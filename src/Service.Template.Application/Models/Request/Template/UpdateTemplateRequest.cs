using Service.Template.Application.Base;
using Service.Template.Domain.Enum;
using System;

namespace Service.Template.Application.Models.Request.Template.Template
{
    public class UpdateTemplateRequest : RequestBase
    {
        private void Validate()
        {
            var IsIdValido = Guid.TryParse(Id.ToString(), out Guid idValido);
            var IsSysUsuSessionIdValido = Guid.TryParse(SysUsuSessionId.ToString(), out Guid sysUsuSessionIdValido);

            ValidadorDeRegra.Novo()
                .Quando(!IsSysUsuSessionIdValido, Resource.SysUsuSessionIdInvalido)
                .Quando(!IsIdValido, Resource.IdInvalido)
                .Quando((Nome == null || Nome.Length < 5 || Nome.Length > 100), Resource.NomeInvalido)
                .DispararExcecaoSeExistir();
        }

        public Guid Id { get; set; }
        public EStatus Status { get; set; }
        public string Nome { get; set; }

        public GetTemplateRequest GetTemplateRequest { get; set; }    

        public UpdateTemplateRequest(Guid id, EStatus status, string nome, GetTemplateRequest getTemplateRequest)
        {
            Id = id;
            Status = status;
            Nome = nome;

            GetTemplateRequest = getTemplateRequest;

            Validate();            
        }
    }
}
