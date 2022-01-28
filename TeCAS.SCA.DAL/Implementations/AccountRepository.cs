using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TeCAS.SCA.Entities;
using TeCAS.SCA.Services.ServiceRepositories;

namespace TeCAS.SCA.DAL.Implementations
{
    public class AccountRepository : Repository, IAccountRepository, IDisposable
    {
        DbContext Context;

        public AccountRepository(DataBaseDbContext context)
            : base(context)
        {
            Context = context;
        }

        public List<Account> GetAll(Guid customerId)
        {
            List<Account> Result = null;
            Result = Context.Set<Account>()
                .Where(p => p.CustomerId == customerId)
                .ToList();

            return Result;
        }

        public List<Account> GetAllComplete()
        {
            List<Account> Result = null;
            Result = Context.Set<Account>()
                .Include(p => p.Customer)
                .ToList();

            return Result;
        }

        public Account RetrieveByCustomerId(Guid customerId)
        {
            Account Result = null;
            Result = Context.Set<Account>()
                .Where(p => p.CustomerId == customerId)
                //.Include(p => p.Customer)
                .FirstOrDefault();

            return Result;
        }

        public Account RetrieveByNoAccount(string noAccount)
        {
            Account Result = null;
            Result = Context.Set<Account>()
                .Where(p => p.NoAccount == noAccount)
                .FirstOrDefault();

            return Result;
        }
    }
}
