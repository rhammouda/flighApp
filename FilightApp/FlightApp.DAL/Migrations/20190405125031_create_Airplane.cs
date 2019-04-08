using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightApp.DAL.Migrations
{
    public partial class create_Airplane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "departure",
                table: "flights");

            migrationBuilder.DropColumn(
                name: "destination",
                table: "flights");

            migrationBuilder.AddColumn<int>(
                name: "airPlaneId",
                table: "flights",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "departureId",
                table: "flights",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "destinationId",
                table: "flights",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "airplanes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    fuelConsommationInLiterByFlightSecond = table.Column<double>(nullable: false),
                    flightSpeedInKMH = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airplanes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_flights_airPlaneId",
                table: "flights",
                column: "airPlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_flights_departureId",
                table: "flights",
                column: "departureId");

            migrationBuilder.CreateIndex(
                name: "IX_flights_destinationId",
                table: "flights",
                column: "destinationId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "airplanes");

            migrationBuilder.DropIndex(
                name: "IX_flights_airPlaneId",
                table: "flights");

            migrationBuilder.DropIndex(
                name: "IX_flights_departureId",
                table: "flights");

            migrationBuilder.DropIndex(
                name: "IX_flights_destinationId",
                table: "flights");

            migrationBuilder.DropColumn(
                name: "airPlaneId",
                table: "flights");

            migrationBuilder.DropColumn(
                name: "departureId",
                table: "flights");

            migrationBuilder.DropColumn(
                name: "destinationId",
                table: "flights");

            migrationBuilder.AddColumn<string>(
                name: "departure",
                table: "flights",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination",
                table: "flights",
                nullable: true);
        }
    }
}
