using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DDDCQRS.Microservice.Domain.AggregatesModel.InventoryAggregate;
using DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate;

namespace DDDCQRS.Microservice.Domain.Events
{
    public class UpdateInventoryWhenProductCreatedDomainEventHandler : INotificationHandler<UpdateInventoryWhenProductCreatedDomainEvent>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IProductRepository _productRepository;


        public UpdateInventoryWhenProductCreatedDomainEventHandler(IInventoryRepository inventoryRepository, IProductRepository productRepository)
        {
            _inventoryRepository = inventoryRepository;
            _productRepository = productRepository;
        }

        public async Task Handle(UpdateInventoryWhenProductCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetByCategoryAsync(notification.CategoryId);

            var inventoryItem = new Inventory(notification.CategoryId, products.Count  + 1);

            await _inventoryRepository.AddAsync(inventoryItem);
        }
    }
}
