using System;

namespace Service.Template.Application.Models.Request.Log
{
    public class LogRequest
    {
        public Guid SysUsuSessionId { get; set; }

        private LogRequest()
        {
        }
        public LogRequest(Guid sysUsuSessionId)
        {
            SysUsuSessionId = sysUsuSessionId;
        }
    }
}
