﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserApp_Demo.Migrations
{
    /// <inheritdoc />
    public partial class AddOTP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailOtp",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OtpExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailOtp",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OtpExpiryTime",
                table: "AspNetUsers");
        }
    }
}
