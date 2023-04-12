using Bogus;

using Service.Template.Application.Base;
using Service.Template.Domain.Enum;
using Service.Template.Test.Builders.Model;
using Service.Template.Test.Util;

namespace Service.Template.Test.Template.Model
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
            Assert.Throws<ExcecaoDeModelo>(() =>
                    TemplateBuilder.Novo().ComNome(nomeInvalido).Build())
                .ComMensagem(Resource.NomeInvalido);
        }

        [Theory]
        [InlineData("2ea8fac2-9543-4523-0000-698994b175ba")]
        public void Nao_Deve_Template_Ser_Criado_Com_Id_Invalido(Guid idInvalido)
        {
            Assert.Throws<ExcecaoDeModelo>(() =>
                    TemplateBuilder.Novo().ComId(idInvalido).Build())
                .ComMensagem(Resource.NomeInvalido);
        }

        [Theory]
        [InlineData("2ea8fac2-9543-4523-0000-698994b175ba")]
        public void Nao_Deve_Template_Ser_Criado_Com_SysUsuSessionId_Invalido(Guid sysUsuSessionIdInvalido)
        {
            Assert.Throws<ExcecaoDeModelo>(() =>
                    TemplateBuilder.Novo().ComSysUsuSessionId(sysUsuSessionIdInvalido).Build())
                .ComMensagem(Resource.NomeInvalido);
        }

        [Theory]
        [InlineData(50)]
        public void Nao_Deve_Template_Ser_Criado_Com_EStatus_Invalido(int eStatusInvalido)
        {
            Assert.Throws<ExcecaoDeModelo>(() =>
                    TemplateBuilder.Novo().ComStatus((EStatus)eStatusInvalido).Build())
                .ComMensagem(Resource.NomeInvalido);
        }
    }
}
