namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using CarDealer.Services.Models;
    using CarDealer.Data;
    using CarDealer.Data.Models;

    public class CarService : ICarService
    {
        private readonly CarDealerDbContext db;

        public CarService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CarsMakeModel> All()
        {
            return this.db
                  .Cars
                  .Select(c => new CarsMakeModel
                  {
                      Make = c.Make,
                      Model = c.Model,
                      TravelledDistance = c.TravelledDistance
                  })
                  .ToList();
        }

        public CarsAllModel CarsById(int id)
        {
            return this.db
                .Cars
                .Where(c => c.Id == id)
                .Select(c => new CarsAllModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.Parts
                    .Select(p => new PartsModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                })
                .FirstOrDefault();
        }

        public IEnumerable<CarsMakeModel> CarsMakeAll(string make)
        {
            return this.db
                .Cars
                .Where(c => c.Make.ToLower() == make.ToLower())
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new CarsMakeModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                });
        }

        public void Create(string make, string carModel, long travelledDistance, IEnumerable<int> parts)
        {
            var existingId = this.db
                            .Parts
                            .Where(p => parts.Contains(p.Id))
                            .Select(p => p.Id)
                            .ToList();

            var car = new Car
            {
                Make = make,
                Model = carModel,
                TravelledDistance = travelledDistance
            };

            foreach (var partId in existingId)
            {
                car.Parts.Add(new PartCar { Part_Id = partId });
            }

            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }
    }
}