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
        
        //I removed the [loginid] becasue I assume id doesn't need to be validated?
        //Trying to figure out how it can be validated

        public string LoginID { get; set; }
       

        //I believe I did the above right.  Please let me know if I didn't

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
