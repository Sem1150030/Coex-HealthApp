﻿// <auto-generated />
using System;
using HealthApp_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthApp_Backend.Migrations
{
    [DbContext(typeof(HealthAppDbContext))]
    [Migration("20241021194742_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.HasKey("Id");

                    b.HasIndex("WorkoutId");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"),
                            Name = "Squat",
                            WorkoutId = new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7")
                        },
                        new
                        {
                            Id = new Guid("9d4ee9b0-373e-4981-8b3e-4750ed8b1ef5"),
                            Name = "Leg Press",
                            WorkoutId = new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7")
                        },
                        new
                        {
                            Id = new Guid("71fadf70-8ca6-4814-b1f7-a6da47b6ee02"),
                            Name = "Bench Press",
                            WorkoutId = new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7")
                        },
                        new
                        {
                            Id = new Guid("d7405b89-f795-4ef1-b65f-18039027710a"),
                            Name = "Shoulder Press",
                            WorkoutId = new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7")
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

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Sets");

                    b.HasData(
                        new
                        {
                            Id = new Guid("581d8fc0-e9c8-4fe3-af8d-df303c45e86f"),
                            ExerciseId = new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"),
                            Reps = 10,
                            Weight = 100m
                        },
                        new
                        {
                            Id = new Guid("b2bff8d9-ee37-4777-b543-24781a32a53c"),
                            ExerciseId = new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"),
                            Reps = 8,
                            Weight = 110m
                        },
                        new
                        {
                            Id = new Guid("618be680-8e2f-463f-8781-b3413b60ee1d"),
                            ExerciseId = new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"),
                            Reps = 12,
                            Weight = 180m
                        },
                        new
                        {
                            Id = new Guid("e6df3ea2-bc5e-411d-a41c-7a7438580628"),
                            ExerciseId = new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"),
                            Reps = 8,
                            Weight = 85m
                        },
                        new
                        {
                            Id = new Guid("3745a942-5712-4e8c-ac0d-a2f556a02472"),
                            ExerciseId = new Guid("3b2cf595-b021-4602-82e5-869f58e84ab7"),
                            Reps = 10,
                            Weight = 60m
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
                            CreatedOn = new DateTime(2024, 10, 21, 21, 47, 41, 670, DateTimeKind.Local).AddTicks(3768),
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

                    b.HasKey("Id");

                    b.ToTable("Workouts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3b2cc595-b071-4602-82e5-869f58e84ab7"),
                            Date = new DateTime(2024, 10, 21, 21, 47, 41, 679, DateTimeKind.Local).AddTicks(775),
                            Name = "Leg Day"
                        },
                        new
                        {
                            Id = new Guid("3b2cc595-b051-4602-82e5-869f58e84ab7"),
                            Date = new DateTime(2024, 10, 21, 21, 47, 41, 679, DateTimeKind.Local).AddTicks(1249),
                            Name = "Push Day"
                        });
                });

            modelBuilder.Entity("HealthApp_Backend.Models.DomainModels.Exercise", b =>
                {
                    b.HasOne("HealthApp_Backend.Models.DomainModels.Workout", "Workout")
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("HealthApp_Backend.Models.DomainModels.Set", b =>
                {
                    b.HasOne("HealthApp_Backend.Models.DomainModels.Exercise", "Exercise")
                        .WithMany("Sets")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
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