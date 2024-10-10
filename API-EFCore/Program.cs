using API_EFCore.BLL.Interfaces;
using API_EFCore.BLL.Services;
using API_EFCore.DAL.DataAccess;
using API_EFCore.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// préciser project pour commandes migrations : 
// - dotnet ef migrations add InitialCreate --startup-project API-EFCore --project API-EFCore.DAL --output-dir migrations
// - dotnet ef database update --startup-project API-EFCore --project API-EFCore.DAL
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookRepository, BookService>();
builder.Services.AddScoped<IBookBLLRepository, BookBLLService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
