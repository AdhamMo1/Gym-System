using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EdittraineeTableandAttendenceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysRemain",
                table: "Attendence");

            migrationBuilder.DropColumn(
                name: "MonthsRemain",
                table: "Attendence");

            migrationBuilder.AddColumn<int>(
                name: "DaysRemain",
                table: "Trainees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonthsRemain",
                table: "Trainees",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysRemain",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "MonthsRemain",
                table: "Trainees");

            migrationBuilder.AddColumn<int>(
                name: "DaysRemain",
                table: "Attendence",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonthsRemain",
                table: "Attendence",
                type: "int",
                nullable: true);
        }
    }
}
