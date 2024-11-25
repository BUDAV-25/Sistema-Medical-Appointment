using MedicalAppointment.Consumption.Base;
using MedicalAppointment.Consumption.ModelsMethods.appointments.Appointments;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace MedicalAppointment.Consumption.ServicesConsumption.appointments
{
    public class AppointmentsServiceConsumption 
    {
        private readonly IBaseConsumption _baseConsumption;
        private readonly ILogger<AppointmentsServiceConsumption> _logger;
        private IConfiguration _configuration;

        public AppointmentsServiceConsumption(IBaseConsumption baseConsumption, ILogger<AppointmentsServiceConsumption> logger)
        {
            _baseConsumption = baseConsumption;
            _logger = logger;
        }

    }
}
