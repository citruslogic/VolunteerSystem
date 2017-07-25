using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerSystem.Models
{
    public class Availability
    {
        public int AvailabilityID { get; set; }
        public int VolunteerID { get; set; }

        public DateTime AvailableStartTime { get; set; }
        public DateTime AvailableEndTime { get; set; }
    }
}
