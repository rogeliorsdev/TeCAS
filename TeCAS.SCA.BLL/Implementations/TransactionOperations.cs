using System;
using System.Collections.Generic;
using System.Linq;
using TeCAS.SCA.DAL;
using TeCAS.SCA.Entities;
using TeCAS.SCA.Services.Operations;
using static TeCAS.SCA.Entities.Enumerations.EnumerationLists;

namespace TeCAS.SCA.BLL.Implementations
{
    public class TransactionOperations : ITransactionOperations
    {
        public Transaction DepositMoney(string noAccount, decimal amount)
        {
            Transaction Result = null;
            var HelperAccount = OperationsFactory.GetAccountOperations();
            var account = HelperAccount.RetrieveByNoAccount(noAccount);
            if(amount > 0)
            {
                if (account != null)
                {
                    var HelperTransaction = OperationsFactory.GetTransactionOperations();

                    var tmp = HelperTransaction.RetrieveLastTransaction(account.Id);
                    decimal saldo = 0;

                    Transaction newTransaction = new Transaction();
                    using (var Repository = RepositoryFactory.GetRepository())
                    {
                        if (tmp != null)
                        {
                            saldo = tmp.CurrentBalance;
                        }
                        newTransaction.CreateAt = DateTime.Now;
                        newTransaction.AccountId = account.Id;
                        newTransaction.TypeTransaction = TypeTransaction.DEPOSITO;
                        newTransaction.MovementAmount = amount;

                        decimal amountCurrent = saldo + amount;
                        newTransaction.CurrentBalance = amountCurrent;
                        Result = Repository.Create(newTransaction);
                    }
                }
                else
                {
                    throw new Exception("No existe en el sistema una cuenta con el número proporcionado");
                }
            }
            else
            {
                throw new Exception("La cantidad de dinero a depositar debe de ser mayor a cero");
            }

            return Result;
        }

        public List<Transaction> GetAll()
        {
            List<Transaction> Result = null;
            using (var Repository = RepositoryFactory.GetRepository())
            {
                Result = Repository.GetAll<Transaction>()
                                   .OrderBy(p => p.CreateAt)
                                   .ToList();
            }

            return Result;
        }

        public List<Transaction> GetAllComplete()
        {
            List<Transaction> Result = null;
            using (var Repository = RepositoryFactory.GetTransactionRepository())
            {
                Result = Repository.GetAllComplete();
            }

            return Result;
        }

        public Transaction HaveMoney(string noAccount, decimal amount)
        {
            Transaction Result = null;
            var HelperAccount = OperationsFactory.GetAccountOperations();
            var account = HelperAccount.RetrieveByNoAccount(noAccount);
            if(account != null)
            {
                var HelperTransaction = OperationsFactory.GetTransactionOperations();

                var tmp = HelperTransaction.RetrieveLastTransaction(account.Id);
                decimal saldo = 0;

                Transaction newTransaction = new Transaction();
                using (var Repository = RepositoryFactory.GetRepository())
                {
                    if(tmp != null)
                    {
                        saldo = tmp.CurrentBalance;
                    }
                    newTransaction.AccountId = account.Id;
                    newTransaction.CreateAt = DateTime.Now;
                    newTransaction.TypeTransaction = TypeTransaction.RETIRO;
                    newTransaction.MovementAmount = amount;

                    decimal amountCurrent = saldo - amount;
                    if (amountCurrent >= 0 && amount > 0)
                    {
                        newTransaction.CurrentBalance = amountCurrent;
                        Result = Repository.Create(newTransaction);
                    }
                    else
                    {
                        throw new Exception("No hay suficiente saldo para hacer un retiro de dinero");
                    }
                }
            }
            else
            {
                throw new Exception("No existe en el sistema una cuenta con el número proporcionado");
            }
            
            return Result;
        }

        public Transaction RetrieveById(Guid id)
        {
            Transaction Result = null;
            using (var Repository = RepositoryFactory.GetRepository())
            {
                Result = Repository.Retrieve<Transaction>(p => p.Id == id);
            }

            return Result;
        }

        public Transaction RetrieveLastTransaction(Guid accountId)
        {
            Transaction Result = null;
            using (var Repository = RepositoryFactory.GetTransactionRepository())
            {
                Result = Repository.RetrieveLastTransaction(accountId);
            }

            return Result;
        }
    }
}
