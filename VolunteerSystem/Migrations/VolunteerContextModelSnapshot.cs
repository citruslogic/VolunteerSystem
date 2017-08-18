using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using VolunteerSystem.Data;

namespace VolunteerSystem.Migrations
{
    [DbContext(typeof(VolunteerContext))]
    partial class VolunteerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VolunteerSystem.Models.Availability", b =>
                {
                    b.Property<int>("AvailabilityID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AvailableEndTime");

                    b.Property<DateTime>("AvailableStartTime");

                    b.Property<int>("VolunteerID");

                    b.HasKey("AvailabilityID");

                    b.HasIndex("VolunteerID");

                    b.ToTable("Availability");
                });

            modelBuilder.Entity("VolunteerSystem.Models.Center", b =>
                {
                    b.Property<int>("CenterID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CenterAddr");

                    b.Property<string>("CenterName");

                    b.Property<string>("CenterPhone");

                    b.Property<int>("VolunteerID");

                    b.HasKey("CenterID");

                    b.HasIndex("VolunteerID");

                    b.ToTable("Center");
                });

            modelBuilder.Entity("VolunteerSystem.Models.CurrentLicense", b =>
                {
                    b.Property<int>("CurrentLicenseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("License");

                    b.Property<int>("VolunteerID");

                    b.HasKey("CurrentLicenseID");

                    b.HasIndex("VolunteerID");

                    b.ToTable("CurrentLicense");
                });

            modelBuilder.Entity("VolunteerSystem.Models.EducationBackground", b =>
                {
                    b.Property<int>("EducationBackgroundID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Background");

                    b.Property<int>("VolunteerID");

                    b.HasKey("EducationBackgroundID");

                    b.HasIndex("VolunteerID");

                    b.ToTable("EducationBackground");
                });

            modelBuilder.Entity("VolunteerSystem.Models.EmergencyContact", b =>
                {
                    b.Property<int>("EmergencyContactID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("VolunteerID");

                    b.HasKey("EmergencyContactID");

                    b.HasIndex("VolunteerID");

                    b.ToTable("EmergencyContact");
                });

            modelBuilder.Entity("VolunteerSystem.Models.InterestsSkill", b =>
                {
                    b.Property<int>("InterestsSkillID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InterestsSkills");

                    b.Property<int>("VolunteerID");

                    b.HasKey("InterestsSkillID");

                    b.HasIndex("VolunteerID");

                    b.ToTable("InterestsSkill");
                });

            modelBuilder.Entity("VolunteerSystem.Models.Volunteer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<bool>("Approved");

                    b.Property<string>("CellPhone");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("HomePhone");

                    b.Property<string>("LastName");

                    b.Property<bool>("LicenseOnFile");

                    b.Property<string>("Password");

                    b.Property<bool>("SSCardOnFile");

                    b.Property<string>("UserName");

                    b.Property<string>("WorkPhone");

                    b.HasKey("ID");

                    b.ToTable("Volunteer");
                });

            modelBuilder.Entity("VolunteerSystem.Models.Availability", b =>
                {
                    b.HasOne("VolunteerSystem.Models.Volunteer")
                        .WithMany("AvailableTimes")
                        .HasForeignKey("VolunteerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VolunteerSystem.Models.Center", b =>
                {
                    b.HasOne("VolunteerSystem.Models.Volunteer")
                        .WithMany("Centers")
                        .HasForeignKey("VolunteerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VolunteerSystem.Models.CurrentLicense", b =>
                {
                    b.HasOne("VolunteerSystem.Models.Volunteer")
                        .WithMany("Licenses")
                        .HasForeignKey("VolunteerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VolunteerSystem.Models.EducationBackground", b =>
                {
                    b.HasOne("VolunteerSystem.Models.Volunteer")
                        .WithMany("Background")
                        .HasForeignKey("VolunteerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VolunteerSystem.Models.EmergencyContact", b =>
                {
                    b.HasOne("VolunteerSystem.Models.Volunteer")
                        .WithMany("EmergencyContacts")
                        .HasForeignKey("VolunteerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VolunteerSystem.Models.InterestsSkill", b =>
                {
                    b.HasOne("VolunteerSystem.Models.Volunteer")
                        .WithMany("InterestsSkills")
                        .HasForeignKey("VolunteerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
