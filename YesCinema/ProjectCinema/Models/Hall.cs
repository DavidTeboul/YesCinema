using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectCinema.Models
{
    public class Hall
    {
        [Key]
        public string IDHall { get; set; }
        [Required]
        public string NumberOfseat { get; set; }

    }
}