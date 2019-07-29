using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OA.Web.Models
{
    public class UserViewModel
    {
        [Required]
        [HiddenInput]
        public long Id { get; set; }        
        
        [Required(ErrorMessage = "Не указано ФИО пользователя")]
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }
}
