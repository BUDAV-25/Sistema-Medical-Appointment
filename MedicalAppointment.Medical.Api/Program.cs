
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.medical;
using MedicalAppointment.Persistance.Repositories.medical;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Medical.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MedicalAppointmentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalAppDB")));

            // -----Registro de cada una de las dependencias-----
            builder.Services.AddScoped<IAvailabilityModesRepository, AvailabilityModesRepository>();
            builder.Services.AddScoped<IMedicalRecordsRepository, MedicalRecordsRepository>();
            builder.Services.AddScoped<ISpecialtiesRepository, SpecialtiesRepository>();

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
        }
    }
}
