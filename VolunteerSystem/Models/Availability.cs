using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerSystem.Models
{
    public class Availability
    {
        public int AvailabilityID { get; set; }

        public List<DateTime> AvailableTimes { get; set; }
    }
}
