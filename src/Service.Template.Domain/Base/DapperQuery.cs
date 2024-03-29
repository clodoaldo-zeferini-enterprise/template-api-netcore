﻿using System;

namespace Service.Template.Domain.Base
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
