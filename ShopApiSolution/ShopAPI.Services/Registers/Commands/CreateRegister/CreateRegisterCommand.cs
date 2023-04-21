using MediatR;
using ShopAPI.Models.Entities;
using ShopAPI.Models.ViewModels.Register;
using ShopAPI.Repositories.Contexts;
using ShopAPI.Repositories.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ShopAPI.Services.Registers.Commands.CreateRegister
{
    public record CreateRegisterCommand(string UserId, RegisterRequestViewModel Register) : IRequest<RegisterRequestViewModel>;

    public class CreateRegisterHandler : IRequestHandler<CreateRegisterCommand, RegisterRequestViewModel>
    {
        private readonly IRepository<Register> _repository;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public CreateRegisterHandler(IRepository<Register> repository
                                    , ApplicationDbContext context
                                    , UserManager<User> userManager)
        {
            _repository = repository;
            _context = context;
            _userManager = userManager;
        }

        public async Task<RegisterRequestViewModel> Handle(CreateRegisterCommand request, CancellationToken cancellationToken)
        {
            var register = request.Register;
            var userId = request.UserId;

            if (!await IsValidRegister(userId))
            {
                return null;
            }

            var entityRegister = new Register
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Age = register.Age,
                UserId = userId,
                Address = new Address
                {
                    City = register.Address.City,
                    State = register.Address.State,
                    CEP = register.Address.CEP,
                    Block = register.Address.Block,
                    Street = register.Address.Street
                }
            };

            await _repository.CreateAsync(entityRegister);

            _context.SaveChanges();

            return register;
        }

        private async Task<bool> IsValidRegister(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var savedRegister = user is null ? null : await _context.Registers.FirstOrDefaultAsync(r => r.UserId == userId);

            return user is not null && savedRegister is null;
        }
    }
}
