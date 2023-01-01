using Service.Template.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Service.Template.Domain.Entities;
using System.Xml.Linq;

namespace Service.Template.Application.Models.Request
{
    public class DeleteTemplateRequest
    { 
        public Guid SysUsuSessionId { get; set; }
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
