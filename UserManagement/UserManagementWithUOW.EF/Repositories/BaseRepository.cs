using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using UserManagementWithUOW.Core.Repositories;

namespace UserManagementWithUOW.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDBContext _context;

        public BaseRepository(ApplicationDBContext context)
        {
            _context = context;
        }


        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

      

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> match)
        {


            return _context.Set<T>().Where(match).ToList();
        }

    


    }
}
