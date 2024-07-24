using PriceLists.Common.Routing;

var builder = WebApplication.CreateBuilder(args);

if (builder.Configuration["PRICELISTS_API_HTTPS_HOST"] is null)
{
    throw new ArgumentNullException(
        "ƒл€ работы приложени€ необходимо объ€вить переменную окружени€ PRICELISTS_API_HTTPS_HOST, котора€ содержит url необходимого API.");
}

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRouting(routeOptions => routeOptions.ConstraintMap["slugify"] = typeof(SlugifyParameterTransformer));

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
