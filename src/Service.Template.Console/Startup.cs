using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Template.Application.Mappers;
using Service.Template.Infrastructure.IoC;
using Service.Template.Infrastructure.Mappers;
using System;

namespace Service.Template.Console
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IHost RegisterServices()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((services) =>
                {
                    Registry.RegisterApplication(services);
                    Registry.RegisterDatabase(services);

                    services.RegisterAutoMapper<AutoMapperProfile>();

                })
                .Build();

            return host;
        }
    }
}
