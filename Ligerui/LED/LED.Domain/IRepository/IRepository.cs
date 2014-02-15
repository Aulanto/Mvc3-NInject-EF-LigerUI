using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LED.Domain.IRepository
{
    public interface IRepository<T> where T : class
    {
        bool Add(T Entity);

        bool Update(T Entity);

        bool Delete(T Entity);

        IEnumerable<T> Find(Expression<Func<T, bool>> condition, Expression<Func<T, object>> order = null);

        T Find(params object[] entityId);

        IEnumerable<TElement> SQLQuery<TElement>(string sql);
    }
}
