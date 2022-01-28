using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TeCAS.SCA.Entities;
using TeCAS.SCA.Services.ServiceRepositories;

namespace TeCAS.SCA.DAL.Implementations
{
    public class TransactionRepository : Repository, ITransactionRepository, IDisposable
    {
        DbContext Context;

        public TransactionRepository(DataBaseDbContext context)
            : base(context)
        {
            Context = context;
        }

        public List<Transaction> GetAllComplete()
        {
            List<Transaction> Result = null;
            Result = Context.Set<Transaction>()
                .Include(p => p.Account)
                .ThenInclude(p => p.Customer)
                .OrderByDescending(p => p.CreateAt)
                .ToList();

            return Result;
        }

        public Transaction RetrieveLastTransaction(Guid accountId)
        {
            Transaction Result = null;
            Result = Context.Set<Transaction>()
                .Where(p => p.AccountId == accountId)
                .OrderByDescending(p => p.CreateAt)
                .FirstOrDefault();

            return Result;

        }
    }
}
