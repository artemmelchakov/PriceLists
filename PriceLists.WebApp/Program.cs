using Microsoft.EntityFrameworkCore;
using PriceLists.Data;
using PriceLists.WebApp.Routing;
using System.Globalization;
using AppContext = PriceLists.Data.AppContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRouting(routeOptions => routeOptions.ConstraintMap["slugify"] = typeof(SlugifyParameterTransformer));

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
    app.UseExceptionHandler("/home/error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller:slugify=PriceList}/{action:slugify=GetAll}/{id?}");

app.Run();
