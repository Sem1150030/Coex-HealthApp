using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthApp_Backend.Migrations
{
    /// <inheritdoc />
    public partial class bugfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "fatCurrent",
                table: "ShoppingLists",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "carbCurrent",
                table: "ShoppingLists",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                columns: new[] { "CreatedOn", "carbCurrent", "fatCurrent" },
                values: new object[] { new DateTime(2024, 10, 3, 16, 14, 48, 501, DateTimeKind.Local).AddTicks(626), 0f, 0f });

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("4eae13c3-408a-42e0-b334-d61c9ad99077"),
                columns: new[] { "CreatedOn", "carbCurrent", "fatCurrent" },
                values: new object[] { new DateTime(2024, 10, 3, 16, 14, 48, 504, DateTimeKind.Local).AddTicks(8824), 0f, 0f });

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("75bbd1bb-9b67-40ad-bac4-c38fdbf86c02"),
                columns: new[] { "CreatedOn", "carbCurrent", "fatCurrent" },
                values: new object[] { new DateTime(2024, 10, 3, 16, 14, 48, 504, DateTimeKind.Local).AddTicks(8907), 0f, 0f });

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("dbaf0f17-3886-4954-a093-c0872fb3c8c1"),
                columns: new[] { "CreatedOn", "carbCurrent", "fatCurrent" },
                values: new object[] { new DateTime(2024, 10, 3, 16, 14, 48, 504, DateTimeKind.Local).AddTicks(8898), 0f, 0f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "fatCurrent",
                table: "ShoppingLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "carbCurrent",
                table: "ShoppingLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                columns: new[] { "CreatedOn", "carbCurrent", "fatCurrent" },
                values: new object[] { new DateTime(2024, 10, 3, 12, 47, 26, 664, DateTimeKind.Local).AddTicks(8288), 0, 0 });

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("4eae13c3-408a-42e0-b334-d61c9ad99077"),
                columns: new[] { "CreatedOn", "carbCurrent", "fatCurrent" },
                values: new object[] { new DateTime(2024, 10, 3, 12, 47, 26, 667, DateTimeKind.Local).AddTicks(6430), 0, 0 });

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("75bbd1bb-9b67-40ad-bac4-c38fdbf86c02"),
                columns: new[] { "CreatedOn", "carbCurrent", "fatCurrent" },
                values: new object[] { new DateTime(2024, 10, 3, 12, 47, 26, 667, DateTimeKind.Local).AddTicks(6497), 0, 0 });

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("dbaf0f17-3886-4954-a093-c0872fb3c8c1"),
                columns: new[] { "CreatedOn", "carbCurrent", "fatCurrent" },
                values: new object[] { new DateTime(2024, 10, 3, 12, 47, 26, 667, DateTimeKind.Local).AddTicks(6492), 0, 0 });
        }
    }
}
