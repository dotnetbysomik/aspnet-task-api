using aspnet_task_api.Data;
using aspnet_task_api.Filters;
using aspnet_task_api.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add database support
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers(options => {
    options.Filters.Add<FluentValidationActionFilter>();
});

builder.Services.AddValidatorsFromAssemblyContaining<TaskCreateValidator>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add code documentation support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add mapping support between models and DTOs
builder.Services.AddAutoMapper(_ => { }, typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
