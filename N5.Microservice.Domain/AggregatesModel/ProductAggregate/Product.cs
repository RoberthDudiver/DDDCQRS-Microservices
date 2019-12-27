using Ardalis.GuardClauses;
using DDDCQRS.Microservice.Domain.Events;
using DDDCQRS.Microservice.Domain.SeedWork;
using System.Collections.Generic;

namespace DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate
{
    public class Product : Entity, IAggregateRoot
    {

        private string _description;
        private string _name;
        private int _price;
        private int? _categoryId;

        protected Product()
        {
        }

        public Product(string name, string description, int price) : this()
        {
            SetName(name);
            SetDescription(description);
            SetPrice(price);
        }

        public string GetDescription() => _description;

        public string GetName() => _name;

        public int GetPrice() => _price;

        public int? GetCategory() => _categoryId;

        public void SetDescription(string description)
        {
            Guard.Against.NullOrWhiteSpace(description, nameof(description));
            _description = description;
        }

        public void SetName(string name)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            _name = name;
        }

        public void SetPrice(int price)
        {
            _price = price;
        }

        public void SetCategory(int categoryId)
        {
            Guard.Against.Null(categoryId, nameof(categoryId));
            _categoryId = categoryId;
        }

        public void AddCategoryId(int value)
        {
            Guard.Against.Null(value, nameof(value));
            _categoryId = value;
            AddDomainEvent(new UpdateInventoryWhenProductCreatedDomainEvent(value));
        }
    }
}
