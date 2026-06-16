using CleanArch.Application.AutoMapper;
using AutoMapper;

namespace CleanArch.Mvc.Configurations
{
    public static class AutoMapperConfig
    {
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            // Register AutoMapper profiles here
            services.AddAutoMapper(typeof(CleanArch.Application.AutoMapper.AutoMapperConfiguration));
            AutoMapperConfiguration.RegisterMappings();
            // Register AutoMapper profiles via the AddAutoMapper extension. The AutoMapperConfiguration.RegisterMappings helper is intentionally a no-op.
            //services.AddAutoMapper(typeof(DomainToViewModelProfile), typeof(ViewModelToDomainProfile));
        }
    }
}
