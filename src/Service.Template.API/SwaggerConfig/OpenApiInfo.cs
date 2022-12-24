using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Template.API.SwaggerConfig
{
    public class OpenApiInfo
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public OpenApiInfo()
        {
        }
        public OpenApiInfo(string title, string version)
        {
            Title = title;
            Version = version;
        }
    }
}
