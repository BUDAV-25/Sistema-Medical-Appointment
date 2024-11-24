using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Application.Contracts.medical;
using MedicalAppointment.Application.Contracts.system;
using MedicalAppointment.Application.Contracts.users;
using MedicalAppointment.Application.Services.medical;
using MedicalAppointment.Application.Services.System;
using MedicalAppointment.Application.Services.users;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.medical;
using MedicalAppointment.Persistance.Interfaces.system;
using MedicalAppointment.Persistance.Interfaces.users;
using MedicalAppointment.Persistance.Repositories.medical;
using MedicalAppointment.Persistance.Repositories.system;
using MedicalAppointment.Persistance.Repositories.users;
using Microsoft.EntityFrameworkCore;
using MedicalAppointment.IOC.Dependencies.system;
using MedicalAppointment.IOC.Dependencies.appointmens;
using MedicalAppointment.Consumption.ServicesConsumption.system;
using MedicalAppointment.Consumption.Base;
using MedicalAppointment.Consumption.IClientService.system;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddDbContext<MedicalAppointmentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalDB")));

// Dependencia del esquema system
builder.Services.AddSystemDependency();

// Dendencia del esquema appointments
builder.Services.AddAppointmentsDependency();

// Constructor HttpClient
builder.Services.AddHttpClient<IBaseConsumption, BaseConsumption>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiConfig:UrlBase"]);
});

builder.Services.AddTransient<INotificationsClientService, NotificationsServiceConsumption>();


// Dependencias del Schema Users
// Dependencia de User
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IUserService, UserService>();
// Dependencia de Doctor
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
// Dependencia de Patient
builder.Services.AddScoped<IPatientRepository, PatientsRepository>();
builder.Services.AddTransient<IPatientService, PatientService>();

// Dependencias del Schema Medical
// Dependencia de AvailabilityModes
builder.Services.AddScoped<IAvailabilityModesRepository, AvailabilityModesRepository>();
builder.Services.AddTransient<IAvailabilityModesService, AvailabilityModesService>();
// Dependencia de MedicalRecords
builder.Services.AddScoped<IMedicalRecordsRepository, MedicalRecordsRepository>();
builder.Services.AddTransient<IMedicalRecordsService, MedicalRecordsService>();
// Dependencia de Specialties
builder.Services.AddScoped<ISpecialtiesRepository, SpecialtiesRepository>();
builder.Services.AddTransient<ISpecialtiesService, SpecialtiesService>();

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();