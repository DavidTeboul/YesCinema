using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectCinema.Models
{
    public class MovieUploadModel
    {

        [Key]
        [Required]
        public string ID { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public DateTime showtime { get; set; }

        [Required]
        public string price { get; set; }


        [Required]
        public string SALLE { get; set; }

        [Required]
        public string ageLimitation { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string moviePicture { get; set; }
    }
}