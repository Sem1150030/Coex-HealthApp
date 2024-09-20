using HealthApp_Backend.Data;
using HealthApp_Backend.mappings;
using HealthApp_Backend.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HealthAppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("HealthAppConnectionStrings")));

builder.Services.AddScoped<IShoppingListrepository, SQLShoppingListRepository>();
builder.Services.AddScoped<IFoodItemRepository, SQLFoodItemRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
