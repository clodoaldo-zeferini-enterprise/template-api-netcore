﻿
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Service.Grupo.Application.Interfaces;
using Service.Grupo.Application.Models.Request.Grupo;
using Service.Grupo.Application.Models.Request.STS;
using Service.Grupo.Application.Models.Response;
using Service.Grupo.Application.Models.STS;
using Service.Grupo.Repository.Interfaces.Repositories.DB;
using Service.Grupo.Application.Models.Request.Log;
using System;
using System.Threading.Tasks;

namespace Service.Grupo.Application.UseCases.Grupo
{
    public class InsertGrupoUseCaseAsync : IUseCaseAsync<InsertGrupoRequest,  GrupoOutResponse>, IDisposable
    {
        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            
            _grupoRepository = null;
        }

        ~InsertGrupoUseCaseAsync()
        {
            Dispose(false);
        }
        #endregion

        private IConfiguration _configuration;
        private IGrupoRepository _grupoRepository;
        private IUseCaseAsync<AuthorizationRequest, AuthorizationOutResponse> _getGetAuthorizationUseCaseAsync;
        private IUseCaseAsync<GetGrupoRequest, GrupoOutResponse> _getGrupoUseCaseAsync;
        private IUseCaseAsync<LogRequest, LogOutResponse> _sendLogUseCaseAsync;

        private GrupoOutResponse _output;
        private GrupoResponse         GrupoResponse;
        private AuthorizationOutResponse authorizationOutResponse;
        private AuthorizationResponse    authorizationResponse;
        private Domain.Entities.Grupo GrupoToInsert;

        public InsertGrupoUseCaseAsync(
              IConfiguration configuration
            , IGrupoRepository grupoRepository
            , IUseCaseAsync<AuthorizationRequest, AuthorizationOutResponse> getGetAuthorizationUseCaseAsync
            , IUseCaseAsync<GetGrupoRequest, GrupoOutResponse> getGrupoUseCaseAsync
            , IUseCaseAsync<LogRequest, LogOutResponse> sendLogUseCaseAsync
)
        {
            _configuration = configuration;
            _grupoRepository = grupoRepository;
            _getGetAuthorizationUseCaseAsync = getGetAuthorizationUseCaseAsync;
            _getGrupoUseCaseAsync = getGrupoUseCaseAsync;
            _sendLogUseCaseAsync = sendLogUseCaseAsync;

            _output = new()
            {
                Resultado = false,
                Mensagem = "Dados Fornecidos são inválidos!"
            };
        }

        public async Task<GrupoOutResponse> ExecuteAsync(InsertGrupoRequest request)
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

                GrupoToInsert = new Domain.Entities.Grupo(Guid.NewGuid());
                GrupoToInsert.SysUsuSessionId = request.SysUsuSessionId;
                GrupoToInsert.Status = Domain.Enum.EStatus.ATIVO;
                GrupoToInsert.DataInsert = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                GrupoToInsert.Nome = request.Nome;

                if (await _grupoRepository.Insert(GrupoToInsert))
                {
                    _output.Mensagem  = "Registro inserido com Sucesso!";
                    _output.Data = await _getGrupoUseCaseAsync.ExecuteAsync(request.GetGrupoRequest);
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
