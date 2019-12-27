using MediatR;
using DDDCQRS.Microservice.Api.Application.Model;
using DDDCQRS.Microservice.Api.ViewModels;
using DDDCQRS.Microservice.Infrastructure.Finder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using N5.MicroService.Utils;

namespace DDDCQRS.Microservice.Api.Application.Queries
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, IContract>
    {
        private readonly ICategoryFinder _CategoryFinder;

        public GetCategoryQueryHandler(ICategoryFinder categoryFinder)
        {
            _CategoryFinder = categoryFinder;
        }

        public async Task<IContract> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var product = await _CategoryFinder.GetByCategorydAsync();

            var lst= product.ToConvertObjects<List<CategoryViewModel>>();
            return new CategoriesViewModel() { Categories = lst };
        }
    }
}
