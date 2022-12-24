using Service.Template.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Service.Template.Domain.Entities;

namespace Service.Template.Application.Models
{
    public class Template
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Status { get; set; }
        public DateTime? DataInsert { get; set; }
        public DateTime? DataUpdate { get; set; }

        public Template()
        {
        }

        public Template(long id, string nome, DateTime dataNascimento, int status, DateTime? dataInsert, DateTime? dataUpdate)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Status = status;
            DataInsert = dataInsert;
            DataUpdate = dataUpdate;
        }
    }
}
