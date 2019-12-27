using MediatR;
using DDDCQRS.Microservice.Api.Application.Model;
using DDDCQRS.Microservice.Api.ViewModels;
using DDDCQRS.Microservice.Infrastructure.Finder;
using N5.MicroService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DDDCQRS.Microservice.Api.Application.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IContract>
    {
        private readonly IProductFinder _productFinder;

        public GetProductsQueryHandler(IProductFinder productFinder)
        {
            _productFinder = productFinder;
        }

        public async Task<IContract> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var product = await _productFinder.FindByIdAsync(request.ProductId);

            return product.ToConvertObjects<ProductViewModel>();
        }
    }
}
