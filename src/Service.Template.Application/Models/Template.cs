using Service.Template.Application.Base;
using Service.Template.Domain.Enum;
using System;

namespace Service.Template.Application.Models
{
    public class Template : Base.Base
    {
        public string Nome { get; set; }

        private void Validate()
        {
            var IsIdValido = Guid.TryParse(Id.ToString(), out Guid idValido);

            ValidadorDeRegra.Novo()
                .Quando(!IsIdValido, Resource.IdInvalido)
                .Quando((string.IsNullOrEmpty(Nome) || Nome.Length > 100), Resource.NomeInvalido)
                .DispararExcecaoSeExistir();
        }
        public Template()
        {
        }

        public Template(Guid id)
        {
            Id = id;

            var IsIdValido = Guid.TryParse(Id.ToString(), out Guid idValido);

            ValidadorDeRegra.Novo()
                .Quando(!IsIdValido, Resource.IdInvalido)
                .DispararExcecaoSeExistir();

        }

        public Template(string nome, EStatus status, DateTime? dataInsert, DateTime? dataUpdate)
        {
            Nome = nome;
            Status = status;
            DataInsert = dataInsert;
            DataUpdate = dataUpdate;

            var IsIdValido = Guid.TryParse(Id.ToString(), out Guid idValido);

            ValidadorDeRegra.Novo()
                .Quando(!IsIdValido, Resource.IdInvalido)
                .Quando((string.IsNullOrEmpty(Nome) || Nome.Length > 100), Resource.NomeInvalido)
                .DispararExcecaoSeExistir();

        }
    }
}
