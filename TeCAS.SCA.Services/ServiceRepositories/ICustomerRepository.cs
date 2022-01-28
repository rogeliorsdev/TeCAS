using System;
using System.Collections.Generic;
using TeCAS.SCA.Entities;

namespace TeCAS.SCA.Services.ServiceRepositories
{
    public interface ICustomerRepository : IDisposable
    {
        List<Customer> GetAllComplete();
    }
}
