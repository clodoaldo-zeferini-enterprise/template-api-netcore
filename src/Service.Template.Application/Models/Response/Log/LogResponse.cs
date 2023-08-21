using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Template.Application.Models.STS
{
    public class LogResponse
    {
        public bool IsValid { get; set; }

        private LogResponse() { }

        public LogResponse(bool isValid) {
            IsValid = IsValid;

        }
    }
}
