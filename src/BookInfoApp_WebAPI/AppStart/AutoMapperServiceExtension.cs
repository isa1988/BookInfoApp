using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace BookInfo_WebAPI.AppStart
{
    public static class AutoMapperServiceExtension
    {
        public static void AddAutoMapperCustom(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BookInfo_WebAPI.MappingProfile());
                mc.AddProfile(new BookInfo_Services.MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
