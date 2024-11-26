using MedicalAppointment.Consumption.Base;
using MedicalAppointment.Consumption.ModelsMethods.appointments.Appointments;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MedicalAppointment.Application.Dtos.appointments.Appointments;
using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Consumption.ContractsConsumption.appointments;

namespace MedicalAppointment.Consumption.ServicesConsumption.appointments
{
    public class AppointmentsServiceConsumption : IAppointmentsContracts
    {
        private readonly IBaseConsumption _baseConsumption;
        private readonly ILogger<AppointmentsServiceConsumption> _logger;
        private IConfiguration _configuration;

        public AppointmentsServiceConsumption(IBaseConsumption baseConsumption, ILogger<AppointmentsServiceConsumption> logger)
        {
            _baseConsumption = baseConsumption;
            _logger = logger;
        }

        public async Task<AppointmentsGetAllModel> GetAll()
        {
            AppointmentsGetAllModel appointmentsGetAll = new AppointmentsGetAllModel();

            try
            {
                appointmentsGetAll = await _baseConsumption.GetAllConsumption<AppointmentsGetAllModel>("Appointments/GetAllAppointments");
            }
            catch (Exception ex)
            {
                appointmentsGetAll.isOkay = false;
                appointmentsGetAll.mensaje = "Error obteniendo las notificaciones.";
                _logger.LogError($"{appointmentsGetAll.mensaje} {ex.ToString()}");
            }
            return appointmentsGetAll;
        }

        public async Task<AppointmentsGetByIdModel> GetById(int id)
        {
            AppointmentsGetByIdModel appointmentsGetById = new AppointmentsGetByIdModel();

            try
            {
                appointmentsGetById = await _baseConsumption.GetByIdConsumption<AppointmentsGetByIdModel>($"Appointments/GetByAppointments{id}");
            }
            catch (Exception ex)
            {
                appointmentsGetById.isOkay = false;
                appointmentsGetById.mensaje = "Error obteniendo los detalles.";
                _logger.LogError($"{appointmentsGetById.mensaje} {ex.ToString()}");

            }
            return appointmentsGetById;
        }

        public async Task<AppointmentsSaveDto> Save(AppointmentsSaveDto saveDto)
        {
            BaseResponseConsumption baseResponse = new BaseResponseConsumption();  

            try
            {
                saveDto.CreatedAt = DateTime.Now;
                var appointmentsSave = await _baseConsumption.SaveConsumption<AppointmentsSaveDto>("Appointments/SaveAppointments{}", saveDto);
            }
            catch (Exception ex)
            {
                baseResponse.isOkay = false;
                baseResponse.mensaje = "Error obteniendo las notificaciones";
                _logger.LogError($"{baseResponse.mensaje} {ex.ToString()}");
            }
            return saveDto;
        }

        public async Task<AppointmentsUpdateDto> Update(AppointmentsUpdateDto updateDto)
        {
            BaseResponseConsumption baseResponse = new BaseResponseConsumption();

            try
            {
                updateDto.UpdateAt = DateTime.Now;
                var appointmentsUpdate = await _baseConsumption.UpdateConsumption<AppointmentsUpdateDto>($"Appointments/UpdateAppointments?={updateDto.AppointmentID}", updateDto);
            }
            catch (Exception ex)
            {
                baseResponse.isOkay = false;
                baseResponse.mensaje = "Error actualizando el appoitnemnts";
                _logger.LogError($"{baseResponse.mensaje} {ex.ToString()}");
            }
            return updateDto;
    }
    }
}
