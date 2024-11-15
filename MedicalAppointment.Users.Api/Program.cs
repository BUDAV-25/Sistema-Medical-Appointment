
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.users;
using MedicalAppointment.Persistance.Repositories.users;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Users.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MedicalAppointmentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalDB")));

            // -----Registro de cada una de las dependencias de system-----
            builder.Services.AddScoped<IDoctorsRepository, DoctorsRepository>();
            builder.Services.AddScoped<IPatientsRepository, PatientsRepository>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();

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
