using System;
using System.Collections.Generic;
using TeCAS.SCA.Entities;

namespace TeCAS.SCA.Services.Operations
{
    public interface ICustomerOperations
    {
        Customer Create(Customer customer);
        bool Delete(Guid id);
        List<Customer> GetAll();
        List<Customer> GetAllComplete();
        Customer RetrieveById(Guid id);
        bool Update(Customer customer);
    }
}
