using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectCinema.Models
{
    public class Seat
    {
        [Key]
        public string IdSeat { get; set; }
        [Required]
        public string Hall { get; set; }
        [Required]
        public string Range { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public DateTime date { get; set; }

        public bool reserve { get; set; }
    }
}