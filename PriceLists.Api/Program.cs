using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using PriceLists.Common.Routing;
using PriceLists.Data;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(mvcOptions => mvcOptions.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer())));

builder.Services.AddDbContext<PriceListsContext>(dbContextOptionsBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString("PriceListsDb");
    dbContextOptionsBuilder.UseSqlServer(connectionString).UseSnakeCaseNamingConvention(CultureInfo.InvariantCulture);
});
builder.Services.AddScoped<IPriceListsRepository, PriceListsRepository>();

builder.Services.AddAutoMapper(mapperConfigurationExpression => mapperConfigurationExpression.AddMaps(Assembly.GetExecutingAssembly()));

builder.Services.AddCors(corsOptions =>
{
    corsOptions.AddDefaultPolicy(corsPolicyBuilder =>
    {
        corsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
