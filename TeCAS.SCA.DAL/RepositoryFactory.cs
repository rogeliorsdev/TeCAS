using TeCAS.SCA.DAL.Implementations;
using TeCAS.SCA.Services.Repositories;
using TeCAS.SCA.Services.ServiceRepositories;

namespace TeCAS.SCA.DAL
{
    public class RepositoryFactory
    {
        public static IRepository GetRepository()
        {
            return new Repository(new DataBaseDbContext());
        }

        public static IAccountRepository GetAccountRepository()
        {
            return new AccountRepository(new DataBaseDbContext());
        }

        public static ICustomerRepository GetCustomerRepository()
        {
            return new CustomerRepository(new DataBaseDbContext());
        }

        public static ITransactionRepository GetTransactionRepository()
        {
            return new TransactionRepository(new DataBaseDbContext());
        }
    }
}
