using MediatR;
using Microsoft.AspNetCore.Identity;
using ShopAPI.Models.Entities;
using ShopAPI.Models.ViewModels.Enums;
using ShopAPI.Models.ViewModels.Orders;
using ShopAPI.Repositories.Contexts;
using ShopAPI.Repositories.Interfaces;
using ShopAPI.Services.Factories;
using ShopAPI.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
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
        private readonly IRepository<Order> _orderRepository;
        private readonly ApplicationDbContext _dbContext;
        private readonly Func<PaymentType, IPaymentService> _paymentStrategy;

        public CreateOrderHandler(ApplicationDbContext dbContext
                                    , IRepository<Order> orderRepository
                                    , Func<PaymentType, IPaymentService> paymentStrategy)
        {
            _orderRepository = orderRepository;
            _dbContext = dbContext;
            _paymentStrategy = paymentStrategy;
        }

        public async Task<OrderResponseViewModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = CreateOrder(request.Order);

            var response = await _orderRepository.CreateAsync(order);

            var paymentService = _paymentStrategy(request.Order.PaymentRequest.PaymentType);

            await paymentService.ExecutePayment(response.Payment);

            _dbContext.SaveChanges();

            return OrderResponseViewModel.ToModelView(response);
        }

        public Order CreateOrder(OrderRequestViewModel orderMV)
        {
            var items = CreateOrderItems(orderMV.Items);

            var payment = GetPayment(orderMV.PaymentRequest);

            return Order.CreateOrder(orderMV.UserId
                                        , items
                                        , payment);
        }

        private Payment GetPayment(PaymentRequestViewModel paymentRequest)
        {
            return paymentRequest.PaymentType.GetPayment(paymentRequest);
        }

        private IList<OrderItem> CreateOrderItems(IList<OrderItemRequestViewModel> items)
        {
            return items.Select(o => new OrderItem(o)).ToList();
        }
    }
}
