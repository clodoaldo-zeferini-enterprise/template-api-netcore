﻿using Service.Grupo.Domain.Base;

namespace Service.Grupo.Test.Util
{
    public static class DomainAssertExtension
    {
        public static void ComMensagem(this ExcecaoDeDominio exception, string mensagem)
        {
            if(exception.MensagensDeErro.Contains(mensagem))
                Assert.True(true);
            else
                Assert.False(true, $"Esperava a mensagem '{mensagem}'");
        }
    }
}
