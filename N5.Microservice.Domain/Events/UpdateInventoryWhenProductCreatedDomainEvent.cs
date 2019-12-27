using MediatR;

namespace DDDCQRS.Microservice.Domain.Events
{
    public class UpdateInventoryWhenProductCreatedDomainEvent : INotification
    {
        public int CategoryId { get; set; }

        public UpdateInventoryWhenProductCreatedDomainEvent(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
