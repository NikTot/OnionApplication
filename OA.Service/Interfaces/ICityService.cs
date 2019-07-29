using OA.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Interfaces
{
    public interface ICityService
    {
        IEnumerable<City> GetCities();
        City GetCity(int id);
        void CreateCity(City city);
        void UpdateCity(City city);
        void DeleteCity(int id);
    }
}
