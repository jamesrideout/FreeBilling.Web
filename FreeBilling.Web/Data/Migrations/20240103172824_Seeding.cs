﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeBilling.Web.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "City", "Country", "PostalCode", "StateProvince" },
                values: new object[,]
                {
                    { 1, "123 Main Street", null, null, "Atlanta", null, "12345", "GA" },
                    { 2, "123 First Avenue", null, null, "Atlanta", null, "12345", "GA" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BillingRate", "Email", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, 220.0, "mary@freebilling.com", "./img/mary.jpg", "Mary Jones" },
                    { 2, 85.0, "betty@freebilling.com", "./img/betty.jpg", "Betty Patel" },
                    { 3, 115.0, "nancy@freebilling.com", "./img/nancy.jpg", "Nancy Smith" },
                    { 4, 145.0, "john@freebilling.com", "./img/john.jpg", "John Phillips" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "CompanyName", "Contact", "PhoneNumber" },
                values: new object[] { 1, 1, "Smith Towing", "Jim", "555-1212" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "CompanyName", "Contact", "PhoneNumber" },
                values: new object[] { 2, 2, "Paintorama", "Phyllis", "555-2121" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
