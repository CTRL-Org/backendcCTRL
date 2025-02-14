﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backendcCTRL.DataAccess;

#nullable disable

namespace backendcCTRL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250214211821_AddTables")]
    partial class AddTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("backendcCTRL.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AppointmentID"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PatientID")
                        .HasColumnType("integer");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("AppointmentID");

                    b.HasIndex("PatientID");

                    b.ToTable("Appointment", (string)null);
                });

            modelBuilder.Entity("backendcCTRL.Models.HealthStats", b =>
                {
                    b.Property<int>("StatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StatID"));

                    b.Property<string>("DataType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("PatientID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("StatID");

                    b.HasIndex("PatientID");

                    b.ToTable("HealthStats", (string)null);
                });

            modelBuilder.Entity("backendcCTRL.Models.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PatientID"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("IDNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.HasKey("PatientID");

                    b.HasIndex("UserID");

                    b.ToTable("Patient", (string)null);
                });

            modelBuilder.Entity("backendcCTRL.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("UserID");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("backendcCTRL.Models.Appointment", b =>
                {
                    b.HasOne("backendcCTRL.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("backendcCTRL.Models.HealthStats", b =>
                {
                    b.HasOne("backendcCTRL.Models.Patient", "Patient")
                        .WithMany("HealthStats")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("backendcCTRL.Models.Patient", b =>
                {
                    b.HasOne("backendcCTRL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("backendcCTRL.Models.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("HealthStats");
                });
#pragma warning restore 612, 618
        }
    }
}
