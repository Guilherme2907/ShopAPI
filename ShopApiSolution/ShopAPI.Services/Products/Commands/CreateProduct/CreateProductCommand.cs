using MediatR;
using ShopAPI.Models.Entities;
using ShopAPI.Models.ViewModels.Products;
using ShopAPI.Repositories.Contexts;
using ShopAPI.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ShopAPI.Services.Products.Commands.CreateProduct
{
    public record CreateProductCommand(ProductRequestViewModel Product) : IRequest<ProductResponseViewModel>
    {
    }

    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponseViewModel>
    {
        private readonly IRepository<Product> _repository;
        private readonly ApplicationDbContext _dbContext;

        public CreateProductHandler(IRepository<Product> repository, ApplicationDbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task<ProductResponseViewModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Product.Name,
                Price = request.Product.Price
            };

            await _repository.CreateAsync(product);
            _dbContext.SaveChanges();

            var response = new ProductResponseViewModel(product);

            return response;
        }
    }
}
