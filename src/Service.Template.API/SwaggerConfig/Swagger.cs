using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Template.API.SwaggerConfig
{
    public class Swagger
    {
        public SwaggerDoc SwaggerDoc { get; }
        public SwaggerEndpoint SwaggerEndpoint { get; }

        public Swagger(IConfiguration configuration)
        {
            OpenApiInfo openApiInfo = new(
                  configuration["Swagger:SwaggerDoc:OpenApiInfo:Title"]
                , configuration["Swagger:SwaggerDoc:OpenApiInfo:Version"]
                );

            SwaggerEndpoint = new SwaggerEndpoint(
                  configuration["Swagger:SwaggerEndpoint:Url"]
                , configuration["Swagger:SwaggerEndpoint:Name"]
                , configuration["Swagger:SwaggerEndpoint:Version"]
                );

            SwaggerDoc = new SwaggerDoc(
                  configuration["Swagger:SwaggerDoc:Name"]
                , openApiInfo
                , SwaggerEndpoint
                );
        }
    }
}
