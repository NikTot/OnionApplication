using Microsoft.EntityFrameworkCore;
using OA.Data;

namespace OA.DAL
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
