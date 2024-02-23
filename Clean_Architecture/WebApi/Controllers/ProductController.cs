using Application.Feature.Product.Qurries;
using Application.Feature.Product.Commands;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var result = await mediator.Send(new GetAllProductByQuery ());
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductId(int id)//parameter id of type int, which represents the identifier of the product to retrieve.
        {
            var result = await mediator.Send(new GetProductByIdQuery {Id=id });// it sets the Id property of the query object to the value of the id parameter passed to the GetProductId method. This is how the endpoint retrieves the ID of the product to be fetched.
            return Ok(result);
        }


        [HttpPost("CreateProduct")]

        public async Task<IActionResult> CreateProduct(CreateProductCommand createProduct, CancellationToken cancellationToken)
        {
             var result = await mediator.Send(createProduct, cancellationToken);
            return Ok(result);
        }


        [HttpPut("UpdateProduct")]

        public async Task<IActionResult> UpdateProduct(UpdateProductCommand UpdateProduct, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(UpdateProduct, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("DeleteProduct/{id}")]

        public async Task<IActionResult> DeleteProduct(int id , CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new DeleteProductCommand { Id=id}, cancellationToken);
            return Ok(result);
        }

    } 
}
