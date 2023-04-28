using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Models.Entities;
using ShopAPI.Models.ViewModels.Orders;
using ShopAPI.Repositories.Contexts;
using ShopAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopAPI.Services.Orders.Queries.GetOrders
{
    public record GetOrdersQuery : IRequest<IEnumerable<OrderResponseViewModel>>
    {
    }

    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IEnumerable<OrderResponseViewModel>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetOrdersHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OrderResponseViewModel>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _dbContext.Orders
                                            .Include(o => o.User)
                                            .Include(o => o.Items)
                                            .ThenInclude(i => i.Product)
                                            .ToListAsync();

            var response = orders.Select(o => new OrderResponseViewModel(o));

            return response;
        }
    }
}
