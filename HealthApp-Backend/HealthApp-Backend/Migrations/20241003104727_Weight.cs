using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthApp_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Weight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "carbCurrent",
                table: "ShoppingLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "carbGoal",
                table: "ShoppingLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fatCurrent",
                table: "ShoppingLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fatGoal",
                table: "ShoppingLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                columns: new[] { "CreatedOn", "carbCurrent", "carbGoal", "fatCurrent", "fatGoal" },
                values: new object[] { new DateTime(2024, 10, 3, 12, 47, 26, 664, DateTimeKind.Local).AddTicks(8288), 0, 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("4eae13c3-408a-42e0-b334-d61c9ad99077"),
                columns: new[] { "CreatedOn", "carbCurrent", "carbGoal", "fatCurrent", "fatGoal" },
                values: new object[] { new DateTime(2024, 10, 3, 12, 47, 26, 667, DateTimeKind.Local).AddTicks(6430), 0, 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("75bbd1bb-9b67-40ad-bac4-c38fdbf86c02"),
                columns: new[] { "CreatedOn", "carbCurrent", "carbGoal", "fatCurrent", "fatGoal" },
                values: new object[] { new DateTime(2024, 10, 3, 12, 47, 26, 667, DateTimeKind.Local).AddTicks(6497), 0, 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("dbaf0f17-3886-4954-a093-c0872fb3c8c1"),
                columns: new[] { "CreatedOn", "carbCurrent", "carbGoal", "fatCurrent", "fatGoal" },
                values: new object[] { new DateTime(2024, 10, 3, 12, 47, 26, 667, DateTimeKind.Local).AddTicks(6492), 0, 0, 0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "carbCurrent",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "carbGoal",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "fatCurrent",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "fatGoal",
                table: "ShoppingLists");

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                column: "CreatedOn",
                value: new DateTime(2024, 10, 3, 10, 42, 50, 117, DateTimeKind.Local).AddTicks(7882));

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("4eae13c3-408a-42e0-b334-d61c9ad99077"),
                column: "CreatedOn",
                value: new DateTime(2024, 10, 3, 10, 42, 50, 121, DateTimeKind.Local).AddTicks(1096));

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("75bbd1bb-9b67-40ad-bac4-c38fdbf86c02"),
                column: "CreatedOn",
                value: new DateTime(2024, 10, 3, 10, 42, 50, 121, DateTimeKind.Local).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("dbaf0f17-3886-4954-a093-c0872fb3c8c1"),
                column: "CreatedOn",
                value: new DateTime(2024, 10, 3, 10, 42, 50, 121, DateTimeKind.Local).AddTicks(1135));
        }
    }
}
