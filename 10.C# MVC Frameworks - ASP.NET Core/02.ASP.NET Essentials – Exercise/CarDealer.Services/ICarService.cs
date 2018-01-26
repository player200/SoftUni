namespace CarDealer.Services
{
    using CarDealer.Services.Models;
    using System.Collections.Generic;

    public interface ICarService
    {
        IEnumerable<CarsMakeModel> CarsMakeAll(string make);

        CarsAllModel CarsById(int id);

        IEnumerable<CarsMakeModel> All();

        void Create(string make, string carModel, long travelledDistance,IEnumerable<int> parts);
    }
}