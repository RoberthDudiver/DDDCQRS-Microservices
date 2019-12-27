using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate;
using DDDCQRS.Microservice.Infrastructure;
using Polly;
using Serilog;

namespace DDDCQRS.Microservice.Api.Infrastructure
{
    public class ProductContextSeed
    {
        public async Task SeedAsync(ProductsContext context)
        {
            var policy = CreatePolicy(nameof(ProductContextSeed));

            await policy.ExecuteAsync(async () =>
            {
                using (context)
                {
                    await SeedProductCategories(context);
                }
            }); 
        }

        private async Task SeedProductCategories (ProductsContext context)
        {
            if (!context.ProductCategories.Any())
            {
                var categories = new List<Category> ()
                {
                    new Category("Clothing", "Clothing category"),
                    new Category("Video Games", "Video games category")
                };

                await context.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }
        }

        private AsyncPolicy CreatePolicy(string prefix, int retries = 3)
        {
            return Policy.Handle<SqlException>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                    onRetry: (exception, timeSpan, retry, ctx) => Log.Warning(exception,
                "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}",
                prefix,
                exception.GetType().Name,
                exception.Message,
                retry,
                retries));
        }
    }
}