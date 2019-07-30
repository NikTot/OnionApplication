using System.ComponentModel.DataAnnotations;

namespace OA.Service.Models
{
    public class UserDTO
    {
        [Required]
        public long Id { get; set; }        
        
        [Required(ErrorMessage = "Не указано ФИО пользователя")]
        public string UserName { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Некорректный номер телефона")]
        [RegularExpression(@"^(\+[7])\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Некорректный номер телефона")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }
}
