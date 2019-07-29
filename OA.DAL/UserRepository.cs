using Microsoft.EntityFrameworkCore;
using OA.Data;
using System.Collections.Generic;

namespace OA.DAL
{
    public class UserRepository : IRepository<User>
    {
        private DBContext db;

        public UserRepository(DBContext context)
        {
            db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null) db.Users.Remove(user);
        }
    }
}
