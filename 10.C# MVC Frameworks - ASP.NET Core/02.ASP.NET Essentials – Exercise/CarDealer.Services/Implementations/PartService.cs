namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using CarDealer.Services.Models;
    using CarDealer.Data;
    using System.Linq;
    using CarDealer.Data.Models;

    public class PartService : IPartService
    {
        private readonly CarDealerDbContext db;

        public PartService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<PartsBasicModel> All()
        {
            return this.db
                .Parts
                .OrderBy(p => p.Id)
                .Select(p => new PartsBasicModel
                {
                    Id=p.Id,
                    Name=p.Name
                })
                .ToList();
        }

        public IEnumerable<PartsAllModel> AllParts()
        {
            return this.db
                .Parts
                .Select(p => new PartsAllModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierName = p.Supplier.Name
                })
                .ToList();
        }

        public PartsAllModel ById(int id)
        {
            return this.db
                .Parts
                .Where(p => p.Id == id)
                .Select(p=>new PartsAllModel
                {
                    Id=p.Id,
                    Name=p.Name,
                    Price=p.Price,
                    Quantity=p.Quantity,
                    SupplierName=p.Supplier.Name
                })
                .FirstOrDefault();
        }

        public void Create(string name, decimal price, string supplierName)
        {
            var part = new Part
            {
                Name = name,
                Price = price,
                Supplier = this.db
                            .Suppliers
                            .FirstOrDefault(s => s.Name == supplierName),
                Quantity=1
            };

            this.db.Add(part);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return;
            }

            this.db.Parts.Remove(part);
            this.db.SaveChanges();
        }

        public void Edit(int id, string name, decimal price, int quantity)
        {
            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return;
            }

            part.Name = name;
            part.Price = price;
            part.Quantity = quantity;
            this.db.SaveChanges();
        }

        public bool Exists(string supplierName)
        {
            return this.db
                 .Suppliers
                 .Any(s => s.Name == supplierName);
        }
    }
}