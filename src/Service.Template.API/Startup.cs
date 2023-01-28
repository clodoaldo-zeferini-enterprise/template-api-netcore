using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Template.Application.Mappers;
using Service.Template.Infrastructure.IoC;
using Service.Template.Infrastructure.Mappers;
using System.Linq;

namespace Service.Template.API
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        private static SwaggerConfig.Swagger swagger;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            swagger = new SwaggerConfig.Swagger(configuration);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins(
                                           "https://localhost:5001"
                                          , "https://Server-DES"
                                          , "https://Server-DES"
                                          , "https://Server-PRO"

                                          ).AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                                  });
            });

            services.AddControllers();

            Registry.RegisterApplication(services);
            Registry.RegisterDatabase(services);

            services.RegisterAutoMapper<AutoMapperProfile>();
 /*
            var key = System.Text.Encoding.ASCII.GetBytes(Configuration["Client:Secret"]);

           
            services.AddAuthentication(
                    x =>
                    {
                        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    }
                )
                .AddJwtBearer(
                    x =>
                    {
                        x.RequireHttpsMetadata = false;
                        x.SaveToken = true;
                        x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    });
            */

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(swagger.SwaggerDoc.Name, new Microsoft.OpenApi.Models.OpenApiInfo {Title = swagger.SwaggerDoc.OpenApiInfo.Title, Version = swagger.SwaggerDoc.OpenApiInfo.Version });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(swagger.SwaggerEndpoint.Url,swagger.SwaggerEndpoint.Name));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
