using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace UserManagementWithUOW.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Add(T entity);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> match);
    }
}
