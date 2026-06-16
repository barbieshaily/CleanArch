using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;

namespace CleanArch.Application.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        //// Registers AutoMapper profiles into the IServiceCollection using the AddAutoMapper extension.
        //public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        //{
        //    services.AddAutoMapper(typeof(DomainToViewModelProfile), typeof(ViewModelToDomainProfile));
        //    return services;
        //}

        public static MapperConfiguration RegisterMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToViewModelProfile>();
                cfg.AddProfile<ViewModelToDomainProfile>();
            });
            return config;
        }
    }
}
