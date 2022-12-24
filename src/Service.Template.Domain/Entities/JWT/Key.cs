using Newtonsoft.Json;

namespace Service.Template.Domain.Entities.JWT
{
    public class Key
    {
        [JsonProperty("e")]
        public string E { get; set; }

        [JsonProperty("n")]
        public string N { get; set; }

        public string ClientId { get; set; }

        public Key()
        {
        }

        public Key(string e, string n, string clientId)
        {
            E = e;
            N = n;
            ClientId = clientId;
        }
    }
}
