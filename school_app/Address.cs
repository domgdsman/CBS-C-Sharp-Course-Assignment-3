namespace school_app
{
    public class Address
    {
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Address(string streetNumber, string zipCode, string city, string country)
        {
            StreetNumber = streetNumber;
            ZipCode = zipCode;
            City = city;
            Country = country;
        }
    }
}
