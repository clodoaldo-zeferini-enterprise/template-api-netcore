using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Template.Domain.Entities
{
    public class DapperQuery
    {
        public Guid SysUsuSessionId { get; set; }
        public string Query { get; set; }

        public DapperQuery()
        {
        }

        public DapperQuery(Guid sysUsuSessionId, string query)
        {
            SysUsuSessionId = sysUsuSessionId;
            Query = query;
        }
    }
}
