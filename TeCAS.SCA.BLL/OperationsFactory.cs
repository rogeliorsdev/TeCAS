using TeCAS.SCA.BLL.Implementations;
using TeCAS.SCA.Services.Operations;

namespace TeCAS.SCA.BLL
{
    public class OperationsFactory
    {
        public static IAccountOperations GetAccountOperations()
        {
            return new AccountOperations();
        }

        public static ICustomerOperations GetCustomerOperations()
        {
            return new CustomerOperations();
        }

        public static ITransactionOperations GetTransactionOperations()
        {
            return new TransactionOperations();
        }

        public static IUserOperations GetUserOperations()
        {
            return new UserOperations();
        }        
    }
}
