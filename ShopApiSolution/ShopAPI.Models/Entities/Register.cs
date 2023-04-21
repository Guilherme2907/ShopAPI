using ShopAPI.Models.ViewModels.Register;

namespace ShopAPI.Models.Entities
{
    public class Register : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string UserId { get; set; }

        public string AddressId { get; set; }

        public User User { get; set; }

        public Address Address { get; set; }

        public Register ConvertTomodel(Register register, RegisterRequestViewModel model) {

            register.FirstName = model.FirstName;
            register.LastName = model.LastName;
            register.Age = model.Age;
            register.Address.City = model.Address.City;
            register.Address.State = model.Address.State;
            register.Address.CEP = model.Address.CEP;
            register.Address.Street = model.Address.Street;
            register.Address.Block = model.Address.Block;

            return register;
        }
    }
}
