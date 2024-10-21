using HealthApp_Backend.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;

namespace HealthApp_Backend.Data
{
    public class HealthAppDbContext : DbContext
    {
        public HealthAppDbContext(DbContextOptions<HealthAppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        // DbSets
        public DbSet<ShoppingListFoodItem> ShoppingListFoodItems { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<WeightTracker> WeightTrackers { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Set> Sets { get; set; }
        //
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder
        //         .UseSqlServer("HealthAppConnectionStrings")
        //         .ConfigureWarnings(warnings => warnings
        //             .Ignore(RelationalEventId.PendingModelChangesWarning));
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Existing seed data for FoodItem
            var foodItems = new List<FoodItem>
            {
                new FoodItem
                {
                    Id = Guid.Parse("3B2CC595-B071-4602-82E5-869F58E84AB7"),
                    name = "Apple",
                    kcalAmount = 52,
                    proteinAmount = 0.3f,
                    measurement = "100g",
                    userId = Guid.Parse("3B2DC595-B071-4602-82E5-869F58E84AB7")
                },
                new FoodItem
                {
                    Id = Guid.Parse("4EAE13C3-408A-42E0-B334-D61C9AD99077"),
                    name = "Banana",
                    kcalAmount = 89,
                    proteinAmount = 1.1f,
                    measurement = "100g",
                    userId = Guid.Parse("3B2DC595-B071-4602-82E5-869F58E84AB7")
                },
                // More seed data...
            };
            modelBuilder.Entity<FoodItem>().HasData(foodItems);

            // Existing seed data for ShoppingList
            var shoppingLists = new List<ShoppingList>
            {
                new ShoppingList
                {
                    Id = Guid.Parse("3B2CC595-B071-4602-82E5-869F58E84AB7"),
                    CreatedOn = DateTime.Now,
                    UserId = Guid.Parse("3B2CD595-B071-4602-82E5-869F58E84AB7"),
                    KcalGoal = 2000,
                    proteinGoal = 100,
                    kcalMax = true,
                    proteinCurrent = 0,
                    kcalCurrent = 0
                },
                // More seed data...
            };
            modelBuilder.Entity<ShoppingList>().HasData(shoppingLists);

            // Existing seed data for ShoppingListFoodItem
            var shoppingListFoodItems = new List<ShoppingListFoodItem>
            {
                new ShoppingListFoodItem
                {
                    Id = Guid.Parse("F77C44D8-7318-4D81-9BD3-CFE6630D3020"),
                    ShoppingListId = Guid.Parse("3B2CC595-B071-4602-82E5-869F58E84AB7"),
                    FoodItemId = Guid.Parse("3B2CC595-B071-4602-82E5-869F58E84AB7"),
                },
                // More seed data...
            };
            modelBuilder.Entity<ShoppingListFoodItem>().HasData(shoppingListFoodItems);

            // Define composite key using ShoppingListId and FoodItemId
            modelBuilder.Entity<ShoppingListFoodItem>()
                .Property(slfi => slfi.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<ShoppingListFoodItem>()
                .HasOne(slfi => slfi.ShoppingList)
                .WithMany(sl => sl.ShoppingListFoodItems)
                .HasForeignKey(slfi => slfi.ShoppingListId);

            modelBuilder.Entity<ShoppingListFoodItem>()
                .HasOne(slfi => slfi.FoodItem)
                .WithMany(fi => fi.ShoppingListFoodItems)
                .HasForeignKey(slfi => slfi.FoodItemId);

            // Seed data for Workout
            var workouts = new List<Workout>
            {
                new Workout
                {
                    Id = Guid.Parse("3B2CC595-B071-4602-82E5-869F58E84AB7"),
                    Name = "Leg Day",
                    Date = new DateTime(2024, 10, 21, 8, 30, 0, DateTimeKind.Utc),
                    userId = Guid.Parse("ba904875-a7f0-4ab4-8da6-6fe117aecf95")
                },
                new Workout
                {
                    Id = Guid.Parse("3B2CC595-B051-4602-82E5-869F58E84AB7"),
                    Name = "Push Day",
                    Date = DateTime.Now,
                    userId = Guid.Parse("ba904875-a7f0-4ab4-8da6-6fe117aecf95")
                }
            };
            modelBuilder.Entity<Workout>().HasData(workouts);

            // Seed data for Exercise
            var exercises = new List<Exercise>
            {
                new Exercise
                {
                    Id = Guid.Parse("3B2CF595-B021-4602-82E5-869F58E84AB7"),
                    Name = "Squat",
                    WorkoutId = Guid.Parse("3B2CC595-B071-4602-82E5-869F58E84AB7"), // Links to Leg Day
                    userId = Guid.Parse("ba904875-a7f0-4ab4-8da6-6fe117aecf95")
                },
                new Exercise
                {
                    Id = Guid.Parse("4B2CF595-B031-4602-82E5-869F58E84AB7"),
                    Name = "Leg Press",
                    WorkoutId = Guid.Parse("3B2CC595-B071-4602-82E5-869F58E84AB7"), // Links to Leg Day
                    userId = Guid.Parse("ba904875-a7f0-4ab4-8da6-6fe117aecf95")
                }
            };
            modelBuilder.Entity<Exercise>().HasData(exercises);

            // Seed data for Set
            var sets = new List<Set>
            {
                new Set
                {
                    Id = Guid.NewGuid(),
                    Reps = 10,
                    Weight = 100,
                    ExerciseId = Guid.Parse("3B2CF595-B021-4602-82E5-869F58E84AB7"), // Squat
                    userId = Guid.Parse("ba904875-a7f0-4ab4-8da6-6fe117aecf95")
                },
                new Set
                {
                    Id = Guid.NewGuid(),
                    Reps = 8,
                    Weight = 110,
                    ExerciseId = Guid.Parse("3B2CF595-B021-4602-82E5-869F58E84AB7"), // Squat
                    userId = Guid.Parse("ba904875-a7f0-4ab4-8da6-6fe117aecf95")
                },
                new Set
                {
                    Id = Guid.NewGuid(),
                    Reps = 12,
                    Weight = 180,
                    ExerciseId = Guid.Parse("4B2CF595-B031-4602-82E5-869F58E84AB7"), // Leg Press
                    userId = Guid.Parse("ba904875-a7f0-4ab4-8da6-6fe117aecf95")
                },
                new Set
                {
                    Id = Guid.NewGuid(),
                    Reps = 10,
                    Weight = 190,
                    ExerciseId = Guid.Parse("4B2CF595-B031-4602-82E5-869F58E84AB7"), // Leg Press
                    userId = Guid.Parse("ba904875-a7f0-4ab4-8da6-6fe117aecf95")
                }
            };
            modelBuilder.Entity<Set>().HasData(sets);
        }
    }
}
