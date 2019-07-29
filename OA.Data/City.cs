using System.Collections.Generic;

namespace OA.Data
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public List<User> Users { get; set; }
    }
}
