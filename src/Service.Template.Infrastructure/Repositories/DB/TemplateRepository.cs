using Microsoft.Extensions.Configuration;
using Service.Template.Domain.Enum;
using Service.Template.Repository.Interfaces.Repositories.DB;

namespace Service.Template.Infrastructure.Repositories.DB
{
    public class TemplateRepository : Repositories.Base.Repository<Service.Template.Domain.Entities.Template>, ITemplateRepository
    {
        public TemplateRepository(IConfiguration configuration) : base(EDataBaseConnection.ID_DB_Template, configuration)
        {

        }
    }
}
