using System;
using System.Collections.Generic;
using System.Linq;
using VolunteerSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace VolunteerSystem.Data
{
    public class VolunteerContext : DbContext
    {
        public VolunteerContext(DbContextOptions<VolunteerContext> options) : base(options)
        {

        }

        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<CurrentLicense> CurrentLicenses { get; set; }
        public DbSet<EducationBackground> EducationBackground { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<InterestsSkill> InterestsSkills { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Availability>().ToTable("Availability");
            modelBuilder.Entity<Center>().ToTable("Center");
            modelBuilder.Entity<CurrentLicense>().ToTable("CurrentLicense");
            modelBuilder.Entity<EducationBackground>().ToTable("EducationBackground");
            modelBuilder.Entity<EmergencyContact>().ToTable("EmergencyContact");
            modelBuilder.Entity<InterestsSkill>().ToTable("InterestsSkill");
            modelBuilder.Entity<Volunteer>().ToTable("Volunteer");
        }
    }
}
