using System.Threading.Tasks;
using Dapper;
using DDDCQRS.Microservice.Infrastructure.ConnectionFactory;
using DDDCQRS.Microservice.Infrastructure.ReadModels;
using System.Collections.Generic;
using System.Linq;
namespace DDDCQRS.Microservice.Infrastructure.Finder
{
    public class ProductFinder : IProductFinder
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public ProductFinder(ISqlConnectionFactory sqlConnectionFactory)
        {
            _connectionFactory = sqlConnectionFactory;
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            var connection = _connectionFactory.GetOpenConnection();

            const string sqlProduct = @"SELECT
                                        	p.[Id] AS productid,
                                        	p.[Name] AS productname,
                                        	p.[Description] AS productdescription,
                                            p.[Price] AS productprice
                                        FROM
                                        	dbo.Product p
                                        WHERE
                                        	p.[Id] = @Id";

            var product = await connection.QueryFirstOrDefaultAsync<Product>(sqlProduct, new { id });

            return product;
        }
        public async Task<List<CustomCategory>> GetByCategorydAsync(int id)
        {
            var connection = _connectionFactory.GetOpenConnection();

            const string sqlProduct = @"SELECT
                                    c.Id,
                                    c.Description,
                                    c.Name ,
                                   (select count(*) from  Product AS p
                                    where p.ProductCategoryId=c.Id ) As Products
                                    FROM     ProductCategory as  c";

            var products = await connection.QueryAsync<CustomCategory>(sqlProduct, new { id });

            return products.ToList();
        }
    }
}