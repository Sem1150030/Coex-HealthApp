using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthApp_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Initial32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kcalAmount = table.Column<int>(type: "int", nullable: false),
                    proteinAmount = table.Column<float>(type: "real", nullable: false),
                    carbAmount = table.Column<float>(type: "real", nullable: false),
                    fatAmount = table.Column<float>(type: "real", nullable: false),
                    measurement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KcalGoal = table.Column<int>(type: "int", nullable: false),
                    proteinGoal = table.Column<int>(type: "int", nullable: false),
                    kcalMax = table.Column<bool>(type: "bit", nullable: false),
                    proteinCurrent = table.Column<float>(type: "real", nullable: false),
                    kcalCurrent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightTrackers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    WeightGoal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightTrackers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListFoodItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoppingListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListFoodItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingListFoodItems_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingListFoodItems_ShoppingLists_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "carbAmount", "fatAmount", "kcalAmount", "measurement", "name", "proteinAmount", "userId" },
                values: new object[,]
                {
                    { new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"), 0f, 0f, 52, "100g", "Apple", 0.3f, new Guid("3b2dc595-b071-4602-82e5-869f58e84ab7") },
                    { new Guid("4eae13c3-408a-42e0-b334-d61c9ad99077"), 0f, 0f, 89, "100g", "Banana", 1.1f, new Guid("3b2dc595-b071-4602-82e5-869f58e84ab7") },
                    { new Guid("75bbd1bb-9b67-40ad-bac4-c38fdbf86c02"), 0f, 0f, 50, "100g", "Pineapple", 0.5f, new Guid("3b2cd595-b071-4602-82e5-869f58e84ab7") },
                    { new Guid("dbaf0f17-3886-4954-a093-c0872fb3c8c1"), 0f, 0f, 47, "100g", "Orange", 1f, new Guid("3b2dc595-b071-4602-82e5-869f58e84ab7") }
                });

            migrationBuilder.InsertData(
                table: "ShoppingLists",
                columns: new[] { "Id", "CreatedOn", "KcalGoal", "UserId", "kcalCurrent", "kcalMax", "proteinCurrent", "proteinGoal" },
                values: new object[,]
                {
                    { new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"), new DateTime(2024, 10, 3, 10, 42, 50, 117, DateTimeKind.Local).AddTicks(7882), 2000, new Guid("3b2cd595-b071-4602-82e5-869f58e84ab7"), 0, true, 0f, 100 },
                    { new Guid("4eae13c3-408a-42e0-b334-d61c9ad99077"), new DateTime(2024, 10, 3, 10, 42, 50, 121, DateTimeKind.Local).AddTicks(1096), 2000, new Guid("3b2cd595-b071-4602-82e5-869f58e84ab7"), 0, true, 0f, 100 },
                    { new Guid("75bbd1bb-9b67-40ad-bac4-c38fdbf86c02"), new DateTime(2024, 10, 3, 10, 42, 50, 121, DateTimeKind.Local).AddTicks(1140), 2000, new Guid("3b2cd595-b071-4602-82e5-869f58e84ab7"), 0, true, 0f, 100 },
                    { new Guid("dbaf0f17-3886-4954-a093-c0872fb3c8c1"), new DateTime(2024, 10, 3, 10, 42, 50, 121, DateTimeKind.Local).AddTicks(1135), 2000, new Guid("3b2cd595-b071-4602-82e5-869f58e84ab7"), 0, true, 0f, 100 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingListFoodItems",
                columns: new[] { "Id", "FoodItemId", "ShoppingListId" },
                values: new object[,]
                {
                    { new Guid("0ce05fb2-b587-480a-b7e9-27f6cc22c760"), new Guid("4eae13c3-408a-42e0-b334-d61c9ad99077"), new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7") },
                    { new Guid("b9abd736-8817-4117-abcc-c4f320b8fe71"), new Guid("dbaf0f17-3886-4954-a093-c0872fb3c8c1"), new Guid("4eae13c3-408a-42e0-b334-d61c9ad99077") },
                    { new Guid("d15ce629-15ad-4675-b5a1-2d3867e55b8f"), new Guid("75bbd1bb-9b67-40ad-bac4-c38fdbf86c02"), new Guid("75bbd1bb-9b67-40ad-bac4-c38fdbf86c02") },
                    { new Guid("f77c44d8-7318-4d81-9bd3-cfe6630d3020"), new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"), new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListFoodItems_FoodItemId",
                table: "ShoppingListFoodItems",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListFoodItems_ShoppingListId",
                table: "ShoppingListFoodItems",
                column: "ShoppingListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingListFoodItems");

            migrationBuilder.DropTable(
                name: "WeightTrackers");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "ShoppingLists");
        }
    }
}
