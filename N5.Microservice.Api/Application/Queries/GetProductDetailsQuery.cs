using MediatR;
using DDDCQRS.Microservice.Api.Application.Model;

namespace DDDCQRS.Microservice.Api.Application.Queries
{
    /// <summary>
    /// We handle the query objects like the command and command handlers
    /// The Query DTO includes all the data needed to handle the request
    /// </summary>
    public class GetProductDetailsQuery : IRequest<IContract>
    {
        public int ProductId { get; }

        public GetProductDetailsQuery(int id)
        {
            ProductId = id;
        }
    }
}
