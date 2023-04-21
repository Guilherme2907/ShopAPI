namespace ShopAPI.Models.ViewModels.Register
{
    public class RegisterRequestViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public AddressViewModel Address { get; set; }
    }
}
