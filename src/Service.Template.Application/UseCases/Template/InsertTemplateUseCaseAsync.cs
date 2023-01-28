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

        private TemplateOutResponse output;

        public InsertTemplateUseCaseAsync(
              IMapper mapper
            , IUseCaseAsync<GetTemplateRequest, TemplateOutResponse> getTemplateUseCaseAsync
            , ITemplateRepository templateRepository
        )
        {
            _mapper = mapper;
            _getTemplateUseCaseAsync = getTemplateUseCaseAsync;
            _templateRepository = templateRepository;

            output = new()
            {
                Resultado = false,
                Mensagem = "Dados Fornecidos são inválidos!"
            };
        }

        public async Task<TemplateOutResponse> ExecuteAsync(InsertTemplateRequest request)
        {
            Domain.Entities.Template templateToInsert = new Domain.Entities.Template();

            if (!request.IsValidTemplate)
            {
                output.AddMensagem("Parâmetros recebidos estão inválidos!");
                output.AddMensagem(JsonConvert.SerializeObject(request, Formatting.Indented));
                return output;
            }

            try
            {
                templateToInsert = _mapper.Map<Domain.Entities.Template>(request);

                templateToInsert.Id = Guid.NewGuid();
                templateToInsert.Status = Domain.Enum.EStatus.ATIVO;
                templateToInsert.DataInsert = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                

                templateToInsert.Nome = request.Nome;


                output.Resultado = await _templateRepository.Insert(templateToInsert);
                output.Mensagem = "Registro inserido com Sucesso!";
            }
            catch (Exception ex)
            {
                Models.Response.Errors.ErrorResponse errorResponse = new("id", "parameter", JsonConvert.SerializeObject(ex, Formatting.Indented));
                System.Collections.Generic.List<Models.Response.Errors.ErrorResponse> errorResponses = new()
                {
                    errorResponse
                };
                output.ErrorsResponse = new Models.Response.Errors.ErrorsResponse(errorResponses);

                output.Exceptions.Add(ex);
                output.AddMensagem("Ocorreu uma falha ao Inserir o Registro!");
                output.Resultado = false;
            }
            finally
            {
                output.Request = JsonConvert.SerializeObject(request, Formatting.Indented);
                output.Data = templateToInsert;
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
