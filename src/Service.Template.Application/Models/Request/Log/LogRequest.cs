using System;

namespace Service.Template.Application.Models.Request.STS
{
    public class AuthorizationRequest
    {
        public Guid SysUsuSessionId { get; set; }

        private AuthorizationRequest()
        {
        }
        public AuthorizationRequest(Guid sysUsuSessionId)
        {
            SysUsuSessionId = sysUsuSessionId;
        }
    }
}
