using Autofac;
using BookInfoApp.WebAPI.AppStart.AutoFac;
using Microsoft.Extensions.DependencyInjection;

namespace BookInfoApp.WebAPI.AppStart
{
    public static class AutofacServiceExtension
    {
        public static IContainer ConfigureAutofac(this IServiceCollection services)
        {
            var container = new AutofacContainer();
            return container.Build(services);
        }
    }
}
