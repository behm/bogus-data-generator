using Bogus;
using BogusDataDemo.Models;
using System;
using System.Collections.Generic;

namespace BogusDataDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's Generate Some Bogus Data!");

            var fakeData = GenerateFakeData();
            foreach (var item in fakeData)
            {
                Console.WriteLine($"ID: {item.CustomerId}");
                Console.WriteLine(item.CompanyName);
                Console.WriteLine(item.Address.StreetAddress);
                if (item.Address.AddressLine2 != null)
                {
                    Console.WriteLine(item.Address.AddressLine2);
                }
                Console.WriteLine($"{item.Address.City}, {item.Address.State}, {item.Address.PostalCode}");
                Console.WriteLine($"   {item.Contact.FullName}");
                Console.WriteLine($"   {item.Contact.Email}");
                Console.WriteLine($"   {item.Contact.Phone}");
                Console.WriteLine();
            }

            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }

        static IEnumerable<Customer> GenerateFakeData()
        {
            int id = 0;
            Randomizer.Seed = new Random(1234);
            var locale = "en_US";

            var addressFaker = new Faker<Address>(locale)
                .RuleFor(a => a.StreetAddress, f => f.Address.StreetAddress())
                .RuleFor(a => a.AddressLine2, f => f.Random.Number(1, 50) > 25 ? f.Address.SecondaryAddress() : null)
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.State, f => f.Address.StateAbbr())
                .RuleFor(a => a.PostalCode, f => f.Address.ZipCode("#####"));

            var contactFaker = new Faker<Contact>(locale)
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber());

            var customerFaker = new Faker<Customer>(locale)
                .RuleFor(t => t.CustomerId, f => ++id)
                .RuleFor(t => t.CompanyName, f => f.Company.CompanyName())
                .RuleFor(t => t.Contact, f => contactFaker)
                .RuleFor(t => t.Address, f => addressFaker);

            return customerFaker.Generate(50);
        }
    }
}
