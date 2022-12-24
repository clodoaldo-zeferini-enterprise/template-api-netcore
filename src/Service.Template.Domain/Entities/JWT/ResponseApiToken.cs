using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Template.Domain.Entities.JWT
{
    public class ResponseApiToken
    {
        public string Token { get; set; }
        public string Resultado { get; set; }
        public string Mensagem { get; set; }
        public string Data { get; set; }

        public ResponseApiToken()
        {
        }

        public ResponseApiToken(string token, string resultado, string mensagem, string data)
        {
            Token = token;
            Resultado = resultado;
            Mensagem = mensagem;
            Data = data;
        }
    }
}
