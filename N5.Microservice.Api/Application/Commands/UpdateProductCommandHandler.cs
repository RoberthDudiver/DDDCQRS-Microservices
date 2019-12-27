using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DDDCQRS.Microservice.Api.Validations;
using DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate;

namespace DDDCQRS.Microservice.Api.Application.Commands {
    
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool> {

        private readonly IProductRepository _repository;
        public UpdateProductCommandHandler(IProductRepository repository) 
        { 
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle (UpdateProductCommand request, CancellationToken cancellationToken) 
        {
            // Todo: Validate Rules for product

            try
            {

                await _repository.UpdateAsync(request.ProductId, request.ProductCategoryId);

                await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                return true;

            }
            catch  {
            
            return false;

            }

        }
    }
}