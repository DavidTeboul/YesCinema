using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCinema.Models
{
    public partial class User
    {
        [Key]
        public string USERID { get; set; }
        [Required(ErrorMessage = "Please Enter Username..")]
        [Display(Name = "UserName")]
        public string USERNAME { get; set; }
        [Required(ErrorMessage = "Please Enter Password...")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PASSWORD { get; set; }
        [Required(ErrorMessage = "Please Enter the Confirm Password...")]
        [Compare("PASSWORD", ErrorMessage = "Password and Confirmation Password must match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string CONFIRMPASS { get; set; }
        [Required(ErrorMessage = "Please Enter Email...")]
        [Display(Name = "Email")]
        public string MAIL { get; set; }
    }
}