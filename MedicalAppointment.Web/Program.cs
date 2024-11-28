using MedicalAppointment.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using MedicalAppointment.IOC.Dependencies.system;
using MedicalAppointment.IOC.Dependencies.appointmens;
using MedicalAppointment.Consumption.ServicesConsumption.system;
using MedicalAppointment.Consumption.Base;
using MedicalAppointment.Consumption.ContractsConsumption.appointments;
using MedicalAppointment.Consumption.ServicesConsumption.appointments;
using MedicalAppointment.Consumption.ContractsConsumption.system;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddDbContext<MedicalAppointmentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalDB")));

// Dendencia del esquema appointments usando la capa de aplicacion
builder.Services.AddAppointmentsDependency();

// Dependencia del esquema system usando la capa de aplicacion
builder.Services.AddSystemDependency();


// Constructor HttpClient
builder.Services.AddHttpClient<IBaseConsumption, BaseConsumption>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiConfig:UrlBase"]);
});

// Dependencia del esquema appointments usando el api y refactorizado
builder.Services.AddTransient<IAppointmentsContracts, AppointmentsServiceConsumption>();
builder.Services.AddTransient<IDoctorAvailabilityContracts, DoctorAvailabilityServiceConsumption>();

// Dependencia del esquema system usando el api y refactorizado
builder.Services.AddTransient<INotificationsContracts, NotificationsServiceConsumption>();
builder.Services.AddTransient<IRolesContracts, RolesServiceConsumption>();
builder.Services.AddTransient<IStatusContracts, StatusServiceConsumption>();

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