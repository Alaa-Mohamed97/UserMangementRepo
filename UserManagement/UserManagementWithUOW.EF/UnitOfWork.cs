using System;
using System.Collections.Generic;
using System.Text;
using UserManagementWithUOW.Core;
using UserManagementWithUOW.Core.Models;
using UserManagementWithUOW.Core.Repositories;
using UserManagementWithUOW.EF.Repositories;

namespace UserManagementWithUOW.EF
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public IBaseRepository<User> users { get;private set; }
        public IBaseRepository<Certifications> Certifications { get; private set; }
        public IBaseRepository<UsersCretifications> userscretifications { get; private set; }

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            users = new BaseRepository<User>(_context);
            Certifications = new BaseRepository<Certifications>(_context);
            userscretifications =new BaseRepository<UsersCretifications>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
