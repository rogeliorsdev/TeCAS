using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TeCAS.SCA.Services.Repositories;

namespace TeCAS.SCA.DAL.Implementations
{
    public class Repository : IRepository
    {
        DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public T Create<T>(T entity) where T : class
        {
            Context.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public bool CreateRange<T>(IEnumerable<T> entities) where T : class
        {
            Context.AddRange(entities);
            Context.SaveChanges();
            bool Result = true;
            return Result;
        }

        public T RetrieveById<T>(params object[] keyValues) where T : class
        {
            return Context.Find<T>(keyValues);
        }

        public T Retrieve<T>(Expression<Func<T, bool>> criteria) where T : class
        {
            T Result = Context.Set<T>().AsNoTracking().FirstOrDefault(criteria);
            return Result;
        }

        public bool Delete<T>(T entity) where T : class
        {
            Context.Remove(entity);
            bool Result = Context.SaveChanges() > 0;
            return Result;
        }

        public bool DeleteRange<T>(IEnumerable<T> entities) where T : class
        {
            Context.Set<T>().RemoveRange(entities);
            bool Result = Context.SaveChanges() > 0;
            return Result;
        }

        public List<T> GetAll<T>() where T : class
        {
            return Context.Set<T>().ToList();
        }

        public bool Update<T>(T entity) where T : class
        {
            Context.Update(entity);
            bool Result = Context.SaveChanges() > 0;
            return Result;
        }

        public List<T> Filter<T>(Expression<Func<T, bool>> criteria) where T : class
        {
            List<T> Result = Context.Set<T>().Where(criteria).ToList();
            return Result;
        }

        public int TotalRecords<T>(Expression<Func<T, bool>> criteria) where T : class
        {
            int Result = Context.Set<T>().Count(criteria);
            return Result;
        }

        public int TotalRecords<T>() where T : class
        {
            int Result = Context.Set<T>().Count();
            return Result;
        }

        public bool Exist<T>(Expression<Func<T, bool>> criteria) where T : class
        {
            bool band = false;
            T Result = Context.Set<T>().FirstOrDefault(criteria);
            if (Result != null)
            {
                band = true;
            }
            return band;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
