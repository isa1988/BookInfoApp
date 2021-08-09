using System;
using System.IO;
using System.Reflection;
using Autofac;
using BookInfo_Core.Contracts.AreaBook;
using BookInfo_Core.Contracts.AreaBook.AreaAuthor;
using BookInfo_Core.Contracts.AreaBook.AreaGenre;
using BookInfo_Core.Contracts.AreaPublisher;
using BookInfo_DAL.DataBase.Initializer;
using BookInfo_DAL.Repositories.AreaBook;
using BookInfo_DAL.Repositories.AreaBook.AreaAuthor;
using BookInfo_DAL.Repositories.AreaBook.AreaGenre;
using BookInfo_DAL.Repositories.AreaPublisher;
using BookInfo_Services.Contracts.AreaBook;
using BookInfo_Services.Contracts.AreaBook.AreaAuthor;
using BookInfo_Services.Contracts.AreaBook.AreaGenre;
using BookInfo_Services.Contracts.AreaPublisher;
using BookInfo_Services.Services.AreaBook;
using BookInfo_Services.Services.AreaBook.AreaAuthor;
using BookInfo_Services.Services.AreaBook.AreaGenre;
using BookInfo_Services.Services.AreaPublisher;
using BookInfo_WebAPI.AppStart;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace BookInfo_WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Production.json");

            if (env.IsDevelopment())
            {
                builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.Development.json");
            }

            Configuration = builder.Build();

            this.env = env;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddDatabaseContext(Configuration);
            services.AddAutoMapperCustom();
            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation  
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "JWT Token Authentication API",
                    Description = "ASP.NET Core 3.1 Web API",

                });
                // To Enable authorization using Swagger (JWT)  
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "AuthorizationToken",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}

                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                Console.WriteLine(xmlFile);
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                Console.WriteLine(xmlPath);
                swagger.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Swagger Configuration in API  
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyPhone API v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            dbInitializer.InitializeAsync().GetAwaiter().GetResult(); 
        }


        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>();
            builder.RegisterType<BookAuthorRepository>().As<IBookAuthorRepository>();
            builder.RegisterType<BookGenreRepository>().As<IBookGenreRepository>();
            builder.RegisterType<GenreRepository>().As<IGenreRepository>();
            builder.RegisterType<AgeCategoryRepository>().As<IAgeCategoryRepository>();
            builder.RegisterType<BookRepository>().As<IBookRepository>();
            builder.RegisterType<InputWorkRepository>().As<IInputWorkRepository>();
            builder.RegisterType<BookPublisherRepository>().As<IBookPublisherRepository>();
            builder.RegisterType<CoverTypeRepository>().As<ICoverTypeRepository>();
            builder.RegisterType<PublisherRepository>().As<IPublisherRepository>();

                builder.RegisterType<DbInitializer>().As<IDbInitializer>();

            builder.RegisterType<AuthorService>().As<IAuthorService>();
            builder.RegisterType<GenreService>().As<IGenreService>();
            builder.RegisterType<AgeCategoryService>().As<IAgeCategoryService>();
            builder.RegisterType<BookService>().As<IBookService>();
            builder.RegisterType<CoverTypeService>().As<ICoverTypeService>();
            builder.RegisterType<PublisherService>().As<IPublisherService>();
        }
    }
}
