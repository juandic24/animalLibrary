using AnimalLibrary.Data;
using AnimalLibrary.Interfaces.Repositories;
using AnimalLibrary.Interfaces.Services;
using AnimalLibrary.Repositories;
using AnimalLibrary.Services;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using Npgsql.EntityFrameworkCore.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

//Adding db context reference
builder.AddAnimalLibraryDB();

// DI: when someone asks for IAnimalRepository, give them AnimalRepository
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();

// DI: when someone asks for IAnimalService, give them AnimalService
builder.Services.AddScoped<IAnimalService, AnimalService>();

// DI: when someone asks for IAnimalRepository, give them AnimalRepository
builder.Services.AddScoped<IGroupRepository, GroupRepository>();

// DI: when someone asks for IAnimalService, give them AnimalService
builder.Services.AddScoped<IGroupService, GroupService>();



var app = builder.Build();

//Migrate and seed the db

app.MigrateAndSeedDb();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
