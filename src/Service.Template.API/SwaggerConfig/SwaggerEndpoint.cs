using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Template.API.SwaggerConfig
{
    public class SwaggerEndpoint
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }

        public SwaggerEndpoint()
        {
        }

        public SwaggerEndpoint(string url, string name, string version)
        {
            Url = url;
            Name = name;
            Version = version;
        }
    }
}
