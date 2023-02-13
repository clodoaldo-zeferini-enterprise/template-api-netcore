using AutoMapper;
using ervice.Template.Domain.Base;
using Newtonsoft.Json;
using Service.Template.Application.Interfaces;
using Service.Template.Application.Models.Request;
using Service.Template.Application.Models.Response;
using Service.Template.Domain.Base;
using Service.Template.Domain.Interfaces.Repositories.DB;
using System;
using System.Threading.Tasks;

namespace Service.Template.Application.UseCases.Template
{
    public class InsertTemplateUseCaseAsync : IUseCaseAsync<InsertTemplateRequest, TemplateOutResponse>, IDisposable
    {
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
        }

        ~InsertTemplateUseCaseAsync()
        {
            Dispose(false);
        }
        #endregion

        private IMapper _mapper;
        private ITemplateRepository _templateRepository;

        private readonly TemplateOutResponse _output;

        public InsertTemplateUseCaseAsync(
                IMapper mapper
              , ITemplateRepository templateRepository
        )
        {
            _mapper = mapper;
            _templateRepository = templateRepository;

            _output = new()
            {
                Resultado = false,
                Mensagem = "Dados Fornecidos são inválidos!"
            };
        }

        public async Task<TemplateOutResponse> ExecuteAsync(InsertTemplateRequest request)
        {
            Domain.Entities.Template templateToInsert = new Domain.Entities.Template(Guid.NewGuid());

            if (!request.IsValidTemplate)
            {
                _output.AddMensagem("Parâmetros recebidos estão inválidos!");
                _output.AddMensagem(JsonConvert.SerializeObject(request, Formatting.Indented));
                return _output;
            }

            try
            {
                templateToInsert = _mapper.Map<Domain.Entities.Template>(request);
                templateToInsert.Status = Domain.Enum.EStatus.ATIVO;
                templateToInsert.DataInsert = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                templateToInsert.Nome = request.Nome;

                _output.Resultado = await _templateRepository.Insert(templateToInsert);
                _output.Mensagem = "Registro inserido com Sucesso!";
            }
            catch (Exception ex)
            {
                Models.Response.Errors.ErrorResponse errorResponse = new("id", "parameter", JsonConvert.SerializeObject(ex, Formatting.Indented));
                System.Collections.Generic.List<Models.Response.Errors.ErrorResponse> errorResponses = new()
                {
                    errorResponse
                };
                _output.ErrorsResponse = new Models.Response.Errors.ErrorsResponse(errorResponses);

                _output.Exceptions.Add(ex);
                _output.AddMensagem("Ocorreu uma falha ao Inserir o Registro!");
                _output.Resultado = false;
            }
            finally
            {
                _output.Request = JsonConvert.SerializeObject(request, Formatting.Indented);
                _output.Data = templateToInsert;
            }

            return _output;
        }
    }
}
