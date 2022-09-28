using System;
using System.Collections.Generic;
using System.Text;
using UserManagementWithUOW.Core.Models;
using UserManagementWithUOW.Core.Repositories;

namespace UserManagementWithUOW.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<User> users { get; }
        IBaseRepository<Certifications> Certifications { get; }
        IBaseRepository<UsersCretifications> userscretifications { get; }
        int Complete();

    }
}
