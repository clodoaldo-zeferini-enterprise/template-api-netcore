using System.Runtime.CompilerServices;
using Bogus;
using Bogus.DataSets;
using Service.Template.Domain.Enum;

namespace Service.Template.Test.Builders.Model.Request.Template
{
    public class DeleteTemplateRequestBuilder
    {
        private Guid Id { get; set; }
        private Guid SysUsuSessionId { get; set; }

        public static DeleteTemplateRequestBuilder Novo()
        {
            return new DeleteTemplateRequestBuilder();
        }
        
        public DeleteTemplateRequestBuilder ComId(string id)
        {
            SysUsuSessionId = Guid.NewGuid();

            if (Guid.TryParse(id, out var newGuid))
            {
                Id = newGuid;
                return this;
            }

            return null;
        }

        public DeleteTemplateRequestBuilder ComSysUsuSessionId(string sysUsuSessionId)
        {
            Id = Guid.NewGuid();

            if (Guid.TryParse(sysUsuSessionId, out var newGuid))
            {
                SysUsuSessionId = newGuid;
                return this;
            }

            return null;
        }

        public Application.Models.Request.Template.DeleteTemplateRequest Build()
        {
            var template = new Application.Models.Request.Template.DeleteTemplateRequest(Id, SysUsuSessionId);
            return template;
        }
    }
}
