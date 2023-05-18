using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Models.Entities;
using ShopAPI.Models.ViewModels.Orders;
using ShopAPI.Repositories.Contexts;
using ShopAPI.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ShopAPI.Services.Orders.Queries.GetOrders
{
    public record GetOrderByIdQuery(string Id) : IRequest<OrderResponseViewModel>
    {
    }

    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderResponseViewModel>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetOrderByIdHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderResponseViewModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders
                                            .Include(o => o.User)
                                            .Include(o => o.Items)
                                            .ThenInclude(i => i.Product)
                                            .Include(o => o.Payment)
                                            .FirstOrDefaultAsync(o => o.Id == request.Id);

            var response = OrderResponseViewModel.ToModelView(order);

            return response;
        }
    }
}
