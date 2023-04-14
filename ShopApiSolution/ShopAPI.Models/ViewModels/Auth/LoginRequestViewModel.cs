namespace ShopAPI.Models.ViewModels.Auth
{
    public record LoginRequestViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
