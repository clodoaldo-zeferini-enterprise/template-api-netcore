﻿
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Service.GetAuthorization.Application.UseCases.GetAuthorization;
using Service.Template.Application.Interfaces;
using Service.Template.Application.Models.Request.Log;
using Service.Template.Application.Models.Request.STS;
using Service.Template.Application.Models.Request.Template;
using Service.Template.Application.Models.Response;
using Service.Template.Application.Models.STS;
using Service.Template.Repository.Interfaces.Repositories.DB;
using System;
using System.Threading.Tasks;

namespace Service.Template.Application.UseCases.Template
{
    public class InsertTemplateUseCaseAsync : IUseCaseAsync<InsertTemplateRequest,  TemplateOutResponse>, IDisposable
    {
        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            
            _templateRepository = null;
        }

        ~InsertTemplateUseCaseAsync()
        {
            Dispose(false);
        }
        #endregion

        private IConfiguration _configuration;
        private ITemplateRepository _templateRepository;
        private IUseCaseAsync<AuthorizationRequest, AuthorizationOutResponse> _getGetAuthorizationUseCaseAsync;
        private IUseCaseAsync<GetTemplateRequest, TemplateOutResponse> _getTemplateUseCaseAsync;
        private IUseCaseAsync<LogRequest, LogOutResponse> _sendLogUseCaseAsync;

        private TemplateOutResponse _output;
        private TemplateResponse         templateResponse;
        private AuthorizationOutResponse authorizationOutResponse;
        private AuthorizationResponse    authorizationResponse;
        private Domain.Entities.Template templateToInsert;

        public InsertTemplateUseCaseAsync(
              IConfiguration configuration
            , ITemplateRepository templateRepository
            , IUseCaseAsync<AuthorizationRequest, AuthorizationOutResponse> getGetAuthorizationUseCaseAsync
            , IUseCaseAsync<GetTemplateRequest, TemplateOutResponse> getTemplateUseCaseAsync
            , IUseCaseAsync<LogRequest, LogOutResponse> sendLogUseCaseAsync
)
        {
            _configuration = configuration;
            _templateRepository = templateRepository;
            _getGetAuthorizationUseCaseAsync = getGetAuthorizationUseCaseAsync;
            _getTemplateUseCaseAsync = getTemplateUseCaseAsync;
            _sendLogUseCaseAsync = sendLogUseCaseAsync;

            _output = new()
            {
                Resultado = false,
                Mensagem = "Dados Fornecidos são inválidos!"
            };
        }

        public async Task<TemplateOutResponse> ExecuteAsync(InsertTemplateRequest request)
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

                templateToInsert = new Domain.Entities.Template(Guid.NewGuid());
                templateToInsert.SysUsuSessionId = request.SysUsuSessionId;
                templateToInsert.Status = Domain.Enum.EStatus.ATIVO;
                templateToInsert.DataInsert = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                templateToInsert.Nome = request.Nome;

                if (await _templateRepository.Insert(templateToInsert))
                {
                    _output.Mensagem  = "Registro inserido com Sucesso!";
                    _output.Data = await _getTemplateUseCaseAsync.ExecuteAsync(request.GetTemplateRequest);
                    _output.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                Models.Response.Errors.ErrorResponse errorResponse = new("id", "parameter", JsonConvert.SerializeObject(ex, Formatting.Indented));
                System.Collections.Generic.List<Models.Response.Errors.ErrorResponse> errorResponses = new()
                {
                    errorResponse
                };
                _output.ErrorsResponse = new Models.Response.Errors.ErrorsResponse(errorResponses);

                _output.AddExceptions(ex);
                _output.AddMensagem("Ocorreu uma falha ao Inserir o Registro!");
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
