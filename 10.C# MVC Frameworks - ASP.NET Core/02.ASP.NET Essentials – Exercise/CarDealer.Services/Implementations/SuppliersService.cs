namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using CarDealer.Services.Models;
    using CarDealer.Data;
    using System.Linq;

    public class SuppliersService : ISuppliersService
    {
        private readonly CarDealerDbContext db;

        public SuppliersService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SuppliersModel> Importers()
        {
            return this.db
                .Suppliers
                .Where(s => s.IsImporter == true)
                .Select(s => new SuppliersModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Parts = s.Parts.Count
                })
                .ToList();
        }

        public IEnumerable<SuppliersModel> Local()
        {
            return this.db
                 .Suppliers
                 .Where(s => s.IsImporter == false)
                 .Select(s => new SuppliersModel
                 {
                     Id = s.Id,
                     Name = s.Name,
                     Parts = s.Parts.Count
                 })
                 .ToList();
        }
    }
}