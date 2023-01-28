using AutoMapper;
using Service.Template.Application.Models.Request;
using Service.Template.Application.Models.Response;
using Service.Template.Domain.Entities;

namespace Service.Template.Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DeleteTemplateRequest, Service.Template.Domain.Entities.Template>();
            CreateMap<InsertTemplateRequest, Service.Template.Domain.Entities.Template>();
            CreateMap<UpdateTemplateRequest, Service.Template.Domain.Entities.Template>();

            CreateMap<Service.Template.Domain.Entities.Template, TemplateResponse>();
        }
    }
}
