using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TinyCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            var tinyCrmDbContext = new TinyCrmDbContext();

            // Insert!
            var customer = new Customer()
            {
                Firstname = "Jogn",
                Lastname = "snow",
                Email = "snras.gr"
            };

            tinyCrmDbContext.Add(customer);

            var mpampis = new Customer()
            {
               
                Firstname = "George",
                Lastname = "Panagiotakopoulos",
                Email = "mpampis.gr"
            };

            tinyCrmDbContext.Add(mpampis);
            tinyCrmDbContext.SaveChanges();

            // Get data
            var customer2 = tinyCrmDbContext
                .Set<Customer>()
                .Where(c => c.CustomerId == customer.CustomerId)
                .SingleOrDefault();



            var CustomerOptions = new CustomerOptions()
            {
                FirstName = "George",
                LastName = "Panagiotakopoulos",
                VatNumber = "123456789",
                CreatedFrom = DateTime.Parse("01-01-0001"),
                CreatedTo = DateTime.Parse("10-10-2020")
            };
            //tinyCrmDbContext.Add(CustomerOptions);
        }

            public static List<Customer> SearchCustomers(CustomerOptions customerOptions)
            {

                var tinyCrmDbContext = new TinyCrmDbContext(); //create tinycrm dbcontext
                var customer = tinyCrmDbContext
                    .Set<Customer>() //sto table customer
                    .Where(c => c.Firstname==customerOptions.FirstName
                                && c.Lastname==customerOptions.LastName 
                                && c.VatNumber==customerOptions.VatNumber
                                && c.CustomerId == customerOptions.CustomerId  
                                && c.Created >= customerOptions.CreatedFrom 
                                && c.Created <= customerOptions.CreatedTo )
                    .Take(500)
                    .ToList();

                return customer;
            }

            public static List<Product> SearchProducts(ProductOptions productOptions)
            {
                var tinyCrmDbContext = new TinyCrmDbContext();
                var product = tinyCrmDbContext
                    .Set<Product>()
                    .Where(p => p.ProductId == productOptions.ProductId 
                                && p.Price >= productOptions.PriceFrom 
                                && p.Price <= productOptions.PriceTo
                                && p.Categories==productOptions.Categories )
                    .Take(500)
                    .ToList();

                return product;
            }





            //// Update
            //customer2.VatNumber = "123456789";
            //tinyCrmDbContext.SaveChanges();

            //// Delete
            //tinyCrmDbContext.Remove(customer2);
            //tinyCrmDbContext.SaveChanges();

        
    }
}
