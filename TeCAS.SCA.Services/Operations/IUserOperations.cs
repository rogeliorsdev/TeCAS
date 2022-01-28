using System;
using System.Collections.Generic;
using TeCAS.SCA.Entities;

namespace TeCAS.SCA.Services.Operations
{
    public interface IUserOperations
    {
        User AuthUser(string email, string password);
        User Create(User user, string password);
        bool Delete(Guid id);
        User Find(string email);
        List<User> GetAll();
        User RetrieveById(Guid id);
        bool Update(User user);
        bool UpdatePassword(User user, string password);
    }
}
