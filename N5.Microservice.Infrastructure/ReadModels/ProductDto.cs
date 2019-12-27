using System.Collections.Generic;

namespace DDDCQRS.Microservice.Infrastructure.ReadModels
{
    public class Product : IResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
    }

    public class Category : IResponse
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }

    public class CustomCategory : Category, IResponse
    {
        public int CategoryProducts { get; set; }
    }
}
