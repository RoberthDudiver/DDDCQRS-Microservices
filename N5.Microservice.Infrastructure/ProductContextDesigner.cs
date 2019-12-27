using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using N5.Configuration;

namespace DDDCQRS.Microservice.Infrastructure {
    public class ProductContextDesigner : IDesignTimeDbContextFactory<ProductsContext> {
        public ProductsContext CreateDbContext (string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<ProductsContext> ()
                .UseSqlServer (AppConfiguration.GetConnectionString (ConnectionStrings.SqlServerConnection)
                , options => options.MigrationsAssembly("DDDCQRS.Microservice.Api"));

            return new ProductsContext (optionsBuilder.Options, new NoMediator ());
        }
    }

    public class NoMediator : IMediator {
        public Task Publish (object notification, CancellationToken cancellationToken = default) {
            return Task.CompletedTask;
        }

        public Task Publish<TNotification> (TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification {
            return Task.CompletedTask;
        }

        public Task<TResponse> Send<TResponse> (IRequest<TResponse> request, CancellationToken cancellationToken = default) {
            return Task.FromResult<TResponse> (default (TResponse));
        }
    }
}