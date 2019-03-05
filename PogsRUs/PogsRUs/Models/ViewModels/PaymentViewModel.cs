using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models.ViewModels
{
    public class PaymentViewModel
    {
        [Required]
        public string UserID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Zip code")]
        public string Zipcode { get; set; }

        [Required]
        [Display(Name = "Credit Card")]
        [DataType(DataType.CreditCard)]
        public string CreditCardNumber{ get; set; }


        [Required]
        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public string ExpirationDate { get; set; }
    }
}
