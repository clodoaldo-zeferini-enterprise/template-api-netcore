using Service.Template.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Template.Domain.Entities
{
    [Table("Template")]
    public class Template : Base
    {
        
        public string Nome { get; set; }

        public Template()
        {
        }

        public Template(Guid id)
        {
            Id = id;
        }        
    }
}
