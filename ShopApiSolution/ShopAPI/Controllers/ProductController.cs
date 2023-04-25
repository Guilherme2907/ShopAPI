using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models.ViewModels.Products;
using ShopAPI.Services.Products.Commands.CreateProduct;
using ShopAPI.Services.Products.Queries.GetProductById;
using ShopAPI.Services.Products.Queries.GetProducts;
using System.Threading.Tasks;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            return Ok(await _mediator.Send(new GetProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(string id)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(ProductRequestViewModel product)
        {
            return Ok(await _mediator.Send(new CreateProductCommand(product)));
        }
    }
}
