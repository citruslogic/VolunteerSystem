using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerSystem.Models
{
    public class Volunteer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName {get; set; }

        public string Password { get; set; }

        
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<EducationBackground> Background { get; set; }

        public virtual ICollection<CurrentLicense> Licenses { get; set; }

        public virtual ICollection<Center> Centers { get; set; }

        public virtual ICollection<InterestsSkill> InterestsSkills { get; set; }

        public virtual ICollection<Availability> AvailableTimes { get; set; }

    }
}
