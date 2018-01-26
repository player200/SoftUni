namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using CarDealer.Services.Models;
    using Data;
    using System.Linq;
    using System;
    using CarDealer.Data.Models;

    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public CustomerModel ById(int id)
        {
            return this.db
                .Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerModel
                {
                    Id=c.Id,
                    Name=c.Name,
                    BirthDate=c.BirthDate,
                    IsYoungDriver=c.IsYoungDriver
                })
                .FirstOrDefault();
        }

        public void Create(string name, DateTime birthDate,bool isYoungDriver)
        {
            var customer = new Customer
            {
                Name = name,
                BirthDate = birthDate,
                IsYoungDriver = isYoungDriver
            };
            this.db.Customers.Add(customer);
            this.db.SaveChanges();
        }

        public CustomerByIdModel CustomerInfo(int id)
        {
            var isYougDriv = this.db
                   .Customers
                   .Where(c => c.Id == id)
                   .Select(c => c.IsYoungDriver ? 0.05 : 0)
                   .FirstOrDefault();

            var discount = this.db
                   .Customers
                   .Where(c => c.Id == id)
                   .Select(c => c.Sales.Select(s=>s.Discount))
                   .FirstOrDefault()
                   .ToList();

            var dis = isYougDriv + discount.FirstOrDefault();

            return this.db
                   .Customers
                   .Where(c => c.Id == id)
                   .Select(c => new CustomerByIdModel
                   {
                       Name = c.Name,
                       Cars = c.Sales.Count,
                       Price = c.Sales.Select(s => s.Car.Parts.Sum(p => p.Part.Price)).Sum()-((c.Sales.Select(s => s.Car.Parts.Sum(p => p.Part.Price)).Sum())*(decimal)dis)
                   })
                   .FirstOrDefault();
        }

        public void Edit(int id, string name, DateTime bithDate, bool isYoungDrivert)
        {
            var customer = this.db.Customers.Find(id);

            if (customer==null)
            {
                return;
            }

            customer.Name = name;
            customer.BirthDate = bithDate;
            customer.IsYoungDriver = isYoungDrivert;
            this.db.SaveChanges();
        }

        public bool Exists(int id)
        {
            return this.db
                .Customers
                .Any(c => c.Id == id);
        }

        public IEnumerable<CustomerModel> OrderedCustomers(OrderedType order)
        {
            var customerQuery = this.db.Customers.AsQueryable();

            switch (order)
            {
                case OrderedType.Ascending:
                    customerQuery = customerQuery
                        .OrderBy(c => c.BirthDate)
                        .ThenBy(c => c.IsYoungDriver);
                    break;
                case OrderedType.Descending:
                    customerQuery = customerQuery
                        .OrderByDescending(c => c.BirthDate)
                        .ThenBy(c => c.IsYoungDriver);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid order: {order}.");
            }

            return customerQuery
                        .Select(c => new CustomerModel
                        {
                            Id=c.Id,
                            Name = c.Name,
                            BirthDate = c.BirthDate,
                            IsYoungDriver = c.IsYoungDriver
                        })
                        .ToList();
        }
    }
}