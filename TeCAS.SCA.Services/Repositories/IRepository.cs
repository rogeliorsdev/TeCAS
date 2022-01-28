using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TeCAS.SCA.Services.Repositories
{
    public interface IRepository : IDisposable
    {
        T Create<T>(T entity) where T : class;
        bool CreateRange<T>(IEnumerable<T> entities) where T : class;
        T RetrieveById<T>(params object[] keyValues) where T : class;
        T Retrieve<T>(Expression<Func<T, bool>> criteria) where T : class;
        bool Update<T>(T entity) where T : class;
        bool Delete<T>(T entity) where T : class;
        bool DeleteRange<T>(IEnumerable<T> entities) where T : class;
        List<T> GetAll<T>() where T : class;
        List<T> Filter<T>(Expression<Func<T, bool>> criteria) where T : class;
        int TotalRecords<T>() where T : class;
        int TotalRecords<T>(Expression<Func<T, bool>> criteria) where T : class;
        bool Exist<T>(Expression<Func<T, bool>> criteria) where T : class;
    }
}
