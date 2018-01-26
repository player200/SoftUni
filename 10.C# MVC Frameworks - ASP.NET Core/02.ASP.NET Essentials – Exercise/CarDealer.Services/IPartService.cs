namespace CarDealer.Services
{
    using CarDealer.Services.Models;
    using System.Collections.Generic;

    public interface IPartService
    {
        IEnumerable<PartsAllModel> AllParts();

        IEnumerable<PartsBasicModel> All();

        void Create(string name,decimal price,string supplierName);

        bool Exists(string supplierName);

        PartsAllModel ById(int id);

        void Edit(int id, string name, decimal price, int quantity);

        void Delete(int id);
    }
}