using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaplanujTreningAPI.Entities.Entities;

namespace ZaplanujTreningAPI.Core.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetWhere(Expression<Func<User, bool>> where);
        User GetById(int id);
        User GetByUsername(string username);
        List<User> GetUsers();
        void Add(User user);
        void Update(User user);
        void SaveChanges();
    }
}
