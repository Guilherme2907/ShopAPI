using MediatR;
using ShopAPI.Models.Entities;
using ShopAPI.Models.ViewModels.Products;
using ShopAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopAPI.Services.Products.Queries.GetProducts
{
    public record GetProductsQuery : IRequest<IEnumerable<ProductResponseViewModel>>
    {
    }

    public class GetProductstHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductResponseViewModel>>
    {
        private readonly IRepository<Product> _repository;

        public GetProductstHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductResponseViewModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();

            var response = products
                                .ToList()
                                .Select(p => new ProductResponseViewModel(p));

            return response;
        }
    }
}
