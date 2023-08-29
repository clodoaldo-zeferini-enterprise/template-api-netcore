using Service.Template.Infrastructure.Config.SwaggerConfig;

namespace Service.Template.Infrastructure.Config
{
    public class Configuration
    {
        public ConnectionString ConnectionString { get; set; }

        public string AllowedHosts { get; set; }

        public Swagger Swagger { get; set; }
    }
}
