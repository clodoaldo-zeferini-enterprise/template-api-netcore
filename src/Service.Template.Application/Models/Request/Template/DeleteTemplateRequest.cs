using ervice.Template.Domain.Base;
using Service.Template.Application.Models.Request.Template;
using System;

namespace Service.Template.Application.Models.Request
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

            ValidadorDeRegra.Novo()
                .Quando(!IsIdValido, Resource.IdInvalido)
                .Quando(!IsSysUsuSessionIdValido, Resource.SysUsuSessionIdInvalido)
                .DispararExcecaoSeExistir();
        }


        public DeleteTemplateRequest(Guid id)
        {
            Id = id;
            Validate();
        }
    }
}
