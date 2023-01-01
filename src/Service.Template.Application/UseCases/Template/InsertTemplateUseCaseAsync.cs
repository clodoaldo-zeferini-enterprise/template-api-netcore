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
    public class InsertTemplateUseCaseAsync : IUseCaseAsync<InsertTemplateRequest, TemplateOutResponse>, IDisposable
    {
        private IMapper _mapper;
        private ITemplateRepository _templateRepository;
        private IUseCaseAsync<GetTemplateRequest, TemplateOutResponse> _getTemplateUseCaseAsync;

        public InsertTemplateUseCaseAsync(
              IMapper mapper
            , IUseCaseAsync<GetTemplateRequest, TemplateOutResponse> getTemplateUseCaseAsync
            , ITemplateRepository templateRepository
        )
        {
            _mapper = mapper;
            _getTemplateUseCaseAsync = getTemplateUseCaseAsync;
            _templateRepository = templateRepository;
        }

        public async Task<TemplateOutResponse> ExecuteAsync(InsertTemplateRequest request)
        {
            TemplateOutResponse output = new()
            {
                Resultado = false,
                Mensagem = "Dados Fornecidos são inválidos!"
            };

            if (!request.IsValidTemplate)
            {
                output.AddMensagem("Parâmetros recebidos estão inválidos!");
                output.AddMensagem(JsonConvert.SerializeObject(request, Formatting.Indented));
                return output;
            }

            Service.Template.Domain.Entities.Template template = new();

            try
            {
                var templateToInsert = _mapper.Map<Domain.Entities.Template>(request);

                templateToInsert.Id = Guid.NewGuid();
                templateToInsert.Name = request.Name;
                templateToInsert.Status = Domain.Enum.EStatus.ATIVO;
                template.DataInsert = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                await _templateRepository.Insert(template);
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
