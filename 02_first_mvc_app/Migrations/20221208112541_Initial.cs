using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _02_first_mvc_app.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 8, 13, 25, 40, 992, DateTimeKind.Local).AddTicks(9332), "saper@gmail.com", "Bob" },
                    { 2, new DateTime(2022, 12, 8, 13, 25, 40, 992, DateTimeKind.Local).AddTicks(9374), "blabla@gmail.com", "Vlad" },
                    { 3, new DateTime(2022, 12, 8, 13, 25, 40, 992, DateTimeKind.Local).AddTicks(9376), "mister@ukr.net", "John" },
                    { 4, new DateTime(2022, 12, 8, 13, 25, 40, 992, DateTimeKind.Local).AddTicks(9379), "developer@gmail.com", "Lilia" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
