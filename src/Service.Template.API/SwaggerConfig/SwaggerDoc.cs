using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Template.API.SwaggerConfig
{
    public class SwaggerDoc
    {
        public string Name { get; set; }
        public OpenApiInfo OpenApiInfo { get; }
        public SwaggerEndpoint SwaggerEndpoint { get; }

        public SwaggerDoc()
        {
        }

        public SwaggerDoc(string name, OpenApiInfo openApiInfo, SwaggerEndpoint swaggerEndpoint)
        {
            Name = name;
            OpenApiInfo = openApiInfo;
            SwaggerEndpoint = swaggerEndpoint;
        }
    }
}
