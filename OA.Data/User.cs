using System.ComponentModel.DataAnnotations;

namespace OA.Data
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }
}
