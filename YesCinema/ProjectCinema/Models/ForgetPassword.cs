using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectCinema.Models
{
    public class ForgetPassword
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
    }
}