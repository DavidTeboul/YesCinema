using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please Enter Username..")]
        [Display(Name = "UserName")]
        public string USERNAME { get; set; }
        [Required(ErrorMessage = "Please Enter Password...")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PASSWORD { get; set; }
    }
}