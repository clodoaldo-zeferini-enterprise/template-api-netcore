using AutoMapper;
using Service.Template.Application.Models.Response;
using Service.Template.Domain.Entities;

namespace Service.Template.Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Service.Template.Domain.Entities.Template, TemplateResponse>();
        }
    }
}
