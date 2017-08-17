using System;
using System.Collections.Generic;
using System.Linq;
using VolunteerSystem.Models;

namespace VolunteerSystem.Data
{
    public static class DbInitializer
    {

        public static void Initialize(VolunteerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any volunteers.
            if (context.Volunteers.Any())
                return;

            var volunteers = new Volunteer[]
            {
                new Volunteer{FirstName="Carson", LastName="Timothy", Address="101 Dundee Dr.", UserName="TCarson",
                    Password="whatever1", HomePhone="544-5440", CellPhone="444-0550", WorkPhone="100-2222",
                    Email="TCarson@imail.com"}
            };

            foreach (Volunteer v in volunteers)
            {
                context.Volunteers.Add(v);
            }
            context.SaveChanges();

            var availabilities = new Availability[]
            {
                new Availability{VolunteerID=1, AvailableStartTime=DateTime.Parse("10:45 AM"),
                    AvailableEndTime=DateTime.Parse("5:30 PM")}
            };

            foreach (Availability a in availabilities)
            {
                context.Availabilities.Add(a);
            }

            context.SaveChanges();

            var centers = new Center[]
            {
                new Center{CenterID=1, CenterName="Unknown Center Name", CenterAddr="2507 Deer Run Pkwy.",
                CenterPhone="707-7000", VolunteerID=1 }
            };

            foreach (Center c in centers)
            {
                context.Centers.Add(c);
            }
            context.SaveChanges();

            var licenses = new CurrentLicense[]
            {
                new CurrentLicense{VolunteerID=1, CurrentLicenseID=1, License=""}
            };

            foreach (CurrentLicense l in licenses)
            {
                context.CurrentLicenses.Add(l);
            }
            context.SaveChanges();

            var education = new EducationBackground[]
            {
                new EducationBackground{EducationBackgroundID=1, VolunteerID=1, Background="BA Social Services" }

            };

            foreach (EducationBackground e in education)
            {
                context.EducationBackground.Add(e);
            }
            context.SaveChanges();

            var contacts = new EmergencyContact[]
            {
                new EmergencyContact{EmergencyContactID=1, VolunteerID=1, Address="1704 Whispering Forest Dr.", FirstName="Fred", LastName="Jackson", PhoneNumber="9045555555" }
            };

            foreach (EmergencyContact ec in contacts)
            {
                context.EmergencyContacts.Add(ec);
            }
            context.SaveChanges();

            var interests = new InterestsSkill[]
            {
                new InterestsSkill{InterestsSkillID=1, VolunteerID=1, InterestsSkills="Microsoft Excel, Skiing"}
            };

            foreach (InterestsSkill s in interests)
            {
                context.InterestsSkills.Add(s);
            }
            context.SaveChanges();

        }
    }
}
