using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PercentSale = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CostPrice = table.Column<int>(type: "int", nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "Fullname", "Gender", "PercentSale", "Phone" },
                values: new object[,]
                {
                    { 1, "adsa@gmail.com", "Petruk Stepan Romanovych", "M", 10, "0979372948" },
                    { 2, "fsud@gmail.com", "Lyudmila Stepanivna Romanchuk", "F", 15, "0959375027" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Fullname", "Gender", "HireDate", "Salary" },
                values: new object[,]
                {
                    { 1, "Yaroschuk Ivan Petrovych", "M", new DateTime(2020, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 8500.0 },
                    { 2, "Mykhalchuk Ruslana Romanivna", "F", new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 8500.0 },
                    { 3, "Tetyana Stepanivna Levchuk", "F", new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 8500.0 },
                    { 4, "Ihor Ivanovich Volos", "M", new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 8500.0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CostPrice", "Name", "Price", "Producer", "Quantity", "Type" },
                values: new object[,]
                {
                    { 1, 85, "Gloves", 150, "Turkey", 5, "Accessories" },
                    { 2, 85, "Glasses", 150, "China", 5, "Accessories" },
                    { 3, 120, "Belt", 250, "Turkey", 15, "Clothes" },
                    { 4, 400, "Backpack", 700, "Poland", 10, "Accessories" },
                    { 5, 800, "Adidas sneakers", 1500, "Poland", 20, "Shoes" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "ClientId", "EmployeeId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 10000m, 1, 1 },
                    { 2, 1, 1, 100m, 1, 1 },
                    { 3, 2, 2, 1800m, 4, 1 },
                    { 4, 2, 4, 10000m, 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ClientId",
                table: "Sales",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_EmployeeId",
                table: "Sales",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
