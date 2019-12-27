using System.Threading.Tasks;
using DDDCQRS.Microservice.Domain.SeedWork;

namespace DDDCQRS.Microservice.Domain.AggregatesModel.InventoryAggregate
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
         Task<Inventory> AddAsync(Inventory inventory);

         Task updateAsync(Inventory inventory);

         Task<Inventory> GetAsync(int inventoryId);
    }
}