using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CustomerApp.DTO
{
    public class Customer
    {       
        public int CustomerID { get; set; }

        [Required]   
        [Display(Name ="First name")]
        [StringLength(50,MinimumLength =2)]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter a valid first name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter a valid last name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email address")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
       
    }
   
}
