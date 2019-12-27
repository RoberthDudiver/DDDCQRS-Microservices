using MediatR;

namespace DDDCQRS.Microservice.Api.Application.Commands
{
    /// <summary>
    /// A command has all the data needed to service a request
    /// </summary>
    public class DeleteProductCommand : IRequest<bool> {
    
  
        public int Id { get; set; }
   

        protected DeleteProductCommand() { }

        public DeleteProductCommand(int id)
        {           
            Id = id;
        }
    }
}