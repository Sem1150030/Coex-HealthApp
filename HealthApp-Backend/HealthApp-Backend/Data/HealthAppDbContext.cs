using HealthApp_Backend.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace HealthApp_Backend.Data
{
    public class HealthAppDbContext : DbContext
    {
        public HealthAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<WeightTracker> WeightTrackers { get; set; }
        public DbSet<ShoppingListFoodItem> ShoppingListFoodItems { get; set; } // Add this line for the junction table
            
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("YourConnectionStringHere")
                .ConfigureWarnings(warnings => warnings
                    .Ignore(RelationalEventId.PendingModelChangesWarning));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            var foodItems = new List<FoodItem>()
            {
                new FoodItem()
                {
                    Id = Guid.Parse("3B2CC595-B071-4602-82E5-869F58E84AB7"),
                    name = "Apple",
                    kcalAmount = 52,
                    proteinAmount = 0.3f,
                    measurement = "100g",
                    userId = Guid.Parse("3B2DC595-B071-4602-82E5-869F58E84AB7")
                },
                new FoodItem()
                {
                    Id = Guid.Parse("4EAE13C3-408A-42E0-B334-D61C9AD99077"),
                    name = "Banana",
                    kcalAmount = 89,
                    proteinAmount = 1.1f,
                    measurement = "100g",
                    userId = Guid.Parse("3B2DC595-B071-4602-82E5-869F58E84AB7")
                },
                new FoodItem()
                {
                    Id = Guid.Parse("DBAF0F17-3886-4954-A093-C0872FB3C8C1"),
                    name = "Orange",
                    kcalAmount = 47,
                    proteinAmount = 1.0f,
                    measurement = "100g",
                    userId = Guid.Parse("3B2DC595-B071-4602-82E5-869F58E84AB7")
                },
                new FoodItem()
                {
                    Id = Guid.Parse("75BBD1BB-9B67-40AD-BAC4-C38FDBF86C02"),
                    name = "Pineapple",
                    kcalAmount = 50,
                    proteinAmount = 0.5f,
                    measurement = "100g",
                    userId = Guid.Parse("3B2CD595-B071-4602-82E5-869F58E84AB7")
                },
            };
            modelBuilder.Entity<FoodItem>().HasData(foodItems);
    
            var shoppingLists = new List<ShoppingList>()
            {
                new ShoppingList()
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
                new ShoppingList()
                {
                    Id = Guid.Parse("4EAE13C3-408A-42E0-B334-D61C9AD99077"),
                    CreatedOn = DateTime.Now,
                    UserId = Guid.Parse("3B2CD595-B071-4602-82E5-869F58E84AB7"),
                    KcalGoal = 2000,
                    proteinGoal = 100,
                    kcalMax = true,
                    proteinCurrent = 0,
                    kcalCurrent = 0
                },
                new ShoppingList()
                {
                    Id = Guid.Parse("DBAF0F17-3886-4954-A093-C0872FB3C8C1"),
                    CreatedOn = DateTime.Now,
                    UserId = Guid.Parse("3B2CD595-B071-4602-82E5-869F58E84AB7"),
                    KcalGoal = 2000,
                    proteinGoal = 100,
                    kcalMax = true,
                    proteinCurrent = 0,
                    kcalCurrent = 0
                },
                new ShoppingList()
                {
                    Id = Guid.Parse("75BBD1BB-9B67-40AD-BAC4-C38FDBF86C02"),
                    CreatedOn = DateTime.Now,
                    UserId = Guid.Parse("3B2CD595-B071-4602-82E5-869F58E84AB7"),
                    KcalGoal = 2000,
                    proteinGoal = 100,
                    kcalMax = true,
                    proteinCurrent = 0,
                    kcalCurrent = 0
                },
            };
            modelBuilder.Entity<ShoppingList>().HasData(shoppingLists);
            
            // Seeding the junction table
            var shoppingListFoodItems = new List<ShoppingListFoodItem>()
            {
                new ShoppingListFoodItem
                {
                    Id = Guid.Parse("F77C44D8-7318-4D81-9BD3-CFE6630D3020"),
            
                    ShoppingListId = Guid.Parse("3B2CC595-B071-4602-82E5-869F58E84AB7"),
                    FoodItemId = Guid.Parse("3B2CC595-B071-4602-82E5-869F58E84AB7"),
                   
                },
                new ShoppingListFoodItem
                {
                    Id = Guid.Parse("0CE05FB2-B587-480A-B7E9-27F6CC22C760"),
            
                    ShoppingListId = Guid.Parse("3B2CC595-B071-4602-82E5-869F58E84AB7"),
                    FoodItemId = Guid.Parse("4EAE13C3-408A-42E0-B334-D61C9AD99077"),
                },
                new ShoppingListFoodItem
                {
                    Id = Guid.Parse("B9ABD736-8817-4117-ABCC-C4F320B8FE71"),
            
                    ShoppingListId = Guid.Parse("4EAE13C3-408A-42E0-B334-D61C9AD99077"),
                    FoodItemId = Guid.Parse("DBAF0F17-3886-4954-A093-C0872FB3C8C1"),
                },
                new ShoppingListFoodItem
                {
                    Id = Guid.Parse("D15CE629-15AD-4675-B5A1-2D3867E55B8F"),
                    ShoppingListId = Guid.Parse("75BBD1BB-9B67-40AD-BAC4-C38FDBF86C02"),
                    FoodItemId = Guid.Parse("75BBD1BB-9B67-40AD-BAC4-C38FDBF86C02"),
                },
            };
            modelBuilder.Entity<ShoppingListFoodItem>().HasData(shoppingListFoodItems);
        }
    }
}
