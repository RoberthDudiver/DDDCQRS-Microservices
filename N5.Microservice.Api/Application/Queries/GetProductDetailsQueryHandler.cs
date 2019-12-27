using MediatR;
using DDDCQRS.Microservice.Api.Application.Model;
using DDDCQRS.Microservice.Infrastructure.Finder;
using System.Threading;
using System.Threading.Tasks;
using N5.MicroService.Utils;
namespace DDDCQRS.Microservice.Api.Application.Queries
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, IContract>
    {
        private readonly IProductFinder _productFinder;

        public GetProductDetailsQueryHandler(IProductFinder productFinder)
        {
            _productFinder = productFinder;
        }

        public async Task<IContract> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var product = await _productFinder.FindByIdAsync(request.ProductId);

            return product.ToConvertObjects<ProductDetailsViewModel>();
        }
    }
}
