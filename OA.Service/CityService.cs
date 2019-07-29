using OA.DAL;
using OA.Data;
using OA.Service.Interfaces;
using System.Collections.Generic;

namespace OA.Service
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> _cityRepository;

        public CityService(IRepository<City> CityRepository)
        {
            _cityRepository = CityRepository;

        }
        public IEnumerable<City> GetCities()
        {
            return _cityRepository.GetAll();
        }
        public City GetCity(int id)
        {
            return _cityRepository.Get(id);
        }
        public void CreateCity(City city)
        {
            _cityRepository.Create(city);
        }
        public void UpdateCity(City city)
        {
            _cityRepository.Update(city);
        }
        public void DeleteCity(int id)
        {
            _cityRepository.Delete(id);
        }
    }
}
