
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Service.GetAuthorization.Application.UseCases.GetAuthorization;
using Service.Template.Application.Interfaces;
using Service.Template.Application.Models.Request.Log;
using Service.Template.Application.Models.Request.STS;
using Service.Template.Application.Models.Request.Template;
using Service.Template.Application.Models.Request.Template.Template;
using Service.Template.Application.Models.Response;
using Service.Template.Application.Models.STS;
using Service.Template.Repository.Interfaces.Repositories.DB;
using System;
using System.Threading.Tasks;

namespace Service.Template.Application.UseCases.Template
{
    public class UpdateTemplateUseCaseAsync : IUseCaseAsync<UpdateTemplateRequest,  TemplateOutResponse>, IDisposable
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
            _getTemplateUseCaseAsync = null;
        }

        ~UpdateTemplateUseCaseAsync()
        {
            Dispose(false);
        }
        #endregion

        private IConfiguration _configuration;
        private ITemplateRepository _templateRepository;
        private IUseCaseAsync<AuthorizationRequest, AuthorizationOutResponse> _getGetAuthorizationUseCaseAsync;
        private IUseCaseAsync<GetTemplateRequest,  TemplateOutResponse> _getTemplateUseCaseAsync;
        private IUseCaseAsync<LogRequest, LogOutResponse> _sendLogUseCaseAsync;

        private readonly  TemplateOutResponse _output;
        private TemplateResponse templateResponse;
        private AuthorizationOutResponse authorizationOutResponse;
        private AuthorizationResponse authorizationResponse;
        private Domain.Entities.Template templateToUpdate;

        public UpdateTemplateUseCaseAsync(
              IConfiguration configuration
            , ITemplateRepository templateRepository
            , IUseCaseAsync<AuthorizationRequest, AuthorizationOutResponse> getGetAuthorizationUseCaseAsync
            , IUseCaseAsync<GetTemplateRequest,  TemplateOutResponse> getTemplateUseCaseAsync
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

        public async Task< TemplateOutResponse> ExecuteAsync(UpdateTemplateRequest request)
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

                templateToUpdate = await _templateRepository.GetById(request.Id);

                templateToUpdate.Nome = request.Nome;
                templateToUpdate.Status = request.Status;
                templateToUpdate.SysUsuSessionId = request.SysUsuSessionId;

                templateToUpdate.DataUpdate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                if (await _templateRepository.Update(templateToUpdate))
                {
                    _output.AddMensagem("Registro Alterado com Sucesso!");
                    _output.Data = await _getTemplateUseCaseAsync.ExecuteAsync(request.GetTemplateRequest);
                    _output.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                Models.Response.Errors.ErrorResponse errorResponse =
                    new("id", "parameter", JsonConvert.SerializeObject(ex, Formatting.Indented));
                System.Collections.Generic.List<Models.Response.Errors.ErrorResponse> errorResponses = new()
                {
                    errorResponse
                };
                _output.ErrorsResponse = new Models.Response.Errors.ErrorsResponse(errorResponses);

                _output.AddExceptions(ex);
                _output.AddMensagem("Ocorreu uma falha ao Atualizar o Registro!");
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
