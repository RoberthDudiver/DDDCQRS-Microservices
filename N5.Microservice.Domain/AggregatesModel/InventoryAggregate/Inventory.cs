using DDDCQRS.Microservice.Domain.SeedWork;
using System;

namespace DDDCQRS.Microservice.Domain.AggregatesModel.InventoryAggregate
{
    public class Inventory : Entity, IAggregateRoot
    {
        private int _categoryId;
        private int _stock;
        private DateTime _date;

        protected Inventory()
        {
        }

        public Inventory(int productCategoryId, int stock)
        {
            SetStock(stock);
            SetDate(DateTime.Now);
            SetCategoryId(productCategoryId);
        }

        public int GetCategoryId() => _categoryId;

        public void SetCategoryId(int value)
        {
            _categoryId = value;
        }

        public int GetStock() => _stock;

        public void SetStock(int value)
        {
            _stock = value;
        }

        public DateTime Date => _date;

        private void SetDate(DateTime value)
        {
            _date = value;
        }
    }
}
