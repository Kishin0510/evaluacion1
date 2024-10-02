using evaluacion1.Src.Data;
using evaluacion1.Src.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite("Data Source=ejemplo.db");
});


var app = builder.Build();


app.UseHttpsRedirection();


app.Run();

