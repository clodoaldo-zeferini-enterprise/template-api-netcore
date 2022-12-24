using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Template.Application.Models.Request.JWT
{
    public class UserRequest
    {
        public Guid ClientId { get; set; }
        public string ClientSecret { get; set; }

        public UserRequest()
        {
        }

        public UserRequest(Guid clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }
    }
}
