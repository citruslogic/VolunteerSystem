using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerSystem.Models.AccountViewModels
{
    public class LoginID
    {
        [Required]
        
        public string Login { get; set; }


    }
}
