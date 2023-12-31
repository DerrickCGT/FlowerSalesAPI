using FlowerSales.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Versioning;
using FlowerSales.Services;
using MongoDB.Driver;
using MongoDB.Bson;


var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));
builder.Services.AddSingleton<MongoDBContext>();

builder.Services.AddScoped<FlowerDBSeed>();

//Add services to the container.
builder.Services.AddControllers();

//Create API versioning with Header
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;

    //options.ApiVersionReader = new QueryStringApiVersionReader("FlowerMongo-Api-Version");

    options.ApiVersionReader = new HeaderApiVersionReader("X-API-version");
});

//Create API versioning format
builder.Services.AddVersionedApiExplorer(options =>
{   // this says we have V and then the version number
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Implement Cross Origin Resource Sharing (CORS)
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:7129").WithHeaders("X-API-version");
    });
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
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
