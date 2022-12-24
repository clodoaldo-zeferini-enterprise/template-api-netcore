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
    public class TemplateUseCaseAsync : IUseCaseAsync<TemplateRequest, TemplateOutResponse>, IDisposable
    {
        private IMapper _mapper;
        private ITemplateRepository _pessoaRepository;
        private IUseCaseAsync<TemplateBuscaRequest, TemplateOutResponse> _getTemplateUseCaseAsync;

        public TemplateUseCaseAsync(
              IMapper mapper
            , IUseCaseAsync<TemplateBuscaRequest, TemplateOutResponse> getTemplateUseCaseAsync
            , ITemplateRepository pessoaRepository
        )
        {
            _mapper = mapper;
            _getTemplateUseCaseAsync = getTemplateUseCaseAsync;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<TemplateOutResponse> ExecuteAsync(TemplateRequest request)
        {
            TemplateOutResponse output = new()
            {
                Resultado = false,
                Mensagem = "Dados Fornecidos são inválidos!"
            };

            if (!request.IsValidTemplate) return output;

            Service.Template.Domain.Entities.Template pessoa = new();

            if ((request.EAction == Domain.Enum.EAction.UPDATE) || (request.EAction == Domain.Enum.EAction.DELETE))
            {
                TemplateOutResponse pessoaOutResponse = await _getTemplateUseCaseAsync.ExecuteAsync(new TemplateBuscaRequest(request.Id));

                if (!pessoaOutResponse.Resultado) return output;

                pessoa = _mapper.Map<Service.Template.Domain.Entities.Template>(pessoaOutResponse.Data);
            }

            try
            {
                if (request.EAction == Domain.Enum.EAction.INSERT)
                {
                    pessoa.Nome = request.Nome;
                    pessoa.DataNascimento = DateTime.Parse(request.DataNascimento.ToString("yyyy-MM-dd HH:mm:ss"));
                    pessoa.Status = request.Status;
                    pessoa.DataInsert = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    _pessoaRepository.Insert(pessoa);

                    if (pessoa.Id > 0)
                    {
                        output.Mensagem = "Registro Inserido com Sucesso!";
                        output.Data = pessoa;
                        output.Resultado = true;
                    }
                }
                else if (request.EAction == Domain.Enum.EAction.UPDATE)
                {
                    pessoa.Nome = request.Nome;
                    pessoa.DataNascimento = request.DataNascimento;
                    pessoa.Status = request.Status;
                    pessoa.DataUpdate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    pessoa = new Service.Template.Domain.Entities.Template(request.Id, request.Nome, request.DataNascimento, request.Status);

                    if (await _pessoaRepository.Update(pessoa))
                    {
                        output.Mensagem = "Registro Alterado com Sucesso!";
                        output.Data = await _pessoaRepository.GetById(pessoa.Id);
                        output.Resultado = true;
                    }
                }
                else if (request.EAction == Domain.Enum.EAction.DELETE && await _pessoaRepository.Delete(pessoa))
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
            _pessoaRepository = null;
            _getTemplateUseCaseAsync = null;
        }

        ~TemplateUseCaseAsync()
        {
            Dispose(false);
        }
        #endregion

    }
}
