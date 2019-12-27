using System.Collections.Generic;
using System.Threading.Tasks;
using DDDCQRS.Microservice.Domain.SeedWork;

namespace DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task<Product> GetAsync(int productId);
        Task<List<Product>> GetByCategoryAsync(int categoryId);
        Task DeleteAsync(int productId);
        Task DeleteAsync(Product product);
        Task UpdateAsync(int productId, int categoryId);
    }
}