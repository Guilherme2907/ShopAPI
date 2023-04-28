using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models.ViewModels.Orders;
using ShopAPI.Models.ViewModels.Products;
using ShopAPI.Services.Orders.Commands.CreateOrder;
using ShopAPI.Services.Orders.Queries.GetOrders;
using ShopAPI.Services.Products.Commands.CreateProduct;
using ShopAPI.Services.Products.Queries.GetProductById;
using ShopAPI.Services.Products.Queries.GetProducts;
using System.Threading.Tasks;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            return Ok(await _mediator.Send(new GetOrdersQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByIdAsync(string id)
        {
            return Ok(await _mediator.Send(new GetOrderByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(OrderRequestViewModel order)
        {
            return Ok(await _mediator.Send(new CreateOrderCommand(order)));
        }
    }
}
