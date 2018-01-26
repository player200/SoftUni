namespace CarDealer.Services
{
    using CarDealer.Services.Models;
    using System.Collections.Generic;

    public interface ISuppliersService
    {
        IEnumerable<SuppliersModel> Local();

        IEnumerable<SuppliersModel> Importers();
    }
}