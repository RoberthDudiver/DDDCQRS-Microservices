using MediatR;
using DDDCQRS.Microservice.Api.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDCQRS.Microservice.Api.Application.Queries
{
    public class GetCategoryQuery : IRequest<IContract>
    {   
        public GetCategoryQuery()
        {
           
        }
    }
}
