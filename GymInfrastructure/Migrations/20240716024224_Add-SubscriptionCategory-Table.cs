using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSubscriptionCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SCId",
                table: "Trainees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "MonthsRemain",
                table: "Attendence",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DaysRemain",
                table: "Attendence",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "SubscriptionCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DurationByMonth = table.Column<int>(type: "int", nullable: true),
                    DurationByDay = table.Column<int>(type: "int", nullable: true),
                    DurationByYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_SCId",
                table: "Trainees",
                column: "SCId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_SubscriptionCategory_SCId",
                table: "Trainees",
                column: "SCId",
                principalTable: "SubscriptionCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_SubscriptionCategory_SCId",
                table: "Trainees");

            migrationBuilder.DropTable(
                name: "SubscriptionCategory");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_SCId",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "SCId",
                table: "Trainees");

            migrationBuilder.AlterColumn<int>(
                name: "MonthsRemain",
                table: "Attendence",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DaysRemain",
                table: "Attendence",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
