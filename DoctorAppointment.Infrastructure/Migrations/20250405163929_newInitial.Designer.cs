﻿// <auto-generated />
using System;
using DoctorAppointment.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctorAppointment.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250405163929_newInitial")]
    partial class newInitial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DoctorAppointment.Core.Domain.Entities.Appointment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AppointmentStatus")
                        .HasColumnType("int");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("UserID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("DoctorAppointment.Core.Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExperienceYears")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Qualifications")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("SpecializationId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DoctorAppointment.Core.Domain.Entities.Review", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("UserID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("DoctorAppointment.Core.Domain.Entities.Schedule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("ID");

                    b.HasIndex("DoctorID");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("DoctorAppointment.Core.Domain.Entities.Specialization", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("DoctorAppointment.Core.Domain.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DoctorAppointment.Core.Domain.Entities.Appointment", b =>
                {
                    b.HasOne("DoctorAppointment.Core.Domain.Entities.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorAppointment.Core.Domain.Entities.User", "User")
                        .WithMany("Appointments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DoctorAppointment.Core.Domain.Entities.Doctor", b =>
                {
                    b.HasOne("DoctorAppointment.Core.Domain.Entities.Specialization", "Specialization")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("DoctorAppointment.Core.Domain.Entities.Review", b =>
                {
                    b.HasOne("DoctorAppointment.Core.Domain.Entities.Doctor", "Doctor")
                        .WithMany("Reviews")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorAppointment.Core.Domain.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DoctorAppointment.Core.Domain.Entities.Schedule", b =>
                {
                    b.HasOne("DoctorAppointment.Core.Domain.Entities.Doctor", "Doctor")
                        .WithMany("Schedules")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("DoctorAppointment.Core.Domain.Entities.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Reviews");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("DoctorAppointment.Core.Domain.Entities.Specialization", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("DoctorAppointment.Core.Domain.Entities.User", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
