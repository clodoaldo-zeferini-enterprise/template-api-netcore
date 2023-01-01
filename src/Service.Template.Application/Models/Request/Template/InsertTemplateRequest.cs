using Service.Template.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Service.Template.Domain.Entities;

namespace Service.Template.Application.Models.Request
{
    public class InsertTemplateRequest
    {
        public Guid SysUsuSessionId { get; set; }

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

        public EStatus Status { get; set; }
        public string Name { get; set; }

        public InsertTemplateRequest(EStatus status, string name)
        {
            Status = status;
            Name = name;
        }
    }
}
