using System;

namespace DDDCQRS.Microservice.Api.Exceptions
{
    public class InvalidRequestException : Exception
    {
        public string Details { get; }

        public InvalidRequestException(string message, string details) : base(message)
        {
            Details = details;
        }
    }
}