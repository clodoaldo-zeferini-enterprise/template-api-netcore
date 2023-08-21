
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Service.Template.Application.Interfaces;
using Service.Template.Application.Models.Request.Log;
using Service.Template.Application.Models.Request.STS;
using Service.Template.Application.Models.Request.Template;
using Service.Template.Application.Models.Response;
using Service.Template.Application.Models.STS;
using Service.Template.Domain.Base;
using Service.Template.Repository.Interfaces.Repositories.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Template.Application.UseCases.Template
{
    public class GetTemplateUseCaseAsync : IUseCaseAsync<GetTemplateRequest,  TemplateOutResponse>, IDisposable
    {
        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _configuration = null;
            
            _templateRepository = null;
            _output = null;
            _configuration = null;
            
        }

        ~GetTemplateUseCaseAsync()
        {
            Dispose(false);
        }
        #endregion

        private IConfiguration _configuration;
        private ITemplateRepository _templateRepository;
        private IUseCaseAsync<AuthorizationRequest, AuthorizationOutResponse> _getGetAuthorizationUseCaseAsync;
        private IUseCaseAsync<LogRequest, LogOutResponse> _sendLogUseCaseAsync;
        private TemplateOutResponse _output;

        private TemplateResponse templateResponse;
        private AuthorizationOutResponse authorizationOutResponse;
        private AuthorizationResponse authorizationResponse;


        public GetTemplateUseCaseAsync(
              IConfiguration configuration
            , ITemplateRepository templateRepository
            , IUseCaseAsync<AuthorizationRequest, AuthorizationOutResponse> getGetAuthorizationUseCaseAsync
            , IUseCaseAsync<LogRequest, LogOutResponse> sendLogUseCaseAsync
            )
        {
            _configuration = configuration;
            _templateRepository = templateRepository;
            _getGetAuthorizationUseCaseAsync = getGetAuthorizationUseCaseAsync;
            _sendLogUseCaseAsync = sendLogUseCaseAsync;

            _output = new()
            {
                Resultado = false,
                Mensagem = "Dados Fornecidos são inválidos!"
            };
        }

        public async Task< TemplateOutResponse> ExecuteAsync(GetTemplateRequest request)
        {
            try
            {
                authorizationOutResponse = await _getGetAuthorizationUseCaseAsync.ExecuteAsync(new AuthorizationRequest(request.SysUsuSessionId));

                if (!authorizationOutResponse.Resultado)
                {
                    _output.Resultado = false;
                    _output.Mensagem = "Ocorreu uma falha na Autorização!";
                    _output.Data = null;

                    return _output;
                }


                if (request.Id != null)
                {
                    Service.Template.Domain.Entities.Template template = await _templateRepository.GetById(request.Id.Value);

                    _output.Resultado = true;
                    _output.Mensagem = "Dado recuperado com Sucesso!";
                    _output.Data = template;
                }
                else
                {
                    /*Montando Filtro*/
                    string _query = String.Empty;
                    string _where = String.Empty;

                    string tabela = $@"Template";
                    string select = $@" SELECT [Id],[Nome],[Status],[DataInsert],[DataUpdate],[SysUsuSessionId] FROM [Exemplo].[dbo].[{tabela}] ";

                    if (request.PageNumber <= 0) { request.PageNumber = 1; }
                    if (request.PageSize   <= 0) { request.PageSize   = 1; }

                    _where = "' Status <> -1 '";

                    string whereNome = String.Empty;
                    if (request.FiltraNome && ((request.FiltroNome != null) && (request.FiltroNome.Trim().Length > 0)))
                    {
                        whereNome = $@"' Nome LIKE ' , '''', '%' , '{request.FiltroNome}' , '%', ''''";
                    }

                    string whereDataInsert = String.Empty;
                    if ((request.FiltraDataInsert) && (request.DataInicial != null && request.DataFinal != null))
                    {
                        DateTime aux;

                        if (request.DataInicial > request.DataFinal)
                        {
                            aux = request.DataInicial.Value;
                            request.DataInicial = request.DataFinal;
                            request.DataFinal = aux;
                        }

                        whereDataInsert = $@"' DataInsert BETWEEN ', '''', '{request.DataInicial.Value:yyyy-MM-dd}{$@" 00:00:00.000"}' , '''', ' AND ' , '''', '{request.DataFinal.Value:yyyy-MM-dd}{$@" 23:59:59.999"}', ''''";

                    }
                    
                    _where = $@" SET @WHERE = CONCAT(' WHERE ' , 
                                                        {_where} 
                             
                                                        {((whereNome.Trim().Length > 0)           ? ($@" AND CONCAT({whereNome}));") : ($@""))}

                                                        {((whereDataInsert.Trim().Length > 0) ? ($@" AND CONCAT({whereDataInsert}));") : ($@""))}
                                                    );
                    ";                   

                    _query = $@"
                         DECLARE 
                              @PageNumber            int = {request.PageNumber}
                            , @PageSize              int = {request.PageSize}

                            , @WHERE                 NVARCHAR(MAX) 
                            , @SelectNavigator       NVARCHAR(MAX)
                            , @SelectTabelaDesejada  NVARCHAR(MAX)
                        ;

                        {_where}
                        
                        SET @SelectNavigator = CONCAT(
                                                        ' DECLARE
                                                          @RecordCount     INT
                                                        , @PageCount       INT
                                                        , @Resto           INT
                                                        , @PageSize        INT
                                                        , @PageNumber      INT;',
                                                        '
                                                        SET @PageSize   = ', @PageSize, ';',
                                                        '
                                                        SET @PageNumber = ', @PageNumber, ';',
                                                        '
                                                        SET @RecordCount = (SELECT COUNT(*)
                                                                            FROM
                                                                            {tabela} WITH (NOLOCK) ', @WHERE, ' );

                                                        SET @Resto = (@RecordCount % @PageSize);

                                                        SET @PageCount = (SELECT IIF(@Resto = 0, (@RecordCount / @PageSize), ((@RecordCount / @PageSize) + 1)));

                                                        SELECT 
                                                          @RecordCount RecordCount
                                                        , @PageNumber  PageNumber
                                                        , @PageSize    PageSize
                                                        , @PageCount   PageCount; 

                                                        SET @Resto = (@RecordCount % @PageSize);
                                                        SET @PageCount = (SELECT IIF(@Resto = 0, (@RecordCount / @PageSize), ((@RecordCount / @PageSize) + 1)));
                                                                   

                                                        '
                                                        );

                        EXEC sp_executesql @SelectNavigator;

                        SET @SelectTabelaDesejada = CONCAT( ' {select} '
                                                           , @WHERE, '  ORDER BY ID ', ' OFFSET ', @PageSize * (@PageNumber - 1)
                                                           , ' ROWS FETCH NEXT ', @PageSize, ' ROWS ONLY ; ', ''
                                                         );

                        EXEC sp_executesql @SelectTabelaDesejada;

                        /*SELECT @SelectTabelaDesejada;*/
                      ";

                    var navigatorNovosCasosLog = _templateRepository.GetMultiple(new DapperQuery(request.SysUsuSessionId, _query), new { param = "" },
                                gr => gr.Read<Domain.Entities.Navigator>()
                              , gr => gr.Read<Service.Template.Domain.Entities.Template>()

                              );

                    var navigators = navigatorNovosCasosLog.Item1;
                    var templates = navigatorNovosCasosLog.Item2;

                    TemplateResponse templateResponse = new();


                    List<Models.Response.Navigator> responseNavigators =  new  List<Models.Response.Navigator>();
                    foreach (Domain.Entities.Navigator navigator in navigators)
                    {
                        responseNavigators.Add(new Models.Response.Navigator(navigator.RecordCount, navigator.PageNumber, navigator.PageSize, navigator.PageCount));
                    }

                    List<Service.Template.Application.Models.Template> responseTemplates = new List<Service.Template.Application.Models.Template>();
                    foreach (Domain.Entities.Template template in templates)
                    {
                        responseTemplates.Add(new Service.Template.Application.Models.Template(template.Id, template.Nome, template.Status, template.SysUsuSessionId, template.DataInsert, template.DataUpdate ));
                    }

                    if (responseNavigators.Any() && responseTemplates.Any())
                    {
                        templateResponse.Navigators = responseNavigators;
                        templateResponse.Templates = responseTemplates;

                        _output.Resultado = true;
                        _output.Mensagem = "Dados retornados com sucesso!";
                        _output.Data = templateResponse;
                    }
                    else
                    {
                        _output.Resultado = true;
                        _output.Mensagem = "Nenhum dado encontrado!";
                    }

                    return _output;
                }
            }            
            catch (Exception ex)
            {
                _output.Mensagem = "Ocorreram Exceções durante a execução";
                _output.AddExceptions(ex);
                Models.Response.Errors.ErrorResponse errorResponse = new Models.Response.Errors.ErrorResponse("id", "parameter", JsonConvert.SerializeObject(ex, Formatting.Indented));
                System.Collections.Generic.List<Models.Response.Errors.ErrorResponse> errorResponses = new System.Collections.Generic.List<Models.Response.Errors.ErrorResponse>();
                errorResponses.Add(errorResponse);
                _output.ErrorsResponse = new Models.Response.Errors.ErrorsResponse(errorResponses);
            }
            finally
            {
                _output.Request = JsonConvert.SerializeObject(request, Formatting.Indented);
                _sendLogUseCaseAsync.ExecuteAsync(new LogRequest(request.SysUsuSessionId));
            }

            return _output;
        }
    }
}
