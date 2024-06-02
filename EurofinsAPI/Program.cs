//Luke Boyd
using Microsoft.EntityFrameworkCore;
//Luke Boyd
using EurofinsAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Luke Boyd
builder.Services.AddDbContext<EurofinsDbContext>(options => options.UseInMemoryDatabase("EurofinsDb"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Luke Boyd 
app.UseDefaultFiles();
//Luke Boyd
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
