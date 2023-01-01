using Service.Template.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Template.Domain.Entities
{
    [Table("Template")]
    public class Template
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EStatus Status { get; set; }
        public DateTime? DataInsert { get; set; }
        public DateTime? DataUpdate { get; set; }


        public Template()
        {
        }

        public Template(Guid id)
        {
            Id = id;
        }

        public Template(string name, EStatus status, DateTime? dataInsert, DateTime? dataUpdate)
        {
            Name = name;
            Status = status;
            DataInsert = dataInsert;
            DataUpdate = dataUpdate;
        }

        public Template(Guid id, string name, EStatus status, DateTime? dataInsert, DateTime? dataUpdate) : this(id)
        {
            Name = name;
            Status = status;
            DataInsert = dataInsert;
            DataUpdate = dataUpdate;
        }
    }
}
