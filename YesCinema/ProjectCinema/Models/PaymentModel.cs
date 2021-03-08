using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectCinema.Models
{
    public class PaymentModel
    {
        [Key]
        public int PaymentID { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Address { get; set; }
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        public string City { get; set; }
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        public string Country { get; set; }
        [RegularExpression(@"\b\d{5}(?:-\d{4})?\b+", ErrorMessage = "Invalid postcode")]
        public string PostCode { get; set; }
    }
}