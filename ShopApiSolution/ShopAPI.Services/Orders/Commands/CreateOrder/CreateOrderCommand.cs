using MediatR;
using Microsoft.AspNetCore.Identity;
using ShopAPI.Models.Entities;
using ShopAPI.Models.ViewModels.Orders;
using ShopAPI.Repositories.Contexts;
using ShopAPI.Repositories.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopAPI.Services.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand(OrderRequestViewModel Order) : IRequest<OrderResponseViewModel>
    {
    }

    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderResponseViewModel>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;


        public CreateOrderHandler(IRepository<Product> productRepository
                                    , ApplicationDbContext dbContext
                                    , UserManager<User> userManager
                                    , IRepository<Order> orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<OrderResponseViewModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = new Order
            {
                UserId = request.Order.UserId,
            };

            orderEntity.Items = request.Order.Items.Select(o => new OrderItem(o, orderEntity.Id)).ToList();

            var response = await _orderRepository.CreateAsync(orderEntity);

            _dbContext.SaveChanges();

            return new OrderResponseViewModel(response);
        }
    }
}
