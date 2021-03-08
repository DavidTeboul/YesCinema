using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectCinema.ViewModel
{
    public class PaymentViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentID { get; set; }
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]

        public string CardName { get; set; }
        // ------------------------------Visa Card ---------------------------------------------//
        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})|(4903|4905|4911|4936|6333|6759)[0-9]{12}|(4903|4905|4911|4936|6333|6759)[0-9]{14}|(4903|4905|4911|4936|6333|6759)[0-9]{15}|564182[0-9]{10}|564182[0-9]{12}|564182[0-9]{13}|633110[0-9]{10}|633110[0-9]{12}|633110[0-9]{13}$", ErrorMessage = "Invalid Card Number")]


        public string CardNumber { get; set; }
        [Display(Name = "Valid From"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM}")]
        public DateTime ValidFrom { get; set; }

        public string CardSecurityCode { get; set; }

        [Required]
        public string Mail { get; set; }

        [RegularExpression(@"([a-zA-Z0-9\s]+)", ErrorMessage = "Invalid Address")]

        public string Address { get; set; }
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        public string City { get; set; }
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        public string Country { get; set; }
        [RegularExpression(@"\b\d{5}(?:-\d{4})?\b+", ErrorMessage = "Invalid postcode")]
        public string PostCode { get; set; }
    }
}