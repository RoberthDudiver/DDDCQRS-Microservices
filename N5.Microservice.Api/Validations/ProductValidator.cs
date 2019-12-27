using FluentValidation;
using DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate;

namespace DDDCQRS.Microservice.Api.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.GetPrice()).Must(x=> ValidateMinPrice(x)).WithMessage(TypeMessage(1));
            RuleFor(x => x.GetPrice()).Must(x=> ValidateHighPrice(x)).WithMessage(TypeMessage(2));
        }

        private bool ValidateMinPrice(int prince)
        {
            if(prince>500){
                return true;
            }
            else{
                return false;
            }
        }

        private bool ValidateHighPrice(int prince)
        {
            if(prince<10000){
                return true;
            }
            else{
                return false;
            }
        }

        private string TypeMessage(int options){
            if(options.Equals(1)){
                return "Precio por debajo del minimo";
            }
            else if(options.Equals(2)){
                return "Precio muy Alto";
            }
            else{
                return "Precio erroneo";
            }
        }
    }
}