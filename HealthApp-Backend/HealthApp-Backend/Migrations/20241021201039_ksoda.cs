using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthApp_Backend.Migrations
{
    /// <inheritdoc />
    public partial class ksoda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("2c1aaf25-c561-498b-aa77-99afb8898459"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("bf9c4825-ac49-41df-801d-339d06d0c02f"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("f364571b-265a-434b-9d31-490c9cd35429"));

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("87ceef55-75a6-4a4f-a2cd-f8e069791bc4"));

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("db34579a-c03a-4c22-a4c8-3573ebdcaa2a"));

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("f12304f0-6dbb-4fb0-a6ac-171384be2ea2"));

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("f5b5947b-4d18-4b30-943a-b447de715320"));

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("fd77fb28-b808-444e-91a8-3cb59517426c"));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"),
                column: "userId",
                value: new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95"));

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
                columns: new[] { "Date", "userId" },
                values: new object[] { new DateTime(2024, 10, 21, 22, 10, 38, 537, DateTimeKind.Local).AddTicks(966), new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95") });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                columns: new[] { "Date", "userId" },
                values: new object[] { new DateTime(2024, 10, 21, 22, 10, 38, 537, DateTimeKind.Local).AddTicks(351), new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "userId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Name", "WorkoutId", "userId" },
                values: new object[,]
                {
                    { new Guid("2c1aaf25-c561-498b-aa77-99afb8898459"), "Leg Press", new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("bf9c4825-ac49-41df-801d-339d06d0c02f"), "Bench Press", new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("f364571b-265a-434b-9d31-490c9cd35429"), "Shoulder Press", new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7"), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "Id", "ExerciseId", "Reps", "Weight", "userId" },
                values: new object[,]
                {
                    { new Guid("87ceef55-75a6-4a4f-a2cd-f8e069791bc4"), new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"), 10, 100m, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("db34579a-c03a-4c22-a4c8-3573ebdcaa2a"), new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"), 12, 180m, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("f12304f0-6dbb-4fb0-a6ac-171384be2ea2"), new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"), 8, 110m, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("f5b5947b-4d18-4b30-943a-b447de715320"), new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"), 8, 85m, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("fd77fb28-b808-444e-91a8-3cb59517426c"), new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"), 10, 60m, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                column: "CreatedOn",
                value: new DateTime(2024, 10, 21, 21, 54, 25, 240, DateTimeKind.Local).AddTicks(5141));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7"),
                columns: new[] { "Date", "userId" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 54, 25, 250, DateTimeKind.Local).AddTicks(3422), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                columns: new[] { "Date", "userId" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 54, 25, 250, DateTimeKind.Local).AddTicks(3040), new Guid("00000000-0000-0000-0000-000000000000") });
        }
    }
}
