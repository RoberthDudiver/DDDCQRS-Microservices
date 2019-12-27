using MediatR;

namespace DDDCQRS.Microservice.Api.Application.Commands
{
    /// <summary>
    /// A command has all the data needed to service a request
    /// </summary>
    public class UpdateProductCommand
        : IRequest<bool>
    {
        public int ProductCategoryId { get; set; }
        public int ProductId { get; set; }

        protected UpdateProductCommand() { }

        public UpdateProductCommand(int productId,
            int productCategoryId)
        {

            ProductId = productId;
            ProductCategoryId = productCategoryId;
        }
    }
}