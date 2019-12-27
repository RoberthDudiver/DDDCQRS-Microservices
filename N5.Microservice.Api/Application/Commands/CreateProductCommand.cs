using MediatR;

namespace DDDCQRS.Microservice.Api.Application.Commands {

    public class CreateProductCommand
        : IRequest<int> {
            public int ProductCategoryId { get; set; }

            public string ProductDescription { get; set; }

            public string ProductName { get; set; }

            public int ProductPrice { get; set; }

            protected CreateProductCommand () { }

            public CreateProductCommand (string productName, string productDescription, int productPrice,
                int productCategoryId) {
                ProductName = productName;
                ProductDescription = productDescription;
                ProductPrice = productPrice;
                ProductCategoryId = productCategoryId;
            }
        }
}