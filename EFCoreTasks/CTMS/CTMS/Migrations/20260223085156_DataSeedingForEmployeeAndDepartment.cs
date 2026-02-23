using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CTMS.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedingForEmployeeAndDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DateOfEstablishment", "Description", "Location", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Produce Valuable Software", "3rd-floor", "IT" },
                    { 2, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Produce Valuable Software", "3rd-floor", "Salse" },
                    { 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Produce Valuable Software", "3rd-floor", "Marketing" },
                    { 4, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Produce Valuable Software", "3rd-floor", "QA" },
                    { 5, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Produce Valuable Software", "3rd-floor", "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentId", "Designation", "Email", "Name", "PhoneNumber", "Salary", "YearsOfExperties" },
                values: new object[,]
                {
                    { 1, "khambhat", 1, "Software Developer", "raj123@gmail.com", "Raj Rana", "7046192318", 40000m, 3 },
                    { 2, "Lodhva", 1, "Software Developer", "ravi123@gmail.com", "Vadher Ravi", "8046192318", 40000m, 3 },
                    { 3, "Vadhvan", 2, "Salse Executive", "rakesh123@gmail.com", "Rakesh Parmar", "8146192318", 30000m, 2 },
                    { 4, "Gondal", 3, "Salse Executive", "yashraj123@gmail.com", "Yashraj Vaghela", "7746192318", 20000m, 2 },
                    { 5, "Rajkot", 3, "Marketing Intern", "akash123@gmail.com", "Akash Pateliya", "7846192318", 5000m, 1 },
                    { 6, "Nadiyad", 4, "QA Developer", "mehul123@gmail.com", "Mehul Prajapati", "8086192318", 40000m, 3 },
                    { 7, "Anand", 5, "Accountent", "sujal123@gmail.com", "Sujal Prajapati", "7946192318", 50000m, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
