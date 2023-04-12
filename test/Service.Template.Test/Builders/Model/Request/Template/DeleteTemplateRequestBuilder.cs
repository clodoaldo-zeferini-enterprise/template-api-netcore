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
        
        public DeleteTemplateRequestBuilder ComId(Guid id)
        {
            SysUsuSessionId = Guid.NewGuid();
            Id = id;
            return this;
        }

        public DeleteTemplateRequestBuilder ComSysUsuSessionId(Guid sysUsuSessionId)
        {
            Id = Guid.NewGuid();
            SysUsuSessionId = sysUsuSessionId;
            return this;
        }

        public Application.Models.Request.Template.DeleteTemplateRequest Build()
        {
            var template = new Application.Models.Request.Template.DeleteTemplateRequest(Id, SysUsuSessionId);
            return template;
        }
    }
}
