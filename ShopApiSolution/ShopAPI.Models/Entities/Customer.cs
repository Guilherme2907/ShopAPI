namespace ShopAPI.Models.Entities
{
    public class Register : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string AddressId { get; set; }

        public Address Address { get; set; }
    }
}
