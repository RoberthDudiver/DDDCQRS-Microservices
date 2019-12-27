using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using DDDCQRS.Microservice.Api.Infrastructure;
using DDDCQRS.Microservice.Api.Infrastructure.Extensions;
using DDDCQRS.Microservice.Infrastructure;

namespace DDDCQRS.Microservice.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            try
            {  
                host.MigrateDatabase<ProductsContext>((context, services) =>
                {
                    new ProductContextSeed()
                    .SeedAsync(context)
                    .Wait();
                });
                host.Run();
            }
            catch (System.Exception)
            {
                // Todo: add log
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>();
                });
    }
}
