using System.Reflection;
using Autofac;
using MediatR;
using DDDCQRS.Microservice.Api.Application.Commands;
using DDDCQRS.Microservice.Api.Validations;
using DDDCQRS.Microservice.Domain.Events;

namespace DDDCQRS.Microservice.Api.Infrastructure.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(CreateProductCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(UpdateProductCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(DeleteProductCommandHandler).GetTypeInfo().Assembly)
                     .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(UpdateInventoryWhenProductCreatedDomainEvent).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(INotificationHandler<>));

            builder.Register<ServiceFactory>(context =>
             {
                 var componentContext = context.Resolve<IComponentContext>();
                 return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
             });

            builder.RegisterGeneric(typeof(RequestValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>));     

            // Todo: Register validators
        }
    }
}