using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TaskManagement_API.Entities;
using TaskManagement_API.Profiles;
using TaskManagement_API.Repositories;
using TaskManagement_API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(config => config.AddProfile<TaskProfile>());
builder.Services.AddControllers();
builder.Services.AddOpenApi();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
