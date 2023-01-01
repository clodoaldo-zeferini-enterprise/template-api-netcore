using Service.Template.Domain.Enum;
using System;

namespace Service.Template.Application.Models
{
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

        public Template(Guid id, string name, EStatus status, DateTime? dataInsert, DateTime? dataUpdate) : this(id)
        {
            Name = name;
            Status = status;
            DataInsert = dataInsert;
            DataUpdate = dataUpdate;
        }
    }
}
