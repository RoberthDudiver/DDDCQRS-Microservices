using System.Threading.Tasks;
using Dapper;
using DDDCQRS.Microservice.Infrastructure.ConnectionFactory;
using DDDCQRS.Microservice.Infrastructure.ReadModels;
using System.Collections.Generic;
using System.Linq;
namespace DDDCQRS.Microservice.Infrastructure.Finder
{
    public class CategoryFinder : ICategoryFinder
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public CategoryFinder(ISqlConnectionFactory sqlConnectionFactory)
        {
            _connectionFactory = sqlConnectionFactory;
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            var connection = _connectionFactory.GetOpenConnection();
            const string sqlProduct = @"SELECT Id, Description, Name FROM  ProductCategory";
            var category = await connection.QueryFirstOrDefaultAsync<Category>(sqlProduct, new { id });
            return category;
        }
        public async Task<List<CustomCategory>> GetByCategorydAsync()
        {
            var connection = _connectionFactory.GetOpenConnection();
            const string sqlProduct = @"SELECT
                                    c.Id as CategoryId,
                                    c.Description as CategoryDescription,
                                    c.Name as CategoryName,
                                        (select count(*) from  Product AS p
                                    where p.ProductCategoryId=c.Id )  As CategoryProducts
                                    FROM     ProductCategory as  c";
            var categorys = await connection.QueryAsync<CustomCategory>(sqlProduct);
            return categorys.ToList();
        }
    }
}