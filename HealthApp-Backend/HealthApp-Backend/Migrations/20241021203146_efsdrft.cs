using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthApp_Backend.Migrations
{
    /// <inheritdoc />
    public partial class efsdrft : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("14e15f88-1acb-4434-b57d-801ce537d320"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("5466a11b-071b-4035-830d-722b5f30f4f2"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("cd82fefa-e1c3-4aae-b212-3c7ccc3e9180"));

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("01734cd3-fd5d-425e-aaac-9ab518f6aa05"));

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("04d633cb-5603-475d-8113-4ea1929971c2"));

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("3edb3285-2beb-4764-b1ef-5ece4e95df47"));

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("bae3ec35-73db-4194-998c-8b9157c7ee0a"));

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("f439526b-ac56-4fd9-96eb-611139b50ca0"));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"),
                column: "WorkoutId",
                value: new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"));

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Name", "WorkoutId", "userId" },
                values: new object[] { new Guid("4b2cf595-b031-4602-82e5-869f58e84ab7"), "Leg Press", new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"), new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95") });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "Id", "ExerciseId", "Reps", "Weight", "userId" },
                values: new object[,]
                {
                    { new Guid("77c30cd7-4881-479d-b6c9-3798a0a49666"), new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"), 10, 100m, new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95") },
                    { new Guid("d42fe59f-bf98-4648-aafe-00f04ce4ecdc"), new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"), 8, 110m, new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95") }
                });

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                column: "CreatedOn",
                value: new DateTime(2024, 10, 21, 22, 31, 45, 508, DateTimeKind.Local).AddTicks(7015));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7"),
                column: "Date",
                value: new DateTime(2024, 10, 21, 22, 31, 45, 517, DateTimeKind.Local).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                column: "Date",
                value: new DateTime(2024, 10, 21, 8, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "Id", "ExerciseId", "Reps", "Weight", "userId" },
                values: new object[,]
                {
                    { new Guid("b66fd2d1-e74e-4697-8a1d-d8eb5296f865"), new Guid("4b2cf595-b031-4602-82e5-869f58e84ab7"), 12, 180m, new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95") },
                    { new Guid("fad149dc-a195-4ebb-9342-b18ef781d90c"), new Guid("4b2cf595-b031-4602-82e5-869f58e84ab7"), 10, 190m, new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("77c30cd7-4881-479d-b6c9-3798a0a49666"));

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("b66fd2d1-e74e-4697-8a1d-d8eb5296f865"));

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("d42fe59f-bf98-4648-aafe-00f04ce4ecdc"));

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("fad149dc-a195-4ebb-9342-b18ef781d90c"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("4b2cf595-b031-4602-82e5-869f58e84ab7"));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"),
                column: "WorkoutId",
                value: new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7"));

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Name", "WorkoutId", "userId" },
                values: new object[,]
                {
                    { new Guid("14e15f88-1acb-4434-b57d-801ce537d320"), "Shoulder Press", new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7"), new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95") },
                    { new Guid("5466a11b-071b-4035-830d-722b5f30f4f2"), "Bench Press", new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7"), new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95") },
                    { new Guid("cd82fefa-e1c3-4aae-b212-3c7ccc3e9180"), "Leg Press", new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7"), new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95") }
                });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "Id", "ExerciseId", "Reps", "Weight", "userId" },
                values: new object[,]
                {
                    { new Guid("01734cd3-fd5d-425e-aaac-9ab518f6aa05"), new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"), 10, 60m, new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95") },
                    { new Guid("04d633cb-5603-475d-8113-4ea1929971c2"), new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"), 8, 85m, new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95") },
                    { new Guid("3edb3285-2beb-4764-b1ef-5ece4e95df47"), new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"), 8, 110m, new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95") },
                    { new Guid("bae3ec35-73db-4194-998c-8b9157c7ee0a"), new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"), 12, 180m, new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95") },
                    { new Guid("f439526b-ac56-4fd9-96eb-611139b50ca0"), new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"), 10, 100m, new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95") }
                });

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                column: "CreatedOn",
                value: new DateTime(2024, 10, 21, 22, 10, 38, 528, DateTimeKind.Local).AddTicks(4266));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7"),
                column: "Date",
                value: new DateTime(2024, 10, 21, 22, 10, 38, 537, DateTimeKind.Local).AddTicks(966));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                column: "Date",
                value: new DateTime(2024, 10, 21, 22, 10, 38, 537, DateTimeKind.Local).AddTicks(351));
        }
    }
}
