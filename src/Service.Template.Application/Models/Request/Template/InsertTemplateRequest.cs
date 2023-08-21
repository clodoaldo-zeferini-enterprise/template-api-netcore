using Service.Template.Application.Base;
using System;


namespace Service.Template.Application.Models.Request.Template
{
    public class InsertTemplateRequest : RequestBase
    {
        private void Validate()
        {
            var IsSysUsuSessionIdValido = Guid.TryParse(SysUsuSessionId.ToString(), out Guid sysUsuSessionIdValido);

            ValidadorDeRegra.Novo()
                .Quando(!IsSysUsuSessionIdValido, Resource.SysUsuSessionIdInvalido)
                .Quando((Nome == null || Nome.Length < 5 || Nome.Length > 100), Resource.NomeInvalido)
                .DispararExcecaoSeExistir();
        }

        public GetTemplateRequest GetTemplateRequest { get; set; }   
        public string Nome { get; set; }

        private InsertTemplateRequest()
        {
        }

        public InsertTemplateRequest(string nome, GetTemplateRequest getTemplateRequest)
        {
            Nome = nome;
            GetTemplateRequest = getTemplateRequest;

            Validate();
            
        }
    }
}
