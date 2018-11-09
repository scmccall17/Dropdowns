﻿// <auto-generated />
using Dropdowns.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Dropdowns.Migrations
{
    [DbContext(typeof(DropdownContext))]
    [Migration("20181102205001_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Dropdowns")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Dropdowns.Models.Continent", b =>
                {
                    b.Property<int>("ContinentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContinentName");

                    b.HasKey("ContinentID");

                    b.ToTable("Continent");
                });

            modelBuilder.Entity("Dropdowns.Models.Corporation", b =>
                {
                    b.Property<int>("CorporationID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContinentID");

                    b.Property<string>("CorporationName");

                    b.Property<int>("CountryID");

                    b.HasKey("CorporationID");

                    b.HasIndex("ContinentID");

                    b.HasIndex("CountryID");

                    b.ToTable("Corporation");
                });

            modelBuilder.Entity("Dropdowns.Models.Country", b =>
                {
                    b.Property<int>("CountryID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContinentID");

                    b.Property<string>("CountryName");

                    b.HasKey("CountryID");

                    b.HasIndex("ContinentID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Dropdowns.Models.Corporation", b =>
                {
                    b.HasOne("Dropdowns.Models.Continent", "Continent")
                        .WithMany()
                        .HasForeignKey("ContinentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dropdowns.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dropdowns.Models.Country", b =>
                {
                    b.HasOne("Dropdowns.Models.Continent", "Continent")
                        .WithMany("Countries")
                        .HasForeignKey("ContinentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
