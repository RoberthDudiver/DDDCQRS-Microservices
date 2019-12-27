using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate;
using DDDCQRS.Microservice.Domain.SeedWork;

namespace DDDCQRS.Microservice.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsContext _context;

        public ProductRepository(ProductsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Product> AddAsync(Product product)
        {
            return await Task.FromResult(_context.Products.Add(product).Entity);
        }


        public async Task DeleteAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            _context.Remove(product);
        }

        public async Task DeleteAsync(Product product)
        {
            await Task.Run(() => _context.Remove(product));
        }

        public async Task<Product> GetAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            return product;
        }

        public async Task UpdateAsync(Product product)
        {
             await Task.FromResult(_context.Products.Update(product).Entity);
        }

        public async Task UpdateAsync(int productId, int categoryId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.SetCategory(categoryId);
            await Task.FromResult(_context.Products.Update(product).Entity);
        }

        public async Task<List<Product>> GetByCategoryAsync(int categoryId)
        {
            var products = await Task.FromResult(_context.Products.
            AsEnumerable().
            Where(p => Equals(p.GetCategory(), categoryId))
            .ToList());

            return products;
        }
    }
}