﻿using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using SoftUniStore.Data.Contracts;

namespace SoftUniStore.Data.Repositories 
{
    public class Repository<T> :IRepostiry<T> where T : class 
    {
        protected IDbSet<T> EntityTable;

        public Repository(ISoftUniStoreContext context)
        {
            this.EntityTable = context.Set<T>();
        }
        public void InsertOrUpdate(T entity)
        {       
            this.EntityTable.AddOrUpdate(entity);
        }

        public void Delete(T entity)
        {
            this.EntityTable.Remove(entity);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this.EntityTable.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return this.EntityTable;
        }

        public T GetById(int id)
        {
            return this.EntityTable.Find(id);
        }

        public T FindByPredicate(Expression<Func<T, bool>> predicate)
        {
            return this.EntityTable.FirstOrDefault(predicate);
        }
    }
}
