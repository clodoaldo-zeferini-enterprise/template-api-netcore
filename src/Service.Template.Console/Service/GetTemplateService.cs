using Microsoft.Extensions.DependencyInjection;
using Service.Template.Application.Models.Request.Template;
using Service.Template.Application.Models.Response;
using Service.Template.Application.UseCases.Template;

namespace Service.Template.Console.Service
{
    internal class GetTemplateService : IDisposable
    {
        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        ~GetTemplateService()
        {
            Dispose(false);
        }
        #endregion

        private readonly IServiceProvider _serviceProvider;
        private readonly GetTemplateRequest _getTemplateRequest;

        private GetTemplateService() { }

        public GetTemplateService(IServiceProvider serviceProvider, GetTemplateRequest getTemplateRequest)
        {
            _serviceProvider = serviceProvider;
            _getTemplateRequest = getTemplateRequest;
        }

        public async Task<TemplateResponse?> ExecuteAsync()
        {
            var service = ActivatorUtilities.CreateInstance<GetTemplateUseCaseAsync>(_serviceProvider);

            var templateOutResponse = await service.ExecuteAsync(_getTemplateRequest);

            if (templateOutResponse.Data != null)
            {
                var templateResponse = (TemplateResponse)templateOutResponse.Data;
                return templateResponse;
            }
            else
            {
                return null;
            }
        }
    }
}
