
using KitchenFridge.DB;
using KitchenFridge.DB.Repository;
using KitchenFridge.DB.Repository.Interfaces;
using KitchenFridge.Services.Interfaces;
using KitchenFridge.Services.Services;
using KitchenFridge.WebApp;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefoultConnection");


builder.Services.AddScoped<IFridgesService, FridgesService>();
builder.Services.AddScoped<IFridgeRepository, FridgeRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IRecipesService, RecipesService>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddDbContext<KitchenFridgeContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
