using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OA.DAL;
using OA.Service.Interfaces;
using OA.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Service
{
    public class UserService : IUserService
    {
        private DBContext db;        

        public UserService(DBContext context)
        {
            db = context;

        }
        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var users = await db.Users.ToListAsync();
            return  Mapper.Map<IList<User>, IEnumerable<UserDTO>>(users); 
        }

        public async Task<UserDTO> GetUser(int id)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
            return Mapper.Map<User, UserDTO>(user);
        }

        public void CreateUser(UserDTO entity)
        {
            var user = Mapper.Map<UserDTO, User>(entity);
            db.Users.Add(user);
            db.SaveChanges();
        }
        public async void UpdateUser(UserDTO entity)
        {
            var user = Mapper.Map<UserDTO, User>(entity);
            var userDB = await db.Users.FirstOrDefaultAsync(u => u.Id == user.Id);           
            db.Entry(userDB).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteUser(int id)
        {            
            User user = db.Users.Find(id);
            if (user != null) db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
