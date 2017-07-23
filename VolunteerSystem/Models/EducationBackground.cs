using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerSystem.Models
{
    public class EducationBackground
    {
        public int EducationBackgroundID { get; set; }
        public int VolunteerID { get; set; }

        public string Background { get; set; }
    }
}
