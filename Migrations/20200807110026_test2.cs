using Microsoft.EntityFrameworkCore.Migrations;

namespace Pension_Management_Portal.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "pensionDetails",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "pensionType",
                table: "pensionDetails",
                newName: "PensionType");

            migrationBuilder.RenameColumn(
                name: "pensionAmount",
                table: "pensionDetails",
                newName: "PensionAmount");

            migrationBuilder.RenameColumn(
                name: "pan",
                table: "pensionDetails",
                newName: "Pan");

            migrationBuilder.RenameColumn(
                name: "dateOfBirth",
                table: "pensionDetails",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "aadharNumber",
                table: "pensionDetails",
                newName: "AadharNumber");

            migrationBuilder.RenameColumn(
                name: "serialNumber",
                table: "pensionDetails",
                newName: "SerialNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "pensionDetails",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "PensionType",
                table: "pensionDetails",
                newName: "pensionType");

            migrationBuilder.RenameColumn(
                name: "PensionAmount",
                table: "pensionDetails",
                newName: "pensionAmount");

            migrationBuilder.RenameColumn(
                name: "Pan",
                table: "pensionDetails",
                newName: "pan");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "pensionDetails",
                newName: "dateOfBirth");

            migrationBuilder.RenameColumn(
                name: "AadharNumber",
                table: "pensionDetails",
                newName: "aadharNumber");

            migrationBuilder.RenameColumn(
                name: "SerialNumber",
                table: "pensionDetails",
                newName: "serialNumber");
        }
    }
}
