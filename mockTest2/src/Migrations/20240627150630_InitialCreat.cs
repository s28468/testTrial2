using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mockTest2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarManufacturers_CarManufacturerId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverCompetitions_Competitions_CompetitionId",
                table: "DriverCompetitions");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverCompetitions_Drivers_DriverId",
                table: "DriverCompetitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Cars_CarId",
                table: "Drivers");

            migrationBuilder.AddColumn<byte[]>(
                name: "ConcurrencyToken",
                table: "Drivers",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "ConcurrencyToken",
                table: "DriverCompetitions",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "ConcurrencyToken",
                table: "Cars",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarManufacturers_CarManufacturerId",
                table: "Cars",
                column: "CarManufacturerId",
                principalTable: "CarManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverCompetitions_Competitions_CompetitionId",
                table: "DriverCompetitions",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverCompetitions_Drivers_DriverId",
                table: "DriverCompetitions",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Cars_CarId",
                table: "Drivers",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarManufacturers_CarManufacturerId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverCompetitions_Competitions_CompetitionId",
                table: "DriverCompetitions");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverCompetitions_Drivers_DriverId",
                table: "DriverCompetitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Cars_CarId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "DriverCompetitions");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "Cars");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarManufacturers_CarManufacturerId",
                table: "Cars",
                column: "CarManufacturerId",
                principalTable: "CarManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverCompetitions_Competitions_CompetitionId",
                table: "DriverCompetitions",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverCompetitions_Drivers_DriverId",
                table: "DriverCompetitions",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Cars_CarId",
                table: "Drivers",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
