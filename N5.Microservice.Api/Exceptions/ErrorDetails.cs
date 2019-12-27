using Newtonsoft.Json;

namespace DDDCQRS.Microservice.Api.Exceptions
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public string Detail { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}