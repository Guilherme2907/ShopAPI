namespace ShopAPI.Models.Configuration
{
    public class AppSettings
    {
        public string Secret { get; set; }

        public string ValidIn { get; set; }

        public string Issuer { get; set; }

        public double HoursToEspireAccessToken { get; set; }

        public double HoursToEspireRefreshToken { get; set; }
    }
}
