namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using CarDealer.Services.Models;
    using CarDealer.Data;
    using System.Linq;

    public class SaleService : ISaleService
    {
        private readonly CarDealerDbContext db;

        public SaleService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SalesModel> SalesAll()
        {
            return this.db
                 .Sales
                 .Select(s => new SalesModel
                 {
                     CarMake = s.Car.Make,
                     CarModel = s.Car.Model,
                     CarTravelledDistance = s.Car.TravelledDistance,
                     CustromerName = s.Customer.Name,
                     Discount = (s.Discount + (s.Customer.IsYoungDriver ? 0.05 : 0)) * 100,
                     Price = s.Car.Parts.Sum(c => c.Part.Price)
                 })
                 .ToList();
        }

        public CarsMakeModel SalesById(int id)
        {
            return this.db
                .Sales
                .Where(s => s.Id == id)
                .Select(s => new CarsMakeModel
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TravelledDistance
                })
                .FirstOrDefault();
        }

        public IEnumerable<SalesModel> SalesDiscounted()
        {
            return this.db
                 .Sales
                 .Where(s => s.Discount > 0 || s.Customer.IsYoungDriver == true)
                 .Select(s => new SalesModel
                 {
                     CarMake = s.Car.Make,
                     CarModel = s.Car.Model,
                     CarTravelledDistance = s.Car.TravelledDistance,
                     CustromerName = s.Customer.Name,
                     Discount = (s.Discount + (s.Customer.IsYoungDriver ? 0.05 : 0)) * 100,
                     Price = s.Car.Parts.Sum(c => c.Part.Price)
                 })
                 .ToList();
        }

        public IEnumerable<SalesModel> SalesDiscounted(double discount)
        {
            return this.db
                    .Sales
                    .Where(s => (s.Discount + (s.Customer.IsYoungDriver ? 0.05 : 0)) * 100 == discount)
                    .Select(s => new SalesModel
                    {
                        CarMake = s.Car.Make,
                        CarModel = s.Car.Model,
                        CarTravelledDistance = s.Car.TravelledDistance,
                        CustromerName = s.Customer.Name,
                        Discount = (s.Discount + (s.Customer.IsYoungDriver ? 0.05 : 0)) * 100,
                        Price = s.Car.Parts.Sum(c => c.Part.Price)
                    })
                    .ToList();
        }
    }
}