using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Template.Domain.Entities.JWT
{
    public class User
    {
        public Guid ClientId { get; set; }
        public string ClientSecret { get; set; }

        public User()
        {
        }

        public User(Guid clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }
    }
}
