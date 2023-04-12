
using Newtonsoft.Json;
using Service.Template.Application.Interfaces;
using Service.Template.Application.Models.Request.Template;
using Service.Template.Application.Models.Request.Template.Template;
using Service.Template.Application.Models.Response;
using Service.Template.Repository.Interfaces.Repositories.DB;
using System;
using System.Threading.Tasks;

namespace Service.Template.Application.UseCases.Template
{
    public class UpdateTemplateUseCaseAsync : IUseCaseAsync<UpdateTemplateRequest, TemplateOutResponse>, IDisposable
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

        
        private ITemplateRepository _templateRepository;
        private IUseCaseAsync<GetTemplateRequest, TemplateOutResponse> _getTemplateUseCaseAsync;

        private readonly TemplateOutResponse _output;

        public UpdateTemplateUseCaseAsync(
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

        public async Task<TemplateOutResponse> ExecuteAsync(UpdateTemplateRequest request)
        {
            try
            {
                Service.Template.Domain.Entities.Template template = new Service.Template.Domain.Entities.Template();

                template.Nome = request.Nome;
                template.Status = request.Status;
                template.DataUpdate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                if (await _templateRepository.Update(template))
                {
                    _output.AddMensagem("Registro Alterado com Sucesso!");
                    _output.Data = await _templateRepository.GetById(template.Id);
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
            }

            return _output;
        }
    }
}
