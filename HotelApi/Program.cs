using HotelApi.DAL;
using HotelApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Db");

builder.Services.AddControllers()
    .AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContextFactory<HotelContext>(opt =>
    opt.UseSqlServer(connectionString,
       x => x.MigrationsAssembly("Migrations")));

builder.Services.AddScoped<UnitOfWork>();

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

using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
var db = scope.ServiceProvider.GetRequiredService<HotelContext>();
db.Database.EnsureCreated();
DbInitializer.Initialize(db);

app.Run();
