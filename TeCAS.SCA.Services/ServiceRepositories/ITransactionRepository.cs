using System;
using System.Collections.Generic;
using TeCAS.SCA.Entities;

namespace TeCAS.SCA.Services.ServiceRepositories
{
    public interface ITransactionRepository : IDisposable
    {
        List<Transaction> GetAllComplete();
        Transaction RetrieveLastTransaction(Guid noAccount);
    }
}
