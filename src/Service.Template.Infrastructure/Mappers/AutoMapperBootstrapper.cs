using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Service.Template.Infrastructure.Mappers
{
    public static class AutoMapperBootstrapper
    {
        public static void RegisterAutoMapper<TProfile>(this IServiceCollection serviceCollection ) where TProfile : Profile, new ()
        {
            var autoMapper = new MapperConfiguration(c => c.AddProfile<TProfile>());
            serviceCollection.AddSingleton(autoMapper.CreateMapper());
        }
    }
}
