using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthApp_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    carbGoal = table.Column<int>(type: "int", nullable: false),
                    fatGoal = table.Column<int>(type: "int", nullable: false),
                    kcalMax = table.Column<bool>(type: "bit", nullable: false),
                    proteinCurrent = table.Column<float>(type: "real", nullable: false),
                    kcalCurrent = table.Column<int>(type: "int", nullable: false),
                    carbCurrent = table.Column<float>(type: "real", nullable: false),
                    fatCurrent = table.Column<float>(type: "real", nullable: false)
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
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sets_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "carbAmount", "fatAmount", "kcalAmount", "measurement", "name", "proteinAmount", "userId" },
                values: new object[,]
                {
                    { new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"), 0f, 0f, 52, "100g", "Apple", 0.3f, new Guid("3b2dc595-b071-4602-82e5-869f58e84ab7") },
                    { new Guid("4eae13c3-408a-42e0-b334-d61c9ad99077"), 0f, 0f, 89, "100g", "Banana", 1.1f, new Guid("3b2dc595-b071-4602-82e5-869f58e84ab7") }
                });

            migrationBuilder.InsertData(
                table: "ShoppingLists",
                columns: new[] { "Id", "CreatedOn", "KcalGoal", "UserId", "carbCurrent", "carbGoal", "fatCurrent", "fatGoal", "kcalCurrent", "kcalMax", "proteinCurrent", "proteinGoal" },
                values: new object[] { new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"), new DateTime(2024, 10, 21, 21, 47, 41, 670, DateTimeKind.Local).AddTicks(3768), 2000, new Guid("3b2cd595-b071-4602-82e5-869f58e84ab7"), 0f, 0, 0f, 0, 0, true, 0f, 100 });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[,]
                {
                    { new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7"), new DateTime(2024, 10, 21, 21, 47, 41, 679, DateTimeKind.Local).AddTicks(1249), "Push Day" },
                    { new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"), new DateTime(2024, 10, 21, 21, 47, 41, 679, DateTimeKind.Local).AddTicks(775), "Leg Day" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Name", "WorkoutId" },
                values: new object[,]
                {
                    { new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"), "Squat", new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7") },
                    { new Guid("71fadf70-8ca6-4814-b1f7-a6da47b6ee02"), "Bench Press", new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7") },
                    { new Guid("9d4ee9b0-373e-4981-8b3e-4750ed8b1ef5"), "Leg Press", new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7") },
                    { new Guid("d7405b89-f795-4ef1-b65f-18039027710a"), "Shoulder Press", new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7") }
                });

            migrationBuilder.InsertData(
                table: "ShoppingListFoodItems",
                columns: new[] { "Id", "FoodItemId", "ShoppingListId" },
                values: new object[] { new Guid("f77c44d8-7318-4d81-9bd3-cfe6630d3020"), new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"), new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7") });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "Id", "ExerciseId", "Reps", "Weight" },
                values: new object[,]
                {
                    { new Guid("3745a942-5712-4e8c-ac0d-a2f556a02472"), new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"), 10, 60m },
                    { new Guid("581d8fc0-e9c8-4fe3-af8d-df303c45e86f"), new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"), 10, 100m },
                    { new Guid("618be680-8e2f-463f-8781-b3413b60ee1d"), new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"), 12, 180m },
                    { new Guid("b2bff8d9-ee37-4777-b543-24781a32a53c"), new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"), 8, 110m },
                    { new Guid("e6df3ea2-bc5e-411d-a41c-7a7438580628"), new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"), 8, 85m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WorkoutId",
                table: "Exercises",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_ExerciseId",
                table: "Sets",
                column: "ExerciseId");

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
                name: "Sets");

            migrationBuilder.DropTable(
                name: "ShoppingListFoodItems");

            migrationBuilder.DropTable(
                name: "WeightTrackers");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "ShoppingLists");

            migrationBuilder.DropTable(
                name: "Workouts");
        }
    }
}
