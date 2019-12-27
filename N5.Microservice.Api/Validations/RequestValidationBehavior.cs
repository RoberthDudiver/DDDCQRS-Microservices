using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using DDDCQRS.Microservice.Api.Exceptions;

namespace DDDCQRS.Microservice.Api.Validations
{
    public class RequestValidationBehavior<TRequest, TResponse> : 
        IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }


        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var errors = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (errors.Any())
            {
                var errorBuilder = new StringBuilder();
                errorBuilder.AppendLine("Invalid Request, reasons: ");
                foreach (var error in errors)
                {
                    errorBuilder.AppendLine(error.ErrorMessage);
                }
                // Throw exception with all errors
                throw new InvalidRequestException(errorBuilder.ToString(), null);
            }

            return next();
        }
    }
}