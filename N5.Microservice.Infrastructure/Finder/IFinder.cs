using System.Threading.Tasks;
using DDDCQRS.Microservice.Infrastructure.ReadModels;

namespace DDDCQRS.Microservice.Infrastructure.Finder
{
    public interface IFinder<T> where T : IResponse
    {
         Task<T> FindByIdAsync(int id);
    }
}