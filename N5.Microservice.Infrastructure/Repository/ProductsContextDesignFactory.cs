using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using N5.Configuration;
namespace DDDCQRS.Microservice.Infrastructure.Repository
{
    public class ProductsContextDesignFactory : IDesignTimeDbContextFactory<ProductsContext>
    {

        public ProductsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductsContext>()
                .UseSqlServer(AppConfiguration.GetConnectionString(ConnectionStrings.SqlServerConnection));

            return new ProductsContext(optionsBuilder.Options, new NoMediator());
        }

        class NoMediator : IMediator
        {

            public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default(CancellationToken)) where TNotification : INotification
            {
                return Task.CompletedTask;
            }

            public Task Publish(object notification, CancellationToken cancellationToken = default)
            {
                return Task.CompletedTask;
            }

            public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
            {
                return Task.FromResult<TResponse>(default(TResponse));
            }

            public Task Send(IRequest request, CancellationToken cancellationToken = default(CancellationToken))
            {
                return Task.CompletedTask;
            }

        }
    }
}
