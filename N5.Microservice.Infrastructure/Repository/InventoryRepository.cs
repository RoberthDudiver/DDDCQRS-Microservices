using System.Threading.Tasks;
using DDDCQRS.Microservice.Domain.AggregatesModel.InventoryAggregate;
using DDDCQRS.Microservice.Domain.SeedWork;

namespace DDDCQRS.Microservice.Infrastructure.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ProductsContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public InventoryRepository(ProductsContext context)
        {
            _context = context;
        }

        public async Task<Inventory> AddAsync(Inventory inventory)
        {
            return await Task.FromResult(_context.InventoryItems.Add(inventory).Entity);
        }

        public async Task<Inventory> GetAsync(int inventoryId)
        {
            var inventory = await _context.InventoryItems.FindAsync(inventoryId);
            return inventory;
        }

        public async Task updateAsync(Inventory inventory)
        {
            await Task.Run(() => _context.Entry(inventory).State = Microsoft.EntityFrameworkCore.EntityState.Modified);
        }
    }
}