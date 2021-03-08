using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCinema.Models
{
	public class Tickets
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "Please Enter Movie Name...")]
        public string MOVIENAME { get; set; }
        [Required(ErrorMessage = "Please Enter Showtime...")]
        public DateTime SHOWTIME { get; set; }
        [Required(ErrorMessage = "Please Enter Seat...")]
        public string SEAT { get; set; }
        [Required(ErrorMessage = "Please Enter Cost...")]
        public int COST { get; set; }

 

    }
}