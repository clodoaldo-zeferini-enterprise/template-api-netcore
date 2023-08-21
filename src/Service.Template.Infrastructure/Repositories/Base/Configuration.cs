using Service.Template.Infrastructure.Repositories.Base.SwaggerConfig;

namespace Service.Template.Infrastructure.Repositories.Base
{
    public class Configuration
    {
        public ConnectionString ConnectionString { get; set; }
        
        public string AllowedHosts { get; set; }    

        public Swagger Swagger { get; set; }
    }
}
