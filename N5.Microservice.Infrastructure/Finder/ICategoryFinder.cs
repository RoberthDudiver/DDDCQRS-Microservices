using DDDCQRS.Microservice.Infrastructure.ReadModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDDCQRS.Microservice.Infrastructure.Finder
{
    public interface ICategoryFinder : IFinder<Category>
    {
        Task<List<CustomCategory>> GetByCategorydAsync();

    }
}