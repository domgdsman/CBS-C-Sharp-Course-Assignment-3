using System;
using System.Collections.Generic;

namespace school_app
{
    public abstract class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public readonly List<Address> Addresses = new List<Address>();

        // constructor not used
        public Person(string id, string name, DateTime birthdate, Address address)
        {
            Id = id;
            Name = name;
            Birthdate = birthdate;
            Addresses.Add(address);
        }

        public Person() { }

        public void AddAddress(Address address)
        {
            Addresses.Add(address);
        }

        private void PrintAddresses()
        {
            foreach (Address address in Addresses)
            {
                Console.WriteLine($"Street: {address.StreetNumber}");
                Console.WriteLine($"Zip Code: {address.ZipCode}");
                Console.WriteLine($"City: {address.City}");
                Console.WriteLine($"Country: {address.Country}");
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Birthdate: {Birthdate.ToShortDateString()}");
            Console.WriteLine("Adresses:");
            PrintAddresses();
            PrintAdditionalInfo();
        }

        protected virtual void PrintAdditionalInfo()
        {
            // classes override method
        }
    }
}
