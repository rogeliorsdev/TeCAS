using System;
using System.Collections.Generic;
using System.Linq;
using TeCAS.SCA.DAL;
using TeCAS.SCA.Entities;
using TeCAS.SCA.Services.Operations;
using static TeCAS.SCA.Entities.Enumerations.EnumerationLists;

namespace TeCAS.SCA.BLL.Implementations
{
    public class CustomerOperations : ICustomerOperations
    {
        public Customer Create(Customer customer)
        {
            Customer Result = null;
            using (var Repository = RepositoryFactory.GetRepository())
            {
                var tmp = Repository.Retrieve<Customer>(p => p.INE.ToUpper() == customer.INE.ToUpper());
                if (tmp == null)
                {
                    customer.CreateAt = DateTime.UtcNow;
                    Result = Repository.Create(customer);
                }
                else
                {
                    throw new Exception("El cliente ya se encuentra registrado en el sistema");
                }
            }

            return Result;
        }

        public bool Delete(Guid id)
        {
            bool Result = false;
            Customer tmp = RetrieveById(id);
            if (tmp != null)
            {
                using (var Repository = RepositoryFactory.GetRepository())
                {
                    tmp.Status = Status.BAJA;
                    Result = Repository.Update(tmp);
                }
            }
            else
            {
                throw new Exception("El cliente que se quiere eliminar no existe");
            }

            return Result;
        }

        public List<Customer> GetAll()
        {
            List<Customer> Result = null;
            using (var Repository = RepositoryFactory.GetRepository())
            {
                Result = Repository.GetAll<Customer>()
                                   //.OrderBy(p => p.FullName)
                                   .OrderByDescending(p => p.CreateAt)
                                   .ToList();
            }

            return Result;
        }

        public List<Customer> GetAllComplete()
        {
            List<Customer> Result = null;
            using (var Repository = RepositoryFactory.GetCustomerRepository())
            {
                Result = Repository.GetAllComplete();
            }

            return Result;
        }

        public Customer RetrieveById(Guid id)
        {
            Customer Result = null;
            using (var Repository = RepositoryFactory.GetRepository())
            {
                Result = Repository.Retrieve<Customer>(p => p.Id == id);
            }

            return Result;
        }

        public bool Update(Customer customer)
        {
            bool Result = false;
            Customer tmp = RetrieveById(customer.Id);
            if (tmp != null)
            {
                using (var Repository = RepositoryFactory.GetRepository())
                {
                    tmp = Repository.Retrieve<Customer>(p => p.INE.ToUpper() ==
                                                    customer.INE.ToUpper() && p.Id != customer.Id);
                    if (tmp == null)
                    {
                        Result = Repository.Update(customer);
                    }
                    else
                    {
                        throw new Exception("El cliente ya se encuentra registrado en el sistema");
                    }
                }
            }
            else
            {
                throw new Exception("El cliente que se quiere actualizar no existe");
            }

            return Result;
        }
    }
}
