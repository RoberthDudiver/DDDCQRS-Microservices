using MediatR;
using DDDCQRS.Microservice.Domain.AggregatesModel.InventoryAggregate;
using DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate;
using DDDCQRS.Microservice.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace DDDCQRS.Microservice.Api.Application.DomainEventHandlers.ProductCreated
{
    public class UpdateInventoryWhenProductCreatedDomainEventHandler
        : INotificationHandler<UpdateInventoryWhenProductCreatedDomainEvent>
    {
        private readonly IProductRepository _productRepository;
        private readonly IInventoryRepository _inventoryRepository;

        public UpdateInventoryWhenProductCreatedDomainEventHandler(
            IProductRepository productRepository, 
            IInventoryRepository inventoryRepository)
        {
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository;
        }
        public async Task Handle(UpdateInventoryWhenProductCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetByCategoryAsync(notification.CategoryId);

            var inventoryItem = new Inventory(notification.CategoryId, products.Count);
            
            await _inventoryRepository.AddAsync(inventoryItem);
        }
    }
}
