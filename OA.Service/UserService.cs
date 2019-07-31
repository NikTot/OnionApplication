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
        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var users = await db.Users.ToListAsync();
            return  Mapper.Map<IList<User>, IEnumerable<UserDTO>>(users); 
        }

        public async Task<UserDTO> GetUserAsync(int id)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
            return Mapper.Map<User, UserDTO>(user);
        }

        public async void CreateUserAsync(UserDTO entity)
        {
            var user = Mapper.Map<UserDTO, User>(entity);           
            await db.Users.AddAsync(user);
            db.SaveChanges();
        }
        public async void UpdateUserAsync(UserDTO entity)
        {
            var user = Mapper.Map<UserDTO, User>(entity);
            var userDB = await db.Users.FirstOrDefaultAsync(u => u.Id == user.Id);  
            if (userDB != null)
            {
                userDB.UserName = user.UserName;
                userDB.City = user.City;
                userDB.Email = user.Email;
                userDB.PhoneNumber = user.PhoneNumber;
            }
            db.Entry(userDB).State = EntityState.Modified;
            db.SaveChanges();
        }
        public async void DeleteUserAsync(int id)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null) db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
