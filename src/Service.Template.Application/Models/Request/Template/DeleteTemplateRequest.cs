using Service.Template.Application.Base;
using Service.Template.Domain.Base;
using System;

namespace Service.Template.Application.Models.Request.Template
{
    public class DeleteTemplateRequest : RequestBase
    {
        public Guid Id { get; set; }

        private DeleteTemplateRequest()
        {
        }

        private void Validate()
        {
            var IsIdValido = Guid.TryParse(Id.ToString(), out Guid idValido);
            var IsSysUsuSessionIdValido = Guid.TryParse(SysUsuSessionId.ToString(), out Guid sysUsuSessionIdValido);

            Base.ValidadorDeRegra.Novo()
                .Quando(!IsIdValido, Base.Resource.IdInvalido)
                .Quando(!IsSysUsuSessionIdValido, Base.Resource.SysUsuSessionIdInvalido)
                .DispararExcecaoSeExistir();
        }

        public DeleteTemplateRequest(Guid id, Guid sysUsuSessionId)
        {
            Id = id;
            SysUsuSessionId = sysUsuSessionId;

            Validate();
        }
    }
}
