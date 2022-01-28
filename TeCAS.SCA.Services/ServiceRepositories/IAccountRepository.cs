using System;
using System.Collections.Generic;
using TeCAS.SCA.Entities;

namespace TeCAS.SCA.Services.ServiceRepositories
{
    public interface IAccountRepository : IDisposable
    {
        List<Account> GetAllComplete();
        List<Account> GetAll(Guid customerId);
        Account RetrieveByNoAccount(string noAccount);
        Account RetrieveByCustomerId(Guid customerId);
    }
}
