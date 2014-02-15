using System;
using System.Collections.Generic;
using System.Linq;
using LED.Domain.IRepository;
using System.Linq.Expressions;
using System.Data;

namespace LED.DataProvider.RepositoryImpl
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ledContext db;

        public Repository()
        {
            db = new ledContext();
        }

        public bool Add(T Entity)
        {
            db.Entry<T>(Entity).State = EntityState.Added;

            return db.SaveChanges() > 0;
        }

        public  bool Update(T Entity)
        {
            db.Set<T>().Attach(Entity);

            db.Entry<T>(Entity).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public  bool Delete(T Entity)
        {
            db.Set<T>().Attach(Entity);

            db.Entry<T>(Entity).State = EntityState.Deleted;

            return db.SaveChanges() > 0;

        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> condition, Expression<Func<T, object>> order = null)
        {
            var query = db.Set<T>().Where(condition);

            if (order != null)
            {
                return query.OrderBy(order);
            }
            else
            {
                return query;
            }
        }
        public T Find(params object[] entityId)
        {
            return db.Set<T>().Find(entityId);
        }

        public IEnumerable<TElement> SQLQuery<TElement>(string sql)
        {
            return db.Database.SqlQuery<TElement>(sql);
        }

    }
}
