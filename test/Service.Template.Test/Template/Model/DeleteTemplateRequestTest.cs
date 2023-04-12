using Bogus;

using Service.Template.Application.Base;
using Service.Template.Application.Models.Request;
using Service.Template.Application.Models.Request.Template;
using Service.Template.Domain.Enum;
using Service.Template.Test.Builders.Model;
using Service.Template.Test.Builders.Model.Request.Template;
using Service.Template.Test.Util;

namespace Service.Template.Test.Template.Model
{
    public class DeleteTemplateRequestTest
    {
        public DeleteTemplateRequestTest()
        {
        }

        [Theory]
        [InlineData("2ea8fac2-9543-4523-0000-698994b175ba")]
        public void Nao_Deve_DeleteTemplateRequestTest_Ser_Criado_Com_Id_Invalido(Guid idInvalido)
        {
            Assert.Throws<ExcecaoDeModelo>(() =>
                    DeleteTemplateRequestBuilder.Novo().ComId(idInvalido).Build())
                .ComMensagem(Resource.IdInvalido);

        }


        [Theory]
        [InlineData("2ea8fac2-9543-4523-0000-698994b175ba")]
        public void Nao_Deve_DeleteTemplateRequestTest_Ser_Criado_Com_SysUsuSessionId_Invalido(Guid sysUsuSessionIdInvalido)
        {
            Assert.Throws<ExcecaoDeModelo>(() =>
                    DeleteTemplateRequestBuilder.Novo().ComSysUsuSessionId(sysUsuSessionIdInvalido).Build())
                .ComMensagem(Resource.SysUsuSessionIdInvalido);

        }

    }
}
