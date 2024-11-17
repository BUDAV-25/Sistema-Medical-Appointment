using MedicalAppointment.Application.Contracts.appointments;
using MedicalAppointment.Application.Contracts.system;
using MedicalAppointment.Application.Services.appointmet;
using MedicalAppointment.Application.Services.System;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.appointments;
using MedicalAppointment.Persistance.Interfaces.system;
using MedicalAppointment.Persistance.Repositories.appointments;
using MedicalAppointment.Persistance.Repositories.system;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddDbContext<MedicalAppointmentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalDB")));


// Dependencia de Notification

builder.Services.AddScoped<INotificationsRepository, NotificationsRepository>();
builder.Services.AddTransient<INotificationService, NotificationService>();

// Dependencia de Roles

builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddTransient<IRolesService, RolesService>();

// Dependencia de Status

builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddTransient<IStatusService, StatusService>();

// Dependencias de Notifications

builder.Services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
builder.Services.AddTransient<IAppointmentsService, AppointmentService>();

// Dependencia de DoctorAvailability

builder.Services.AddScoped<IDoctorAvailabilityRepository, DoctorAvailabilityRepository>();
builder.Services.AddTransient<IDoctorAvailabilityService, DoctorAvailabilityService>();




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