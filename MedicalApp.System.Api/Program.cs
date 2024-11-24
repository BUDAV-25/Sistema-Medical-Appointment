using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.system;
using MedicalAppointment.Persistance.Repositories.system;
using Microsoft.EntityFrameworkCore;
using MedicalAppointment.IOC.Dependencies.system;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MedicalAppointment.Application.Contracts.system;
using MedicalAppointment.Application.Services.System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MedicalAppointmentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalDB")));


// El registro de cada una de las dependencias 

builder.Services.AddHttpClient();
builder.Services.AddSystemDependency();


builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
