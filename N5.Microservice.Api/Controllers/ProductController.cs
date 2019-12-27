using MediatR;
using Microsoft.AspNetCore.Mvc;
using DDDCQRS.Microservice.Api.Application.Commands;
using DDDCQRS.Microservice.Api.Application.Model;
using DDDCQRS.Microservice.Api.Application.Queries;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DDDCQRS.Microservice.Api.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [Route("{id:int}")]
        [HttpGet()]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductsAsync(int id)
        {
            try
            {
                var product = await _mediator.Send(new GetProductsQuery(id));
                return Ok(product);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("{id:int}")]
        [HttpDelete()]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductsAsync(int id)
        {
            try
            {
                var product = await _mediator.Send(new DeleteProductCommand(id));
                return Ok(product);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("{id:int}")]
        [HttpPost()]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SetProductsAsync(CreateProductCommand command)
        {
            try
            {
                var product = await _mediator.Send(command);
                return Ok(product);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("UpdateCategory")]
        [HttpPost()]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProductsCategoryAsync(UpdateProductCommand command)
        {
            try
            {
                var product = await _mediator.Send(command);
                return Ok(product);
            }
            catch(Exception e)
            {
                return NotFound();
            }
        }
    }
}