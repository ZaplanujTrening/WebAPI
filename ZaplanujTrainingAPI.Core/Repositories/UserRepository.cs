using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ZaplanujTreningAPI.Core.Repositories.Interfaces;
using ZaplanujTreningAPI.Entities;
using ZaplanujTreningAPI.Entities.Entities;

namespace ZaplanujTreningAPI.Core.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DataContext _db;

        public UserRepository(DataContext context) : base(context)
        {
            _db = Context;
        }

        public User GetWhere(Expression<Func<User, bool>> where)
        {
            return Get(where);
        }

        public User GetUserById(int id)
        {
            return GetById(id);
        }

        public User GetByUsername(string username)
        {
            return Get(a => a.Username == username);
        }

        public List<User> GetUsers()
        {
            return GetAll().ToList();
        }
    }
}
