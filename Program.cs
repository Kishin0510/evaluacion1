using evaluacion1.Src.Data;
using evaluacion1.Src.Models;
using evaluacion1.Src.Repositories;
using evaluacion1.Src.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite("Data Source=ejemplo.db");
});
builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await Seeder.Seed(context);
}

app.MapControllers();
app.Run();

