using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DDDCQRS.Microservice.Api.Validations;
using DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate;

namespace DDDCQRS.Microservice.Api.Application.Commands {
    /// <summary>
    /// Handler which processes the command when
    /// customer executes cancel order from app
    /// </summary>
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int> {

        private readonly IProductRepository _repository;
        public CreateProductCommandHandler (IProductRepository repository) 
        { 
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<int> Handle (CreateProductCommand request, CancellationToken cancellationToken) 
        {
            var product = new Product (request.ProductName, request.ProductDescription, request.ProductPrice);
            product.AddCategoryId (request.ProductCategoryId);

            new ProductValidator().Validate(product);

            await _repository.AddAsync(product);          

            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return product.Id;
        }
    }
}