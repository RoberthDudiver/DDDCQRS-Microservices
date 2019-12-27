using System;
using System.Reflection;
using Autofac;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using N5.Configuration;
using DDDCQRS.Microservice.Api.Infrastructure.AutofacModules;
using DDDCQRS.Microservice.Infrastructure;

namespace DDDCQRS.Microservice.Api {
    public class Startup {
        public Startup (IWebHostEnvironment env) {
            _configuration = new ConfigurationBuilder ()
                .AddJsonFile ("Configuration/appsettings.json")
                .AddJsonFile ($"Configuration/appsettings.{env.EnvironmentName}.json")
                .Build ();
        }

        private readonly IConfiguration _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddControllers ();
            services.AddMediatR (typeof (Startup).GetTypeInfo ().Assembly);
            services.AddCustomDbContext(_configuration);

            services.AddSwaggerGen (c => c.SwaggerDoc ("v1", new OpenApiInfo { Title = "DDDCQRS.Microservice.Api", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });

            app.UseSwagger ();

            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "N5 Microservice v1");
                // Route Prefix
            });
        }

        public void ConfigureContainer (ContainerBuilder builder) {
            builder.RegisterModule(new InfrastructureModule(_configuration.GetConnectionString(ConnectionStrings.SqlServerConnection)));
            builder.RegisterModule (new MediatorModule ());
        }
    }

    static class CustomExtensionsMethod {
        public static IServiceCollection AddCustomDbContext (this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<ProductsContext> (options => {
                options.UseSqlServer (configuration.GetConnectionString (ConnectionStrings.SqlServerConnection),
                    sqlServerOptionsAction : sqlOptions => {
                        sqlOptions.MigrationsAssembly (typeof (Startup).GetTypeInfo ().Assembly.GetName ().Name);
                        sqlOptions.EnableRetryOnFailure (maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds (30), errorNumbersToAdd: null);
                    });
            });

            return services;
        }
    }
}