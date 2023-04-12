
using Newtonsoft.Json;
using Service.Template.Application.Interfaces;
using Service.Template.Application.Models.Request.Template;
using Service.Template.Application.Models.Response;
using Service.Template.Repository.Interfaces.Repositories.DB;
using System;
using System.Threading.Tasks;

namespace Service.Template.Application.UseCases.Template
{
    public class DeleteTemplateUseCaseAsync : IUseCaseAsync<DeleteTemplateRequest, TemplateOutResponse>, IDisposable
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

        ~DeleteTemplateUseCaseAsync()
        {
            Dispose(false);
        }
        #endregion

        
        private ITemplateRepository _templateRepository;
        private IUseCaseAsync<GetTemplateRequest, TemplateOutResponse> _getTemplateUseCaseAsync;

        private readonly TemplateOutResponse _output;

        public DeleteTemplateUseCaseAsync(
              IUseCaseAsync<GetTemplateRequest, TemplateOutResponse> getTemplateUseCaseAsync
            , ITemplateRepository templateRepository
        )
        {
            
            _getTemplateUseCaseAsync = getTemplateUseCaseAsync;
            _templateRepository = templateRepository;

            _output = new()
            {
                Resultado = false,
                Mensagem = "Dados Fornecidos são inválidos!"
            };
        }

        public async Task<TemplateOutResponse> ExecuteAsync(DeleteTemplateRequest request)
        {
            try
            {
                Domain.Entities.Template template = new Domain.Entities.Template(request.Id);

                _output.Resultado = await _templateRepository.Delete(template);

                _output.Mensagem = (_output.Resultado ? "Registro Excluído com Sucesso!" : "Ocorreu uma falha ao Excluir o Registro!");
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
                _output.Mensagem = "Ocorreu uma falha ao Excluir o Registro!";
            }
            finally
            {
                _output.Request = JsonConvert.SerializeObject(request, Formatting.Indented);

                /*Consumir serviço de Log*/
            }

            return _output;
        }
    }
}
