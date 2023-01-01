using Service.Template.Application.Interfaces;
using Service.Template.Application.Models.Request.JWT;
using Service.Template.Application.Models.Request;
using Service.Template.Application.Models.Response.JWT;
using Service.Template.Application.Models.Response;
using Service.Template.Application.UseCases.JWT;
using Service.Template.Application.UseCases.Template;
using Service.Template.Infrastructure.Repositories.DBTemplate;
using Microsoft.Extensions.DependencyInjection;
using Service.Template.Domain.Interfaces.Repositories.DB;

namespace Service.Template.Infrastructure.IoC
{
    public static class Registry
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            #region[Registrar Injeção de Dependência - Authentication]
            services.AddTransient<IUseCaseAsync<UserRequest, UserOutResponse>, AutenticarUserUseCaseAsync>();
            #endregion[Registrar Injeção de Dependência - Authentication]

            #region[Registrar Injeção de Dependência - Template]
            services.AddTransient<IUseCaseAsync<DeleteTemplateRequest, TemplateOutResponse>, DeleteTemplateUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<GetTemplateRequest, TemplateOutResponse>, GetTemplateUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<InsertTemplateRequest, TemplateOutResponse>, InsertTemplateUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<UpdateTemplateRequest, TemplateOutResponse>, UpdateTemplateUseCaseAsync>();
            #endregion[Registrar Injeção de Dependência - Template]
        }

        public static void RegisterDatabase(this IServiceCollection services)
        {
            #region[Registrar Injeção de Dependência - Repositorio - DBTemplate]
            services.AddTransient<ITemplateRepository, TemplateRepository>();
            #endregion[Registrar Injeção de Dependência - Repositorio - DBTemplate]

        }
    }
}
