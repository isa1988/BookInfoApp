using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace BookInfoApp.WebAPI.AppStart
{
    public static class AutoMapperServiceExtension
    {
        public static void AddAutoMapperCustom(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BookInfoApp.WebAPI.MappingProfile());
                mc.AddProfile(new BookInfoApp.Services.MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
