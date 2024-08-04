using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editAttendenceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendence_Trainees_TraineeId",
                table: "Attendence");

            migrationBuilder.AlterColumn<Guid>(
                name: "TraineeId",
                table: "Attendence",
                type: "uniqueidentifier",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AttendedOn",
                table: "Attendence",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendence_Trainees_TraineeId",
                table: "Attendence",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendence_Trainees_TraineeId",
                table: "Attendence");

            migrationBuilder.AlterColumn<Guid>(
                name: "TraineeId",
                table: "Attendence",
                type: "uniqueidentifier",
                maxLength: 50,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AttendedOn",
                table: "Attendence",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendence_Trainees_TraineeId",
                table: "Attendence",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
