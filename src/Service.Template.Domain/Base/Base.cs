using Service.Template.Domain.Enum;
using System;

namespace Service.Template.Domain.Base
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
