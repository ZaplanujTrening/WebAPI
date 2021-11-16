using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ZaplanujTreningAPI.Entities;
using ZaplanujTreningAPI.Utils.Helpers;

namespace ZaplanujTreningAPI.Core.Repositories
{
    public abstract class BaseRepository<T>
        where T : class
    {
        private readonly DbSet<T> _dbset;
        private DataContext _context;

        protected DataContext Context
        {
            get { return _context; }
        }

        protected BaseRepository(DataContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                _dbset.Remove(obj);
            }
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).FirstOrDefault<T>();
        }

        public virtual T GetById(long id)
        {
            return _dbset.Find(id);
        }

        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbset;
        }

        public virtual bool Any(Expression<Func<T, bool>> where)
        {
            return _dbset.Any(where);
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new AppException($"DB error! {e.Message}");
            }
        }
    }
}
