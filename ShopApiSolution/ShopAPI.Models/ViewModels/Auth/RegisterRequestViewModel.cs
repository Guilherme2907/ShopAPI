namespace ShopAPI.Models.ViewModels.Auth
{
    public class RegisterRequestViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
    }
}
