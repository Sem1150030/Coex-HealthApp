using Microsoft.EntityFrameworkCore;

namespace HealthApp_Backend.Data;

public class HealthAppDbContext: DbContext
{
    public HealthAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }
    
    public DbSet<ShoppingList> 
}