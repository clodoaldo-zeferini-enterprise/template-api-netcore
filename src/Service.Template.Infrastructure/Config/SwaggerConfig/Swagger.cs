using Microsoft.Extensions.Configuration;

namespace Service.Template.Infrastructure.Config.SwaggerConfig
{
    public class Swagger
    {
        public SwaggerDoc SwaggerDoc { get; set; }
        public SwaggerEndpoint SwaggerEndpoint { get; set; }

        public OpenApiInfo OpenApiInfo { get; set; }

        public Swagger()
        {
            SwaggerDoc = new SwaggerDoc();
            SwaggerEndpoint = new SwaggerEndpoint();
            OpenApiInfo = new OpenApiInfo();
        }
    }
}
