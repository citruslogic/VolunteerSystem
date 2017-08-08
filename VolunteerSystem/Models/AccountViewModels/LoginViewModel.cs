using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerSystem.Models.AccountViewModels
{
    public class LoginViewModel
    {
        // Login should require a name for tracking purposes and to validate authority.
        // Unless it's ran off of email address.
        // DT  I'm trying to get a first Name and Last Name in the login page.  
        [Required]
        [StringLength(20)]
        [Display(Name = "Login ID")]
        public string LoginID { get; set; }

       //End of insertion

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
