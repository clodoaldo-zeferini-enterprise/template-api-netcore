using ervice.Template.Domain.Base;
using Service.Template.Application.Models.Request.Template;
using System;
using System.ComponentModel.DataAnnotations;

namespace Service.Template.Application.Models.Request
{
    public class GetTemplateRequest : RequestBase
    {
        public UInt16 PageNumber { get; set; }
        public UInt16 PageSize { get; set; }
        public Guid? Id { get; set; }
        public bool FiltraNome { get; set; }
        public string FiltroNome { get; set; }
        public bool FiltraDataInsert { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public bool FiltraStatus { get; set; }
        public UInt16 Status { get; set; }


        private void Validate()
        {
            var IsIdValido = Guid.TryParse(Id.ToString(), out Guid idValido);
            var IsSysUsuSessionIdValido = Guid.TryParse(SysUsuSessionId.ToString(), out Guid sysUsuSessionIdValido);

            ValidadorDeRegra.Novo()
                .Quando(!IsIdValido, Resource.IdInvalido)
                .Quando(!IsSysUsuSessionIdValido, Resource.SysUsuSessionIdInvalido)
                .Quando(((FiltraNome && (FiltroNome == null || FiltroNome.Length == 0 || FiltroNome.Length > 100 ))), Resource.FiltroNomeInvalido)
                .Quando(((!FiltraNome && (FiltroNome != null && FiltroNome.Length != 0))), Resource.FiltroNomeInvalido)

                .Quando((string.IsNullOrEmpty(Nome) || Nome.Length > 100), Resource.NomeInvalido)

                .DispararExcecaoSeExistir();
        }


        private GetTemplateRequest()
        {
        }

        public GetTemplateRequest(Guid id)
        {
            Id = id;
        }

        public GetTemplateRequest(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }


    }
}
