namespace CarDealer.Services
{
    using CarDealer.Services.Models;
    using System;
    using System.Collections.Generic;

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> OrderedCustomers(OrderedType order);

        CustomerByIdModel CustomerInfo(int id);

        void Create(string name,DateTime birthDate, bool isYoungDriver);

        CustomerModel ById(int id);

        void Edit(int id, string name, DateTime bithDate, bool isYoungDrivert);

        bool Exists(int id);
    }
}