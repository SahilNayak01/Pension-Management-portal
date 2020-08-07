using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pension_Management_Portal.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pensionDetails",
                columns: table => new
                {
                    serialNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateOfBirth = table.Column<DateTime>(nullable: false),
                    pan = table.Column<string>(nullable: true),
                    aadharNumber = table.Column<string>(nullable: true),
                    pensionType = table.Column<int>(nullable: false),
                    pensionAmount = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pensionDetails", x => x.serialNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pensionDetails");
        }
    }
}
