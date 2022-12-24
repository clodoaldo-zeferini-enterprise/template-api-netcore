using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Template.Domain.Entities
{
    [Table("Template")]
    public class Template
    {
        [Key]
        public long Id{ get; set; } 

        [Required]
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Status { get; set; }
        public DateTime? DataInsert { get; set; }
        public DateTime? DataUpdate { get; set; }


        public Template()
        {
            Id = 0;
        }

        public Template(long id)
        {
            Id = id;
        }

        public Template(string nome, DateTime dataNascimento, int status)
        {
            Id = 0;
            Nome = nome;
            DataNascimento = dataNascimento;
            Status = status;
        }

        public Template(long id, string nome, DateTime dataNascimento, int status) : this(id)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Status = status;
        }

        public Template(string nome, DateTime dataNascimento, int status, DateTime? dataUpdate) : this(nome, dataNascimento, status)
        {
            DataUpdate = dataUpdate;
        }

        public Template(long id, string nome, DateTime dataNascimento, int status, DateTime? dataInsert, DateTime? dataUpdate) : this(id, nome, dataNascimento, status)
        {
            DataInsert = dataInsert;
            DataUpdate = dataUpdate;
        }
    }
}
