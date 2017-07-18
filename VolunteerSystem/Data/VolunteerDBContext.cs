using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VolunteerSystem.Models;

namespace VolunteerSystem.Data
{
    public class VolunteerDbContext : DbContext
    {
        public DbSet<Volunteer> Volunteers { get; set; }
    }
}
