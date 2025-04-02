using StudentManagement.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StudentContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Swaggerin aktivointi
builder.Services.AddSwaggerGen();          // Swaggerin aktivointi

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();                      // Swaggerin käyttö
    app.UseSwaggerUI();                    // Swaggerin käyttö
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
