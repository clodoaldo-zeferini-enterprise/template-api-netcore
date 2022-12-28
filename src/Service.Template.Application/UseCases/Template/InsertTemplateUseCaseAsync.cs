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
    public class InsertTemplateUseCaseAsync : IUseCaseAsync<TemplateRequest, TemplateOutResponse>, IDisposable
    {
        private IMapper _mapper;
        private ITemplateRepository _templateRepository;
        private IUseCaseAsync<TemplateBuscaRequest, TemplateOutResponse> _getTemplateUseCaseAsync;

        public InsertTemplateUseCaseAsync(
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

            if ((!request.IsValidTemplate) && (request.EAction != Domain.Enum.EAction.INSERT))
            {
                output.AddMensagem("Parâmetros recebidos estão inválidos!");
                output.AddMensagem(JsonConvert.SerializeObject(request, Formatting.Indented));
                return output;
            }

            Service.Template.Domain.Entities.Template template = new();

            try
            {
                if (request.EAction == Domain.Enum.EAction.INSERT)
                {
                    template.Nome = request.Nome;
                    template.DataNascimento = DateTime.Parse(request.DataNascimento.ToString("yyyy-MM-dd HH:mm:ss"));
                    template.Status = request.Status;
                    template.DataInsert = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    await _templateRepository.Insert(template);

                    if (template.Id > 0)
                    {
                        output.AddMensagem("Registro Inserido com Sucesso!");
                        output.Data = template;
                        output.Resultado = true;
                    }
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

                output.AddMensagem("Ocorreu uma falha ao Inserir o Registro!");
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

        ~InsertTemplateUseCaseAsync()
        {
            Dispose(false);
        }
        #endregion

    }
}
