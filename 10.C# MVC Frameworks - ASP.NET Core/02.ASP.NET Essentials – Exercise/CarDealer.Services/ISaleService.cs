namespace CarDealer.Services
{
    using CarDealer.Services.Models;
    using System.Collections.Generic;

    public interface ISaleService
    {
        IEnumerable<SalesModel> SalesAll();

        CarsMakeModel SalesById(int id);

        IEnumerable<SalesModel> SalesDiscounted();

        IEnumerable<SalesModel> SalesDiscounted(double discount);
    }
}