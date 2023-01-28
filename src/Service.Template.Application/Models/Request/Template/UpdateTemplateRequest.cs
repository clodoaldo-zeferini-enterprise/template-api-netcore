using Service.Template.Application.Models.Request.Template;
using Service.Template.Domain.Enum;
using System;

namespace Service.Template.Application.Models.Request
{
    public class UpdateTemplateRequest : RequestBase
    {

        private bool isValidTemplate;       
        public bool IsValidTemplate
        {
            get 
            {
                bool isValidNome = (Name != null && Name.Length > 1);
                isValidTemplate = (isValidNome);
                return isValidTemplate;
            }
        }

        public Guid Id { get; set; }
        public EStatus Status { get; set; }
        public string Name { get; set; }

        public UpdateTemplateRequest(bool isValidTemplate, Guid id, EStatus status, string name)
        {
            this.isValidTemplate = isValidTemplate;
            Id = id;
            Status = status;
            Name = name;
        }
    }
}
