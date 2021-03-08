using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCinema.Models
{
    public class ItemCart
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string MOVIENAME { get; set; }
        [Required]
        public DateTime SHOWTIME { get; set; }
        [Required]
        public string SEAT { get; set; }
        [Required]
        public int COST { get; set; }
        public int Quantity { get; set; }
    }
}