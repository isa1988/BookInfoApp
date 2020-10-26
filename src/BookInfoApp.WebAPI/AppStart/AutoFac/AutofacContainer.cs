using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BookInfoApp.Core.Contracts;
using BookInfoApp.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookInfoApp.WebAPI.AppStart.AutoFac
{
    public class AutofacContainer
    {
        public IContainer Build(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);

            var assemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .OrderByDescending(a => a.FullName)
                .ToArray();

            ServicesRegister(builder, assemblies);
            RepositoriesRegister(builder, assemblies);

            return builder.Build();
        }

        private void ServicesRegister(ContainerBuilder builder, Assembly[] assemblies)
        {
            string line = "BookInfoApp.Services".ToLower();
            var servicesAssembly = AssemblyHelper.FindAssemblyByName(assemblies, line);
            builder.RegisterAssemblyTypes(servicesAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }

        private void RepositoriesRegister(ContainerBuilder builder, Assembly[] assemblies)
        {
            string line = "BookInfoApp.DAL".ToLower();
            var dataAssembly = AssemblyHelper.FindAssemblyByName(assemblies, line);
            builder.RegisterAssemblyTypes(dataAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

        }
    }
}
