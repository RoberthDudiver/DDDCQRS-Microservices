using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate;

namespace DDDCQRS.Microservice.Api.Application.Commands {
    /// <summary>
    /// Handler which processes the command when
    /// customer executes cancel order from app
    /// </summary>
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool> {

        private readonly IProductRepository _repository;
        public DeleteProductCommandHandler(IProductRepository repository) 
        { 
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle (DeleteProductCommand request, CancellationToken cancellationToken) 
        {        
         
            await _repository.DeleteAsync(request.Id);          

            await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return true;
        }
    
    }
}