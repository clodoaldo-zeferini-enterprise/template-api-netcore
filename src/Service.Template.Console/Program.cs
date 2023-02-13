using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Service.Template.Application.Models.Request;
using Service.Template.Console.Service;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder();
        BuildConfig(builder);

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                Service.Template.Infrastructure.IoC.Registry.RegisterApplication(services);
                Service.Template.Infrastructure.IoC.Registry.RegisterDatabase(services);

            })
            .Build();

        using (GetTemplateService getTemplateService = new GetTemplateService(host.Services, new GetTemplateRequest(1, 10)))
        {
            getTemplateService.ExecuteAsync();
        }
    }

    private static void BuildConfig(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json",
                optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
    }
}

