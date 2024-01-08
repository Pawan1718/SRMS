using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // Added for IConfiguration
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using SRMS.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

// Access configuration directly from builder
var config = builder.Configuration;

// Use a single connection string for simplicity
var connectionString = config.GetConnectionString("DBCS");

builder.Services.AddDbContext<AdminDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ClassDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<SubjectDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

