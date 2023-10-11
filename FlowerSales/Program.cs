using FlowerSales.Models;
using Microsoft.EntityFrameworkCore;
using FlowerSales.Services;
using MongoDB.Driver;
using MongoDB.Bson;


var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));
builder.Services.AddSingleton<MongoDBContext>();


//Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Useless for current project as it is a modelseedbuilder SQL database
builder.Services.AddDbContext<FlowerDBContext>(options =>
{
    options.UseInMemoryDatabase("FlowerShop");
});

var app = builder.Build();

// initialise FlowerDBSeed for the first time and execute method SeedProductsIfNotExists()
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var flowerDBSeed = services.GetRequiredService<FlowerDBSeed>();
    flowerDBSeed.SeedProductsIfNotExists();
}

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
