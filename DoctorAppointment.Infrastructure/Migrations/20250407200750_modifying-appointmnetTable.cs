﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorAppointment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyingappointmnetTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppointmentCode",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentCode",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Appointments");
        }
    }
}
