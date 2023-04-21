using MediatR;
using ShopAPI.Models.Entities;
using ShopAPI.Models.ViewModels.Register;
using ShopAPI.Repositories.Contexts;
using ShopAPI.Repositories.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace ShopAPI.Services.Registers.Commands.CreateRegister
{
    public record UpdateRegisterCommand(string UserId, RegisterRequestViewModel Register) : IRequest<RegisterRequestViewModel>;

    public class UpdateRegisterHandler : IRequestHandler<UpdateRegisterCommand, RegisterRequestViewModel>
    {
        private readonly IRepository<Register> _repository;
        private readonly ApplicationDbContext _context;

        public UpdateRegisterHandler(IRepository<Register> repository
                                    , ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<RegisterRequestViewModel> Handle(UpdateRegisterCommand request, CancellationToken cancellationToken)
        {
            var register = await _context.Registers
                                            .Include(r => r.Address)
                                            .Include(r => r.User)
                                            .FirstOrDefaultAsync(r => r.UserId == request.UserId);

            if (register is null)
            {
                return null;
            }

            register = register.ConvertTomodel(register, request.Register);

            await _repository.UpdateAsync(register);

            _context.SaveChanges();

            return request.Register;
        }
    }
}
