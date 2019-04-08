using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightApp.DAL.Migrations
{
    public partial class flightForeigKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_flights_airplanes_airPlaneId",
                table: "flights");

            migrationBuilder.DropForeignKey(
                name: "FK_flights_airports_departureId",
                table: "flights");

            migrationBuilder.DropForeignKey(
                name: "FK_flights_airports_destinationId",
                table: "flights");

            migrationBuilder.RenameColumn(
                name: "airPlaneId",
                table: "flights",
                newName: "airplaneId");

            migrationBuilder.RenameIndex(
                name: "IX_flights_airPlaneId",
                table: "flights",
                newName: "IX_flights_airplaneId");

            migrationBuilder.AlterColumn<int>(
                name: "destinationId",
                table: "flights",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "departureId",
                table: "flights",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "airplaneId",
                table: "flights",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_flights_airplanes_airplaneId",
                table: "flights",
                column: "airplaneId",
                principalTable: "airplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_flights_airports_departureId",
                table: "flights",
                column: "departureId",
                principalTable: "airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_flights_airports_destinationId",
                table: "flights",
                column: "destinationId",
                principalTable: "airports",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_flights_airplanes_airplaneId",
                table: "flights");

            migrationBuilder.DropForeignKey(
                name: "FK_flights_airports_departureId",
                table: "flights");

            migrationBuilder.DropForeignKey(
                name: "FK_flights_airports_destinationId",
                table: "flights");

            migrationBuilder.RenameColumn(
                name: "airplaneId",
                table: "flights",
                newName: "airPlaneId");

            migrationBuilder.RenameIndex(
                name: "IX_flights_airplaneId",
                table: "flights",
                newName: "IX_flights_airPlaneId");

            migrationBuilder.AlterColumn<int>(
                name: "destinationId",
                table: "flights",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "departureId",
                table: "flights",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "airPlaneId",
                table: "flights",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_flights_airplanes_airPlaneId",
                table: "flights",
                column: "airPlaneId",
                principalTable: "airplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_flights_airports_departureId",
                table: "flights",
                column: "departureId",
                principalTable: "airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_flights_airports_destinationId",
                table: "flights",
                column: "destinationId",
                principalTable: "airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
