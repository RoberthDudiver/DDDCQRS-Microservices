using DDDCQRS.Microservice.Api.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDCQRS.Microservice.Api.ViewModels
{
    public class CategoriesViewModel : IContract
    {
        public List<CategoryViewModel> Categories { get; set; }


    }
}
