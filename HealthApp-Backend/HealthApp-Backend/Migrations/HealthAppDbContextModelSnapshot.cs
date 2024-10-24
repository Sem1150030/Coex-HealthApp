﻿// <auto-generated />
using System;
using HealthApp_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthApp_Backend.Migrations
{
    [DbContext(typeof(HealthAppDbContext))]
    partial class HealthAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.1.24451.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HealthApp_Backend.Models.DomainModels.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutId");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"),
                            Name = "Squat",
                            WorkoutId = new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                            userId = new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95")
                        },
                        new
                        {
                            Id = new Guid("4b2cf595-b031-4602-82e5-869f58e84ab7"),
                            Name = "Leg Press",
                            WorkoutId = new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                            userId = new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95")
                        });
                });

            modelBuilder.Entity("HealthApp_Backend.Models.DomainModels.FoodItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("carbAmount")
                        .HasColumnType("real");

                    b.Property<float>("fatAmount")
                        .HasColumnType("real");

                    b.Property<int>("kcalAmount")
                        .HasColumnType("int");

                    b.Property<string>("measurement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("proteinAmount")
                        .HasColumnType("real");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("FoodItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                            carbAmount = 0f,
                            fatAmount = 0f,
                            kcalAmount = 52,
                            measurement = "100g",
                            name = "Apple",
                            proteinAmount = 0.3f,
                            userId = new Guid("3b2dc595-b071-4602-82e5-869f58e84ab7")
                        },
                        new
                        {
                            Id = new Guid("4eae13c3-408a-42e0-b334-d61c9ad99077"),
                            carbAmount = 0f,
                            fatAmount = 0f,
                            kcalAmount = 89,
                            measurement = "100g",
                            name = "Banana",
                            proteinAmount = 1.1f,
                            userId = new Guid("3b2dc595-b071-4602-82e5-869f58e84ab7")
                        });
                });

            modelBuilder.Entity("HealthApp_Backend.Models.DomainModels.Set", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Sets");

                    b.HasData(
                        new
                        {
                            Id = new Guid("77c30cd7-4881-479d-b6c9-3798a0a49666"),
                            ExerciseId = new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"),
                            Reps = 10,
                            Weight = 100m,
                            userId = new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95")
                        },
                        new
                        {
                            Id = new Guid("d42fe59f-bf98-4648-aafe-00f04ce4ecdc"),
                            ExerciseId = new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"),
                            Reps = 8,
                            Weight = 110m,
                            userId = new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95")
                        },
                        new
                        {
                            Id = new Guid("b66fd2d1-e74e-4697-8a1d-d8eb5296f865"),
                            ExerciseId = new Guid("4b2cf595-b031-4602-82e5-869f58e84ab7"),
                            Reps = 12,
                            Weight = 180m,
                            userId = new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95")
                        },
                        new
                        {
                            Id = new Guid("fad149dc-a195-4ebb-9342-b18ef781d90c"),
                            ExerciseId = new Guid("4b2cf595-b031-4602-82e5-869f58e84ab7"),
                            Reps = 10,
                            Weight = 190m,
                            userId = new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95")
                        });
                });

            modelBuilder.Entity("HealthApp_Backend.Models.DomainModels.ShoppingList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("KcalGoal")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("carbCurrent")
                        .HasColumnType("real");

                    b.Property<int>("carbGoal")
                        .HasColumnType("int");

                    b.Property<float>("fatCurrent")
                        .HasColumnType("real");

                    b.Property<int>("fatGoal")
                        .HasColumnType("int");

                    b.Property<int>("kcalCurrent")
                        .HasColumnType("int");

                    b.Property<bool>("kcalMax")
                        .HasColumnType("bit");

                    b.Property<float>("proteinCurrent")
                        .HasColumnType("real");

                    b.Property<int>("proteinGoal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ShoppingLists");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                            CreatedOn = new DateTime(2024, 10, 21, 22, 31, 45, 508, DateTimeKind.Local).AddTicks(7015),
                            KcalGoal = 2000,
                            UserId = new Guid("3b2cd595-b071-4602-82e5-869f58e84ab7"),
                            carbCurrent = 0f,
                            carbGoal = 0,
                            fatCurrent = 0f,
                            fatGoal = 0,
                            kcalCurrent = 0,
                            kcalMax = true,
                            proteinCurrent = 0f,
                            proteinGoal = 100
                        });
                });

            modelBuilder.Entity("HealthApp_Backend.Models.DomainModels.ShoppingListFoodItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FoodItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShoppingListId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FoodItemId");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("ShoppingListFoodItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f77c44d8-7318-4d81-9bd3-cfe6630d3020"),
                            FoodItemId = new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                            ShoppingListId = new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7")
                        });
                });

            modelBuilder.Entity("HealthApp_Backend.Models.DomainModels.WeightTracker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.Property<float>("WeightGoal")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("WeightTrackers");
                });

            modelBuilder.Entity("HealthApp_Backend.Models.DomainModels.Workout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Workouts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                            Date = new DateTime(2024, 10, 21, 8, 30, 0, 0, DateTimeKind.Utc),
                            Name = "Leg Day",
                            userId = new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95")
                        },
                        new
                        {
                            Id = new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7"),
                            Date = new DateTime(2024, 10, 21, 22, 31, 45, 517, DateTimeKind.Local).AddTicks(2194),
                            Name = "Push Day",
                            userId = new Guid("ba904875-a7f0-4ab4-8da6-6fe117aecf95")
                        });
                });

            modelBuilder.Entity("HealthApp_Backend.Models.DomainModels.Exercise", b =>
                {
                    b.HasOne("HealthApp_Backend.Models.DomainModels.Workout", null)
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthApp_Backend.Models.DomainModels.Set", b =>
                {
                    b.HasOne("HealthApp_Backend.Models.DomainModels.Exercise", null)
                        .WithMany("Sets")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthApp_Backend.Models.DomainModels.ShoppingListFoodItem", b =>
                {
                    b.HasOne("HealthApp_Backend.Models.DomainModels.FoodItem", "FoodItem")
                        .WithMany("ShoppingListFoodItems")
                        .HasForeignKey("FoodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthApp_Backend.Models.DomainModels.ShoppingList", "ShoppingList")
                        .WithMany("ShoppingListFoodItems")
                        .HasForeignKey("ShoppingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodItem");

                    b.Navigation("ShoppingList");
                });

            modelBuilder.Entity("HealthApp_Backend.Models.DomainModels.Exercise", b =>
                {
                    b.Navigation("Sets");
                });

            modelBuilder.Entity("HealthApp_Backend.Models.DomainModels.FoodItem", b =>
                {
                    b.Navigation("ShoppingListFoodItems");
                });

            modelBuilder.Entity("HealthApp_Backend.Models.DomainModels.ShoppingList", b =>
                {
                    b.Navigation("ShoppingListFoodItems");
                });

            modelBuilder.Entity("HealthApp_Backend.Models.DomainModels.Workout", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}