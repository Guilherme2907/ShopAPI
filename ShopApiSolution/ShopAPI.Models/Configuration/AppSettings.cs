namespace ShopAPI.Models.Configuration
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string ValidIn { get; set; }
        public string Issuer { get; set; }
        public double ExpiresIn { get; set; }
    }
}
