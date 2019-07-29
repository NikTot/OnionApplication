using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OA.Web.Models
{
    public class UserViewModel
    {
        [Required]
        [HiddenInput]
        public long Id { get; set; }        
        
        [Required(ErrorMessage = "Required error message defined on the model")]
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [Display(Name = "City")]
        public City City { get; set; }
    }
}
