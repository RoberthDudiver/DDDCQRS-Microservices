using DDDCQRS.Microservice.Infrastructure.ReadModels;
using System.Collections.Generic;

namespace DDDCQRS.Microservice.Api.Application.Model
{
    /// <summary>
    /// Viewmodel Specifically made for the clients, based on the data returned by the queries.
    /// </summary>
    public class ProductDetailsViewModel : IContract
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
    }
}
