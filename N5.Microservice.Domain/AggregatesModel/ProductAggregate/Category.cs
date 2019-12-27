using DDDCQRS.Microservice.Domain.SeedWork;

namespace DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate
{
    public class Category : Entity
    {
        private string _name;

        private string _description;

        protected Category() { }

        public Category(string categoryName, string categoryDescription)
        {
            SetCategoryName(categoryName);
            SetCategoryDescription(categoryDescription);
        }

        public string GetCategoryName() => _name;

        public string GetCategoryDescription() => _description;

        public void SetCategoryName(string value)
        {
            _name = value;
        }

        public void SetCategoryDescription(string value)
        {
            _description = value;
        }

    }
}
