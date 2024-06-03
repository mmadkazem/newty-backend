﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Reservation.Infrastructure.Persistance.Context;

#nullable disable

namespace Reservation.Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(ReservationDbContext))]
    [Migration("20240522072001_ReserveMig")]
    partial class ReserveMig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Reservation.Domain.Entities.Account.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BusinessId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CityId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.HasIndex("CityId");

                    b.HasIndex("PhoneNumber");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Businesses.Artist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uuid");

                    b.Property<string>("CoverImagePath")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Businesses.Business", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uuid");

                    b.Property<string>("CoverImagePath")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("SmsCreditId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Businesses.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uuid");

                    b.Property<string>("CoverImagePath")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Businesses.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ArtistId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("BusinessId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Businesses.SmsCredit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("SmsCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId")
                        .IsUnique();

                    b.ToTable("SmsCredits");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Cities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Points.Point", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ArtistId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BusinessId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Rate")
                        .HasColumnType("integer");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("BusinessId");

                    b.HasIndex("UserId");

                    b.ToTable("Point");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Reserve.ReserveItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Finished")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ReserveTimeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ServiceId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ReserveTimeId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ReserveItems");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Reserve.ReserveTime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BusinessId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Finished")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("TotalEndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TotalStartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.HasIndex("UserId");

                    b.ToTable("ReserveTimes");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Account.User", b =>
                {
                    b.HasOne("Reservation.Domain.Entities.Businesses.Business", null)
                        .WithMany("UsersVIP")
                        .HasForeignKey("BusinessId");

                    b.HasOne("Reservation.Domain.Entities.Cities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Businesses.Artist", b =>
                {
                    b.HasOne("Reservation.Domain.Entities.Businesses.Business", "Business")
                        .WithMany("Artists")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Businesses.Business", b =>
                {
                    b.HasOne("Reservation.Domain.Entities.Cities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Businesses.Post", b =>
                {
                    b.HasOne("Reservation.Domain.Entities.Businesses.Business", "Business")
                        .WithMany("Posts")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Businesses.Service", b =>
                {
                    b.HasOne("Reservation.Domain.Entities.Businesses.Artist", null)
                        .WithMany("Services")
                        .HasForeignKey("ArtistId");

                    b.HasOne("Reservation.Domain.Entities.Businesses.Business", "Business")
                        .WithMany("Services")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Businesses.SmsCredit", b =>
                {
                    b.HasOne("Reservation.Domain.Entities.Businesses.Business", "Business")
                        .WithOne("SmsCredit")
                        .HasForeignKey("Reservation.Domain.Entities.Businesses.SmsCredit", "BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Points.Point", b =>
                {
                    b.HasOne("Reservation.Domain.Entities.Businesses.Artist", null)
                        .WithMany("Points")
                        .HasForeignKey("ArtistId");

                    b.HasOne("Reservation.Domain.Entities.Businesses.Business", null)
                        .WithMany("Points")
                        .HasForeignKey("BusinessId");

                    b.HasOne("Reservation.Domain.Entities.Account.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Reserve.ReserveItem", b =>
                {
                    b.HasOne("Reservation.Domain.Entities.Reserve.ReserveTime", null)
                        .WithMany("ReserveItems")
                        .HasForeignKey("ReserveTimeId");

                    b.HasOne("Reservation.Domain.Entities.Businesses.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Reserve.ReserveTime", b =>
                {
                    b.HasOne("Reservation.Domain.Entities.Businesses.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BusinessId");

                    b.HasOne("Reservation.Domain.Entities.Account.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Business");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Businesses.Artist", b =>
                {
                    b.Navigation("Points");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Businesses.Business", b =>
                {
                    b.Navigation("Artists");

                    b.Navigation("Points");

                    b.Navigation("Posts");

                    b.Navigation("Services");

                    b.Navigation("SmsCredit");

                    b.Navigation("UsersVIP");
                });

            modelBuilder.Entity("Reservation.Domain.Entities.Reserve.ReserveTime", b =>
                {
                    b.Navigation("ReserveItems");
                });
#pragma warning restore 612, 618
        }
    }
}
