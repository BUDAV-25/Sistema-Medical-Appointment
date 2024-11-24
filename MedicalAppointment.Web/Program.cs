
using MedicalAppointment.Persistance.Context;
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