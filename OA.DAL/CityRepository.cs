using Microsoft.EntityFrameworkCore;
using OA.Data;
using System.Collections.Generic;

namespace OA.DAL
{
    public class CityRepository : IRepository<City>
    {
        private DBContext db;

        public CityRepository(DBContext context)
        {
            db = context;
        }

        public IEnumerable<City> GetAll()
        {
            return db.Cities;
        }

        public City Get(int id)
        {
            return db.Cities.Find(id);
        }

        public void Create(City city)
        {
            db.Cities.Add(city);
        }

        public void Update(City city)
        {
            db.Entry(city).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            City city = db.Cities.Find(id);
            if (city != null) db.Cities.Remove(city);
        }
    }
}
