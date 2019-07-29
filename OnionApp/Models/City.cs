using System.Collections.Generic;

namespace OA.Web.Models
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public List<UserViewModel> Users { get; set; }
    }
}
