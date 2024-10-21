using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthApp_Backend.Migrations
{
    /// <inheritdoc />
    public partial class yfgtvjufg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("71fadf70-8ca6-4814-b1f7-a6da47b6ee02"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("9d4ee9b0-373e-4981-8b3e-4750ed8b1ef5"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("d7405b89-f795-4ef1-b65f-18039027710a"));

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("3745a942-5712-4e8c-ac0d-a2f556a02472"));

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("581d8fc0-e9c8-4fe3-af8d-df303c45e86f"));

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("618be680-8e2f-463f-8781-b3413b60ee1d"));

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("b2bff8d9-ee37-4777-b543-24781a32a53c"));

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: new Guid("e6df3ea2-bc5e-411d-a41c-7a7438580628"));

            migrationBuilder.AddColumn<Guid>(
                name: "userId",
                table: "Workouts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "userId",
                table: "Sets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "userId",
                table: "Exercises",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Exercises");

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Name", "WorkoutId" },
                values: new object[,]
                {
                    { new Guid("71fadf70-8ca6-4814-b1f7-a6da47b6ee02"), "Bench Press", new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7") },
                    { new Guid("9d4ee9b0-373e-4981-8b3e-4750ed8b1ef5"), "Leg Press", new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7") },
                    { new Guid("d7405b89-f795-4ef1-b65f-18039027710a"), "Shoulder Press", new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7") }
                });

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

            migrationBuilder.UpdateData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                column: "CreatedOn",
                value: new DateTime(2024, 10, 21, 21, 47, 41, 670, DateTimeKind.Local).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7"),
                column: "Date",
                value: new DateTime(2024, 10, 21, 21, 47, 41, 679, DateTimeKind.Local).AddTicks(1249));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                column: "Date",
                value: new DateTime(2024, 10, 21, 21, 47, 41, 679, DateTimeKind.Local).AddTicks(775));
        }
    }
}
