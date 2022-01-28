using System;
using System.Collections.Generic;
using TeCAS.SCA.Entities;

namespace TeCAS.SCA.Services.Operations
{
    public interface IAccountOperations
    {
        Account Create(Account account);
        List<Account> GetAll();
        List<Account> GetAllComplete();
        List<Account> GetAll(Guid customerId);
        Account RetrieveById(Guid id);
        Account RetrieveByNoAccount(string noAccount);
        Account RetrieveByCustomerId(Guid customerId);
        bool Update(Account account);
    }
}
