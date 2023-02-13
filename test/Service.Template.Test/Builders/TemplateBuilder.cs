using Service.Template.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Bogus.DataSets;

namespace Service.Template.Test.Builders
{
    public class EstatusFaker
    {

    }

    public class TemplateBuilder
    {
        private Guid Id { get; set; }
        private EStatus Status { get; set; }
        private DateTime? DataInsert { get; set; }
        private DateTime? DataUpdate { get; set; }
        private Guid SysUsuSessionId { get; set; }
        private string Nome { get; set; }

        public static TemplateBuilder Novo()
        {
            var eStatus = new EStatus[] { EStatus.ATIVO, EStatus.INATIVO, EStatus.EXCLUIDO };
            var faker = new Faker<TemplateBuilder>()
                .RuleFor(u => u.Status, f => f.PickRandom(eStatus));

            return new TemplateBuilder
            {
                Id = Guid.NewGuid(),
                Status = faker.Generate(1)[0].Status,
                DataInsert = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                SysUsuSessionId = Guid.NewGuid()
            };
        }

        public TemplateBuilder ComNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public TemplateBuilder ComStatus(EStatus eStatus)
        {
            Status = eStatus;
            return this;
        }

        public TemplateBuilder ComId(Guid id)
        {
            Id = id;
            return this;
        }

        public TemplateBuilder ComSysUsuSessionId(Guid sysUsuSessionId)
        {
            SysUsuSessionId = sysUsuSessionId;
            return this;
        }

        public Domain.Entities.Template Build()
        {
            var template = new Domain.Entities.Template(Id, Nome, Status, SysUsuSessionId);
                
            return template;
        }
    }
}
