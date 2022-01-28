using System;
using System.Collections.Generic;
using TeCAS.SCA.Entities;

namespace TeCAS.SCA.Services.Operations
{
    public interface ITransactionOperations
    {
        Transaction DepositMoney(string noAccount, decimal amount);
        List<Transaction> GetAll();
        List<Transaction> GetAllComplete();
        Transaction HaveMoney(string noAccount, decimal amount);
        Transaction RetrieveById(Guid id);
        Transaction RetrieveLastTransaction(Guid accountId);
    }
}
