using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TeCAS.SCA.Entities;
using TeCAS.SCA.Services.ServiceRepositories;

namespace TeCAS.SCA.DAL.Implementations
{
    public class CustomerRepository : Repository, ICustomerRepository, IDisposable
    {
        DbContext Context;

        public CustomerRepository(DataBaseDbContext context)
            : base(context)
        {
            Context = context;
        }

        public List<Customer> GetAllComplete()
        {
            List<Customer> Result = null;
            Result = Context.Set<Customer>()
                .Include(p => p.Accounts)
                .ThenInclude(p => p.Transactions)
                .OrderByDescending(p => p.CreateAt)
                .ToList();

            return Result;
        }
    }
}
