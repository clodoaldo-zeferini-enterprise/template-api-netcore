using Bogus;

using Service.Template.Domain.Base;
using Service.Template.Domain.Enum;
using Service.Template.Test.Builders.Domain;
using Service.Template.Test.Util;

namespace Service.Template.Test.Template.Domain
{
    public class TemplateTest
    {
        private readonly string _nome;

        private readonly Faker _faker;

        public TemplateTest()
        {
            _faker = new Faker();

            _nome = _faker.Person.FullName;
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Nao_Deve_Template_Ter_Um_Nome_Invalido(string nomeInvalido)
        {
            Assert.Throws<ExcecaoDeDominio>(() =>
                TemplateBuilder.Novo().ComNome(nomeInvalido).Build())
                .ComMensagem(Resource.NomeInvalido);
        }
    }
}
