using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VolunteerSystem.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Volunteer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(nullable: true),
                    cellNumber = table.Column<string>(nullable: true),
                    eduBackground = table.Column<string>(nullable: true),
                    emailAddress = table.Column<string>(nullable: true),
                    emergencyAddr = table.Column<string>(nullable: true),
                    emergencyEmail = table.Column<string>(nullable: true),
                    emergencyName = table.Column<string>(nullable: true),
                    emergencyPhone = table.Column<string>(nullable: true),
                    firstName = table.Column<string>(nullable: true),
                    homeNumber = table.Column<string>(nullable: true),
                    isApproved = table.Column<bool>(nullable: false),
                    isLicenseOnFile = table.Column<bool>(nullable: false),
                    isSSCardOnFile = table.Column<bool>(nullable: false),
                    lastName = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    userName = table.Column<string>(nullable: true),
                    workNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Volunteer");
        }
    }
}
