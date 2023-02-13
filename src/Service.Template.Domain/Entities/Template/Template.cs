using ervice.Template.Domain.Base;
using Service.Template.Domain.Base;
using Service.Template.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Template.Domain.Entities
{
    [Table("Template")]
    public class Template : Base.Base
    {
        public string Nome { get; set; }

        private void Validate()
        {
            var IsIdValido = Guid.TryParse(Id.ToString(), out Guid idValido);
            var IsSysUsuSessionIdValido = Guid.TryParse(SysUsuSessionId.ToString(), out Guid sysUsuSessionIdValido);

            ValidadorDeRegra.Novo()
                .Quando(!IsIdValido, Resource.IdInvalido)
                .Quando((string.IsNullOrEmpty(Nome) || Nome.Length > 100), Resource.NomeInvalido)
                .Quando(!IsSysUsuSessionIdValido, Resource.SysUsuSessionIdInvalido)
                .DispararExcecaoSeExistir();
        }

        private Template() { }

        public Template(Guid id, string nome, EStatus status, Guid sysUsuSessionId)
        {
            Id = id;
            Nome = nome;
            Status = status;
            SysUsuSessionId = sysUsuSessionId;

            Validate();
        }

        public Template(Guid id)
        {
            var IsIdValido = Guid.TryParse(Id.ToString(), out Guid idValido);
            
            ValidadorDeRegra.Novo().Quando(!IsIdValido, Resource.IdInvalido).DispararExcecaoSeExistir();

            Id = id;
        }

        public void AlterarNome(string nome)
        {
            ValidadorDeRegra.Novo()
                .Quando((string.IsNullOrEmpty(nome) || nome.Length > 100), Resource.NomeInvalido)
                .DispararExcecaoSeExistir();

            Nome = nome;
        }
    }
}
