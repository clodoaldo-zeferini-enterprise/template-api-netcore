using Service.Template.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Template.Domain.Entities
{
    public class Base
    {
        public Guid Id { get; set; }
        public EStatus Status { get; set; }
        public DateTime? DataInsert { get; set; }
        public DateTime? DataUpdate { get; set; }
        public Guid SysUsuSessionId { get; set; }
    }
}
