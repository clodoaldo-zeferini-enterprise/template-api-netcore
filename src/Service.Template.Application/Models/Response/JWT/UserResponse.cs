using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Template.Application.Models.Response.JWT
{
    public class UserResponse
    {
        public bool Autenticado {get; set; }
        public Guid ClientId { get; set; }
        public string Token { get; set; }

        public UserResponse()
        {
        }
        public UserResponse(bool autenticado, Guid clientId, string token)
        {
            Autenticado = autenticado;
            ClientId = clientId;
            Token = token;
        }
    }
}
