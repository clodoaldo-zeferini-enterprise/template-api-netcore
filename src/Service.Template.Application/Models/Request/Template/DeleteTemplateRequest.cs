using Service.Template.Application.Models.Request.Template;
using System;

namespace Service.Template.Application.Models.Request
{
    public class DeleteTemplateRequest : RequestBase
    { 
        public Guid Id { get; set; }


        private bool isValidTemplate;
        public bool IsValidTemplate
        {
            get
            {
                return isValidTemplate;
            }
        }


        public DeleteTemplateRequest(Guid id)
        {
            isValidTemplate = Guid.TryParse(id.ToString(), out Guid idValido);

            if (isValidTemplate) { Id = idValido;}
        }
    }
}
