
using Service.Template.Application.Base.SwaggerConfig;

namespace Service.Template.Application.Base
{
    public class Configuration
    {
        public ConnectionString ConnectionString { get; set; }
        
        public string AllowedHosts { get; set; }    

        public Swagger Swagger { get; set; }
    }
}
