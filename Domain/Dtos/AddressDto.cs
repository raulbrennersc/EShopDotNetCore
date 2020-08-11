using Domain.Entities;

namespace Domain.Dtos
{
    public class AddressDto
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public AddressDto(Address address)
        {
            Name = address.Name;
            Street = address.Street;
            City = address.City;
            Number = address.Number;
            ZipCode = address.ZipCode;
            State = address.State;
            Country = address.Country;
        }
    }
}