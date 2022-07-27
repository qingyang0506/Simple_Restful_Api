using Simple_Restful_Api.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//configure the sqlite
var connectionString = builder.Configuration.GetConnectionString("Employees") ?? "Data Source=Employees.db";
builder.Services.AddSqlite<EmployeeDb>(connectionString);
//get the client name from the configuration file
string name = builder.Configuration["DigimonClientName"];
//get the third party restful api url from the configuration file
string url = builder.Configuration["DigimonAddress"];
builder.Services.AddHttpClient(name, client =>
{
    client.BaseAddress = new Uri(url);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

