﻿// <auto-generated />
using System;
using Kira.Flight.Infrastructure.EfCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Kira.Flight.Infrastructure.Migrations
{
    [DbContext(typeof(FlightWriteDbContext))]
    partial class FlightWriteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Kira.Flight.Domain.Entities.Airplane", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.HasKey("Id");

                    b.ToTable("Airplanes");
                });

            modelBuilder.Entity("Kira.Flight.Domain.Entities.Airport", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("Kira.Flight.Domain.Entities.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AirplaneId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FromAirportId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ToAirportId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UtcDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AirplaneId");

                    b.HasIndex("FromAirportId");

                    b.HasIndex("ToAirportId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Kira.Flight.Domain.Entities.Seat", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FlightId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("boolean");

                    b.Property<string>("SeatNumber")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.HasKey("Id");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("Kira.Flight.Domain.Entities.Flight", b =>
                {
                    b.HasOne("Kira.Flight.Domain.Entities.Airplane", null)
                        .WithMany()
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kira.Flight.Domain.Entities.Airport", null)
                        .WithMany()
                        .HasForeignKey("FromAirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kira.Flight.Domain.Entities.Airport", null)
                        .WithMany()
                        .HasForeignKey("ToAirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}