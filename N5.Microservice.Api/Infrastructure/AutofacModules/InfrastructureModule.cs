using DDDCQRS.Microservice.Domain.AggregatesModel.InventoryAggregate;
using DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate;
using DDDCQRS.Microservice.Infrastructure.ConnectionFactory;
using DDDCQRS.Microservice.Infrastructure.Finder;
using DDDCQRS.Microservice.Infrastructure.Repository;
using Autofac;

namespace DDDCQRS.Microservice.Api.Infrastructure.AutofacModules
{
    public class InfrastructureModule : Autofac.Module
    {
        private readonly string _connectionString;

        public InfrastructureModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", _connectionString)
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<InventoryRepository>()
                .As<IInventoryRepository>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<ProductFinder>()
                .As<IProductFinder>()
                .InstancePerLifetimeScope();  

            builder.RegisterType<CategoryFinder>()
                .As<ICategoryFinder>()
                .InstancePerLifetimeScope();
        }
    }
}