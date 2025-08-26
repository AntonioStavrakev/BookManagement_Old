using BookManagement.Core.DTOs.BookDTOs;
using BookManagement.Core.Repositories;
using BookManagement.Infrastructure.Configurations;
using BookManagement.Infrastructure.Entities;
using BookManagement.Infrastructure.Repositories;
using BookManagement.Services.Helpers.Configurations;
using BookManagement.Services.Helpers.Profiles;
using BookManagement.Services.Helpers.Validators;
using BookManagement.Services.Models.AuthorModels.DTOs;
using BookManagement.Services.Models.AuthorModels.Interfaces;
using BookManagement.Services.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookManagementDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 37))
    ));

builder.Services.AddServices();
builder.Services.AddRepositories();


builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BookGeneralDTO>());


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
