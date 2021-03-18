﻿// <auto-generated />
using System;
using DevRupt.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevRupt.App.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210318164200_FurtherRelationshipConfig")]
    partial class FurtherRelationshipConfig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevRupt.Core.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("DevRupt.Core.Models.Charge", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FolioId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FolioReservationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("ServiceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ServiceType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FolioId", "FolioReservationId");

                    b.ToTable("Charges");
                });

            modelBuilder.Entity("DevRupt.Core.Models.Folio", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReservationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsMainFolio")
                        .HasColumnType("bit");

                    b.HasKey("Id", "ReservationId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Folios");
                });

            modelBuilder.Entity("DevRupt.Core.Models.GrossPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GrossPrice");
                });

            modelBuilder.Entity("DevRupt.Core.Models.PrimaryGuest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("BirthDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("BirthPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalityCountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreferredLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("PrimaryGuests");
                });

            modelBuilder.Entity("DevRupt.Core.Models.RatePlan", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSubjectToCityTax")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RatePlans");
                });

            modelBuilder.Entity("DevRupt.Core.Models.Reservation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Adults")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Arrival")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("BookingId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Departure")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("PrimaryGuestId")
                        .HasColumnType("int");

                    b.Property<string>("RatePlanId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PrimaryGuestId");

                    b.HasIndex("RatePlanId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("DevRupt.Core.Models.Service", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DefaultGrossPriceId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PricingUnit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DefaultGrossPriceId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("DevRupt.Core.Models.ServiceDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ServiceItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceItemId");

                    b.ToTable("ServiceDate");
                });

            modelBuilder.Entity("DevRupt.Core.Models.ServiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ReservationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ServiceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("TotalAmountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("TotalAmountId");

                    b.ToTable("ServiceItems");
                });

            modelBuilder.Entity("DevRupt.Core.Models.ServiceTotalAmount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("GrossAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ServiceTotalAmount");
                });

            modelBuilder.Entity("DevRupt.Core.Models.Charge", b =>
                {
                    b.HasOne("DevRupt.Core.Models.Folio", null)
                        .WithMany("Charges")
                        .HasForeignKey("FolioId", "FolioReservationId");
                });

            modelBuilder.Entity("DevRupt.Core.Models.Folio", b =>
                {
                    b.HasOne("DevRupt.Core.Models.Reservation", "Reservation")
                        .WithMany("Folios")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("DevRupt.Core.Models.PrimaryGuest", b =>
                {
                    b.HasOne("DevRupt.Core.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("DevRupt.Core.Models.Reservation", b =>
                {
                    b.HasOne("DevRupt.Core.Models.PrimaryGuest", "PrimaryGuest")
                        .WithMany()
                        .HasForeignKey("PrimaryGuestId");

                    b.HasOne("DevRupt.Core.Models.RatePlan", "RatePlan")
                        .WithMany("Reservations")
                        .HasForeignKey("RatePlanId");

                    b.Navigation("PrimaryGuest");

                    b.Navigation("RatePlan");
                });

            modelBuilder.Entity("DevRupt.Core.Models.Service", b =>
                {
                    b.HasOne("DevRupt.Core.Models.GrossPrice", "DefaultGrossPrice")
                        .WithMany()
                        .HasForeignKey("DefaultGrossPriceId");

                    b.Navigation("DefaultGrossPrice");
                });

            modelBuilder.Entity("DevRupt.Core.Models.ServiceDate", b =>
                {
                    b.HasOne("DevRupt.Core.Models.ServiceItem", null)
                        .WithMany("Dates")
                        .HasForeignKey("ServiceItemId");
                });

            modelBuilder.Entity("DevRupt.Core.Models.ServiceItem", b =>
                {
                    b.HasOne("DevRupt.Core.Models.Reservation", null)
                        .WithMany("Services")
                        .HasForeignKey("ReservationId");

                    b.HasOne("DevRupt.Core.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId");

                    b.HasOne("DevRupt.Core.Models.ServiceTotalAmount", "TotalAmount")
                        .WithMany()
                        .HasForeignKey("TotalAmountId");

                    b.Navigation("Service");

                    b.Navigation("TotalAmount");
                });

            modelBuilder.Entity("DevRupt.Core.Models.Folio", b =>
                {
                    b.Navigation("Charges");
                });

            modelBuilder.Entity("DevRupt.Core.Models.RatePlan", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("DevRupt.Core.Models.Reservation", b =>
                {
                    b.Navigation("Folios");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("DevRupt.Core.Models.ServiceItem", b =>
                {
                    b.Navigation("Dates");
                });
#pragma warning restore 612, 618
        }
    }
}
