using MedicalAppointment.Application.Contracts.system;
using MedicalAppointment.Application.Services.System;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.system;
using MedicalAppointment.Persistance.Repositories.system;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container.

builder.Services.AddDbContext<MedicalAppointmentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalDB")));

// Dependencia de Status
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddTransient<IStatusService, StatusService>();

// Dependencia de Notification

builder.Services.AddScoped<INotificationsRepository, NotificationsRepository>();
builder.Services.AddTransient<INotificationService, NotificationService>();

// Dependencia de Roles

builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddTransient<IRolesService, RolesService>();



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