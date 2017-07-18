using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VolunteerSystem.Models
{
    public class VolunteerSystemContext : DbContext
    {
        public VolunteerSystemContext (DbContextOptions<VolunteerSystemContext> options)
            : base(options)
        {
        }

        public DbSet<VolunteerSystem.Models.Volunteer> Volunteer { get; set; }
    }
}
