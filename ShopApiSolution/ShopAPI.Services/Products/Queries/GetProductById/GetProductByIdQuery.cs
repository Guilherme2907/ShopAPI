using MediatR;
using ShopAPI.Models.Entities;
using ShopAPI.Models.ViewModels.Products;
using ShopAPI.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ShopAPI.Services.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(string Id) : IRequest<ProductResponseViewModel>;

    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponseViewModel>
    {
        private readonly IRepository<Product> _repository;

        public GetProductByIdHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<ProductResponseViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(request.Id);

            var response = new ProductResponseViewModel(product);

            return response;
        }
    }
}
