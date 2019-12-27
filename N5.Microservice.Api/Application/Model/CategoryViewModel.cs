using DDDCQRS.Microservice.Api.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDCQRS.Microservice.Api.ViewModels
{
    public class CategoryViewModel : IContract
    {
        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryName { get; set; }
        public int CategoryProducts { get; set; }


    }
}
