using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerSystem.Models
{
    public class CurrentLicense
    {
        public int CurrentLicenseID { get; set; }
        public int VolunteerID { get; set; }

        public string License { get; set; }
    }
}
