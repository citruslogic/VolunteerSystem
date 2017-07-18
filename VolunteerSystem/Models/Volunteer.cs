using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerSystem.Models
{
    public class Volunteer
    {
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String userName { get; set; }
        public String password { get; set; }        // strong hash algorithm expected.

        private ArrayList workCenters = new ArrayList();   // centers where the volunteer prefers to work.
        private ArrayList interests = new ArrayList();

        public DateTime[] availibility { get; set; }

        public String address { get; set; }
        public String homeNumber { get; set; }
        public String workNumber { get; set; }
        public String cellNumber { get; set; }
        public String emailAddress { get; set; }

        public String eduBackground { get; set; }
        private ArrayList curLicenses = new ArrayList();

        public String emergencyName { get; set; }
        public String emergencyPhone { get; set; }
        public String emergencyEmail { get; set; }
        public String emergencyAddr { get; set; }

        public Boolean isLicenseOnFile { get; set; }
        public Boolean isSSCardOnFile { get; set; }

        public Boolean isApproved { get; set; }

    }
}
