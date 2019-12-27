using MediatR;
using Microsoft.AspNetCore.Mvc;
using DDDCQRS.Microservice.Api.Application.Commands;
using DDDCQRS.Microservice.Api.Application.Model;
using DDDCQRS.Microservice.Api.Application.Queries;
using System.Net;
using System.Threading.Tasks;

namespace DDDCQRS.Microservice.Api.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class  InventoryController: Controller
    {
        private readonly IMediator _mediator;
        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("categoryandproducts")]
        [HttpGet()]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductsByCategoryAsync(int id)
        {
            try
            {
                var product = await _mediator.Send(new GetCategoryQuery());
                return Ok(product);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}