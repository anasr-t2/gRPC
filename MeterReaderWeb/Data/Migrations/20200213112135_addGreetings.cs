using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeterReaderWeb.Migrations
{
    public partial class addGreetings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Greetings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    GreetingContent = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Greetings", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReadingDate",
                value: new DateTime(2020, 2, 13, 13, 21, 34, 541, DateTimeKind.Local).AddTicks(2125));

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReadingDate",
                value: new DateTime(2020, 2, 13, 13, 21, 34, 542, DateTimeKind.Local).AddTicks(6566));

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReadingDate",
                value: new DateTime(2020, 2, 13, 13, 21, 34, 542, DateTimeKind.Local).AddTicks(6666));

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReadingDate",
                value: new DateTime(2020, 2, 13, 13, 21, 34, 542, DateTimeKind.Local).AddTicks(6671));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Greetings");

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReadingDate",
                value: new DateTime(2019, 9, 24, 23, 38, 57, 515, DateTimeKind.Local).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReadingDate",
                value: new DateTime(2019, 9, 24, 23, 38, 57, 518, DateTimeKind.Local).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReadingDate",
                value: new DateTime(2019, 9, 24, 23, 38, 57, 518, DateTimeKind.Local).AddTicks(8719));

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReadingDate",
                value: new DateTime(2019, 9, 24, 23, 38, 57, 518, DateTimeKind.Local).AddTicks(8724));
        }
    }
}
