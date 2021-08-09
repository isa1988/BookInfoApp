using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfo_DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookInfo_WebAPI.AppStart
{
    public static class DatabaseContextServiceExtension
    {
        public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DbContextBookInfoApp>(options => options.UseNpgsql(connection));
        }
    }
}
