using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FlowerWeb_APP.Data;
using FlowerWeb_APP.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FlowerWeb_APPContextConnection") ?? throw new InvalidOperationException("Connection string 'FlowerWeb_APPContextConnection' not found.");

builder.Services.AddDbContext<FlowerWeb_APPContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<FlowerWeb_APPUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<FlowerWeb_APPContext>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
