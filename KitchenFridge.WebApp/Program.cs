
using KitchenFridge.DB;
using KitchenFridge.DB.Repository;
using KitchenFridge.DB.Repository.Interfaces;
using KitchenFridge.Services.Interfaces;
using KitchenFridge.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IFridgesService, FridgesService>();
builder.Services.AddScoped<IFridgeRepository, FridgeRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddDbContext<KitchenFridgeContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
