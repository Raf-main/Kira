using System;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kira.Flight.Infrastructure.Migrations;

/// <inheritdoc />
public partial class initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable("Airplanes",
            table => new
            {
                Id = table.Column<Guid>("uuid", nullable: false),
                Name = table.Column<string>("character varying(32)", maxLength: 32, nullable: false),
                Model = table.Column<string>("character varying(32)", maxLength: 32, nullable: false)
            }, constraints: table => { table.PrimaryKey("PK_Airplanes", x => x.Id); });

        migrationBuilder.CreateTable("Airports",
            table => new
            {
                Id = table.Column<Guid>("uuid", nullable: false),
                Name = table.Column<string>("character varying(32)", maxLength: 32, nullable: false)
            }, constraints: table => { table.PrimaryKey("PK_Airports", x => x.Id); });

        migrationBuilder.CreateTable("Seats",
            table => new
            {
                Id = table.Column<Guid>("uuid", nullable: false),
                SeatNumber = table.Column<string>("character varying(32)", maxLength: 32, nullable: false),
                FlightId = table.Column<Guid>("uuid", nullable: false),
                IsReserved = table.Column<bool>("boolean", nullable: false)
            }, constraints: table => { table.PrimaryKey("PK_Seats", x => x.Id); });

        migrationBuilder.CreateTable("Flights",
            table => new
            {
                Id = table.Column<Guid>("uuid", nullable: false),
                AirplaneId = table.Column<Guid>("uuid", nullable: false),
                FromAirportId = table.Column<Guid>("uuid", nullable: false),
                ToAirportId = table.Column<Guid>("uuid", nullable: false),
                Price = table.Column<decimal>("numeric", nullable: false),
                UtcDateTime = table.Column<DateTimeOffset>("timestamp with time zone", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_Flights", x => x.Id);

                table.ForeignKey("FK_Flights_Airplanes_AirplaneId", x => x.AirplaneId, "Airplanes", "Id",
                    onDelete: ReferentialAction.Cascade);

                table.ForeignKey("FK_Flights_Airports_FromAirportId", x => x.FromAirportId, "Airports", "Id",
                    onDelete: ReferentialAction.Cascade);

                table.ForeignKey("FK_Flights_Airports_ToAirportId", x => x.ToAirportId, "Airports", "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex("IX_Flights_AirplaneId", "Flights", "AirplaneId");

        migrationBuilder.CreateIndex("IX_Flights_FromAirportId", "Flights", "FromAirportId");

        migrationBuilder.CreateIndex("IX_Flights_ToAirportId", "Flights", "ToAirportId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable("Flights");

        migrationBuilder.DropTable("Seats");

        migrationBuilder.DropTable("Airplanes");

        migrationBuilder.DropTable("Airports");
    }
}
