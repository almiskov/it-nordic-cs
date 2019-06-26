using L34_C02_working_with_ef_core_final.Data;
using L34_C02_working_with_ef_core_final.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace L34_C02_working_with_ef_core_final
{
    class Program
    {
        private static OnlineStoreContext _context = new OnlineStoreContext();

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //InsertCustomers();
            //InsertProducts();

            // SelectCustomers();

            //MoreSelectQueries();

            //UpdateCustomers();

            // UpdateProductsDisconnected();

            DeleteCustomers();
        }

        private static void DeleteCustomers()
        {
            //var customer = _context.Customers.First(c => c.Id == 4);
            var customer = new Customer() { Id = 8 };

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        private static void UpdateProductsDisconnected()
        {
            //var product = _context.Products.First();
            //product.Price *= 1.1M;

            var product = new Product()
            {
                Id = 1,
                Name = "Bread",
                Price = 50M - 50M * 0.1M
            };

            using (var newContext = new OnlineStoreContext())
            {
                newContext.Products.Update(product);
                newContext.SaveChanges();
            }
        }

        private static void UpdateCustomers()
        {
            var customer = _context.Customers.First();

            customer.Name = "Mr. " + customer.Name;

            _context.SaveChanges();
        }

        private static void MoreSelectQueries()
        {
            //var customers = _context.Customers.Where(c => c.Name.StartsWith("A")).ToList();
            //var customers = 
            //    _context
            //        .Customers
            //        .OrderBy(c => c.Id)
            //        .Last(c => c.Name.Length > 6);

            //var products =
            //    _context
            //        .Products
            //        .Where(p => p.Price > 1000)
            //        .ToList();

            var products =
                _context
                    .Products
                    .Where(p => EF.Functions.Like(p.Name, "%ee%"))
                    .ToList();


            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} ({p.Id}) {p.Price}");
            }
        }

        private static void SelectCustomers()
        {
            using (var context = new OnlineStoreContext())
            {
                //string name = "Anna";
                //var allCustomers = context
                //    .Customers
                //    .Where(c => c.Name == name)
                //    .ToList();

                var customers = context.Customers.ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine($"Customer {customer.Id} is {customer.Name}");
                }
            }
        }

        private static void InsertProducts()
        {
            var bread = new Product() { Name = "Fan", Price = 1500 };
            var liquid = new Product[]
                {
                    new Product { Name = "TV", Price = 30000 },
                    new Product { Name = "Oven", Price = 10000 }
                };

            using (var context = new OnlineStoreContext())
            {
                context.Products.Add(bread);

                context.AddRange(liquid);

                context.SaveChanges();
            }
        }

        private static void InsertCustomers()
        {
            var customer = new Customer() { Name = "Anna1" };
            var customerSet = new Customer[]
                {
                    new Customer { Name = "Ivan1" },
                    new Customer { Name = "Pavel1" }
                };

            using (var context = new OnlineStoreContext())
            {
                //context.Customers.Add(customer);
                context.Add(customer);
                context.AddRange(customerSet);

                context.SaveChanges();
            }
        }


    }
}
