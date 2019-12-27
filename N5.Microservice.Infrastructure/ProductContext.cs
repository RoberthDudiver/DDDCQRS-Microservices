using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DDDCQRS.Microservice.Domain.AggregatesModel.InventoryAggregate;
using DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate;
using DDDCQRS.Microservice.Domain.SeedWork;
using DDDCQRS.Microservice.Infrastructure.EntityConfigurations;
using DDDCQRS.Microservice.Infrastructure.Extensions;

namespace DDDCQRS.Microservice.Infrastructure {
    public class ProductsContext : DbContext , IUnitOfWork {

        private readonly IMediator _mediator;
        public DbSet<Category> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> InventoryItems { get; set; }

        public ProductsContext (DbContextOptions<ProductsContext> options) : base (options) {}

        public ProductsContext (DbContextOptions<ProductsContext> options, IMediator mediator) : base (options) 
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync (CancellationToken cancellationToken = default) 
        {
            await _mediator.DispatchDomainEventsAsync(this);

            _ = base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}