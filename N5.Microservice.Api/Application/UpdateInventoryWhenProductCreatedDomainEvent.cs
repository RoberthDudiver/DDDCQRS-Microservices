using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDCQRS.Microservice.Domain.Events;
using System.Threading;

namespace DDDCQRS.Microservice.Api.Application
{
    public class UpdateInventoryWhenProductCreatedDomainEventHandler
       : INotificationHandler<UpdateInventoryWhenProductCreatedDomainEvent>
    {

        // Todo: Add IInventoryRespository
        // Todo: Add IProductRespository
        public UpdateInventoryWhenProductCreatedDomainEventHandler()
        {
        }

        public async Task Handle(UpdateInventoryWhenProductCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            // Todo: Get all producs from category

            // Todo: Create a new inventory item with the products count as the stock plus one more

            // Todo: Add the new item to the transaction
        }
    }
}
