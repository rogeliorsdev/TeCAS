using System;
using System.Collections.Generic;
using System.Linq;
using TeCAS.SCA.DAL;
using TeCAS.SCA.Entities;
using TeCAS.SCA.Services.Operations;

namespace TeCAS.SCA.BLL.Implementations
{
    public class AccountOperations : IAccountOperations
    {
        public Account Create(Account account)
        {
            Account Result = null;
            using (var Repository = RepositoryFactory.GetRepository())
            {
                var tmp = Repository.Retrieve<Account>(p => p.NoAccount.ToUpper() == account.NoAccount.ToUpper());
                if (tmp == null)
                {
                    account.CreateAt = DateTime.UtcNow;
                    account.Customer = null;
                    Result = Repository.Create(account);
                }
                else
                {
                    throw new Exception("Ya existe en el sistema una cuenta con el número proporcionado");
                }
            }

            return Result;
        }

        public List<Account> GetAll()
        {
            List<Account> Result = null;
            using (var Repository = RepositoryFactory.GetRepository())
            {
                Result = Repository.GetAll<Account>()
                                   .OrderBy(p => p.CreateAt)
                                   .ToList();
            }

            return Result;
        }

        public List<Account> GetAll(Guid customerId)
        {
            List<Account> Result = null;
            using (var Repository = RepositoryFactory.GetAccountRepository())
            {
                Result = Repository.GetAll(customerId);
            }

            return Result;
        }

        public List<Account> GetAllComplete()
        {
            List<Account> Result = null;
            using (var Repository = RepositoryFactory.GetAccountRepository())
            {
                Result = Repository.GetAllComplete().OrderBy(p => p.CreateAt).ToList();
            }

            return Result;
        }

        public Account RetrieveByCustomerId(Guid customerId)
        {
            Account Result = null;
            using (var Repository = RepositoryFactory.GetAccountRepository())
            {
                Result = Repository.RetrieveByCustomerId(customerId);
            }

            return Result;
        }

        public Account RetrieveById(Guid id)
        {
            Account Result = null;
            using (var Repository = RepositoryFactory.GetRepository())
            {
                Result = Repository.Retrieve<Account>(p => p.Id == id);
            }

            return Result;
        }

        public Account RetrieveByNoAccount(string noAccount)
        {
            Account Result = null;
            using (var Repository = RepositoryFactory.GetAccountRepository())
            {
                Result = Repository.RetrieveByNoAccount(noAccount);
            }

            return Result;
        }

        public bool Update(Account account)
        {
            bool Result = false;
            Account tmp = RetrieveById(account.Id);
            if (tmp != null)
            {
                using (var Repository = RepositoryFactory.GetRepository())
                {
                    tmp = Repository.Retrieve<Account>(p => p.NoAccount.ToUpper() ==
                                                    account.NoAccount.ToUpper() && p.Id != account.Id);
                    if (tmp == null)
                    {
                        account.Customer = null;
                        Result = Repository.Update(account);
                    }
                    else
                    {
                        throw new Exception("No existe en el sistema una cuenta con el número proporcionado");
                    }
                }
            }
            else
            {
                throw new Exception("La cuenta proporcionado no existe");
            }

            return Result;
        }
    }
}
