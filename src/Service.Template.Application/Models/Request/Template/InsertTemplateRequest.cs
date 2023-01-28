using System;
using Service.Template.Application.Models.Request.Template;


namespace Service.Template.Application.Models.Request
{
    public class InsertTemplateRequest : RequestBase
    {
        private bool isValidTemplate;       
        public bool IsValidTemplate
        {
            get 
            {
                bool isValidNome = Nome is { Length: > 1 };
                isValidTemplate = (isValidNome);
                return isValidTemplate;
            }
        }

        public string Nome { get; set; }

        public InsertTemplateRequest(string nome)
        {
            Nome = nome;
        }
    }
}
