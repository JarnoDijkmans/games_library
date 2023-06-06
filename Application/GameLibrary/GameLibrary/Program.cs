using DataLayer.DAL;
using LogicLayer.Interfaces;
using LogicLayer.Models.CheckoutRelated;
using LogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<IDiscountDAL, DiscountDAL>();
builder.Services.AddScoped<IDiscountFactory, DiscountFactory>();
builder.Services.AddScoped<ICheckoutDAL, CheckoutDAL>();
builder.Services.AddScoped<CheckoutService>();


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
app.UseSession();

app.UseAuthorization();

app.MapControllers(); 
app.MapRazorPages();

app.Run();
