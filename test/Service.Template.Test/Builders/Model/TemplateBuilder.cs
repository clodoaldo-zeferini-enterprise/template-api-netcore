using Bogus;
using Bogus.DataSets;
using Service.Template.Domain.Enum;

namespace Service.Template.Test.Builders.Model
{
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
            var templateBuilderFaker = new Faker<TemplateBuilder>("pt_BR")
                .RuleFor(u => u.Status, f => f.PickRandom(eStatus));

            var templatesBuilders = templateBuilderFaker.Generate(1);

            return templatesBuilders[0];
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

        public Application.Models.Template Build()
        {
            var template = new Application.Models.Template(Id, Nome, Status, SysUsuSessionId, DataInsert, DataUpdate);
            return template;
        }
    }
}
