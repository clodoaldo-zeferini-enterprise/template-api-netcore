using Service.Template.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Service.Template.Domain.Entities;

namespace Service.Template.Application.Models.Request
{
    public class TemplateRequest : Template
    {
        private bool isValidTemplate;
        public EAction EAction { get; set; }
        public bool IsValidTemplate
        {
            get 
            {
                isValidTemplate = (
                        ((EAction == EAction.INSERT) && (Id == 0) && (Nome != null && Nome.Length > 1) && (DataNascimento < DateTime.Now.AddDays(1)) && (Status == 1))
                    ||  ((EAction == EAction.UPDATE) && (Id != 0) && (Nome != null && Nome.Length > 1) && (DataNascimento < DateTime.Now.AddDays(1)))
                    ||  ((EAction == EAction.DELETE) && (Id != 0))

                    );

                return isValidTemplate;
            }
        }        

        public TemplateRequest()
        {
        }

        public TemplateRequest(EAction eAction, long id, string nome, DateTime dataNascimento, int status, DateTime? dataInsert, DateTime? dataUpdate)
        {
            EAction = eAction;
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Status = status;
            DataInsert = dataInsert;
            DataUpdate = dataUpdate;
        }
    }
}
