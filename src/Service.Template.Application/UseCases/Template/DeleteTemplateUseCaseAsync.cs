using AutoMapper;
using Newtonsoft.Json;
using Service.Template.Application.Interfaces;
using Service.Template.Application.Models.Request;
using Service.Template.Application.Models.Response;
using Service.Template.Domain.Interfaces.Repositories.DB;
using System;
using System.Threading.Tasks;

namespace Service.Template.Application.UseCases.Template
{
    public class DeleteTemplateUseCaseAsync : IUseCaseAsync<TemplateRequest, TemplateOutResponse>, IDisposable
    {
        private IMapper _mapper;
        private ITemplateRepository _templateRepository;
        private IUseCaseAsync<TemplateBuscaRequest, TemplateOutResponse> _getTemplateUseCaseAsync;

        public DeleteTemplateUseCaseAsync(
              IMapper mapper
            , IUseCaseAsync<TemplateBuscaRequest, TemplateOutResponse> getTemplateUseCaseAsync
            , ITemplateRepository templateRepository
        )
        {
            _mapper = mapper;
            _getTemplateUseCaseAsync = getTemplateUseCaseAsync;
            _templateRepository = templateRepository;
        }

        public async Task<TemplateOutResponse> ExecuteAsync(TemplateRequest request)
        {
            TemplateOutResponse output = new()
            {
                Resultado = false,
                Mensagem = "Dados Fornecidos são inválidos!"
            };

            if ((!request.IsValidTemplate) && (request.EAction != Domain.Enum.EAction.DELETE))
            {
                output.AddMensagem("Parâmetros recebidos estão inválidos!");
                output.AddMensagem(JsonConvert.SerializeObject(request, Formatting.Indented));
                return output;
            }

            Service.Template.Domain.Entities.Template template = new();

            if (request.EAction == Domain.Enum.EAction.DELETE)
            {
                TemplateOutResponse templateOutResponse = await _getTemplateUseCaseAsync.ExecuteAsync(new TemplateBuscaRequest(request.Id));

                if (!templateOutResponse.Resultado) return output;

                template = _mapper.Map<Service.Template.Domain.Entities.Template>(templateOutResponse.Data);
            }

            try
            {                
                if (request.EAction == Domain.Enum.EAction.DELETE && await _templateRepository.Delete(template))
                {
                    output.Mensagem = "Registro Excluído com Sucesso!";
                    output.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                Models.Response.Errors.ErrorResponse errorResponse = new("id", "parameter", JsonConvert.SerializeObject(ex, Formatting.Indented));
                System.Collections.Generic.List<Models.Response.Errors.ErrorResponse> errorResponses = new()
                {
                    errorResponse
                };
                output.ErrorsResponse = new Models.Response.Errors.ErrorsResponse(errorResponses);

                output.Mensagem = "Ocorreu uma falha ao Inserir o Registro!";
                output.Resultado = false;
            }
            finally
            {
                output.Request = JsonConvert.SerializeObject(request, Formatting.Indented);
            }

            return output;
        }

        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _mapper = null;
            _templateRepository = null;
            _getTemplateUseCaseAsync = null;
        }

        ~DeleteTemplateUseCaseAsync()
        {
            Dispose(false);
        }
        #endregion

    }
}
