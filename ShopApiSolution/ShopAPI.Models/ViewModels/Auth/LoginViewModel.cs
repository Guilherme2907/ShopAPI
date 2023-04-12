namespace ShopAPI.Models.ViewModels.Auth
{
    public record LoginViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
