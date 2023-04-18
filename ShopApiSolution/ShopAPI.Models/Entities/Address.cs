using System;

namespace ShopAPI.Models.Entities
{
    public class Address : Entity
    {
        public string Street { get; set; }

        public string Block { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string CEP { get; set; }

        public string RegisterId { get; set; }

        public Register Register { get; set; }
    }
}
