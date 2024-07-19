using Microsoft.EntityFrameworkCore;
using PriceLists.Data;
using System.Globalization;
using AppContext = PriceLists.Data.AppContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppContext>(dbContextOptionsBuilder => 
{
    var connectionString = builder.Configuration.GetConnectionString("PriceListsDb");
    dbContextOptionsBuilder.UseSqlServer(connectionString).UseSnakeCaseNamingConvention(CultureInfo.InvariantCulture);
});
builder.Services.AddScoped<IRepository, AppRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
