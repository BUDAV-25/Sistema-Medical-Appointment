using MedicalAppointment.Application.Dtos.appointments.DoctorAvailability;
using MedicalAppointment.Consumption.Base;
using MedicalAppointment.Consumption.ContractsConsumption.appointments;
using MedicalAppointment.Consumption.ModelsMethods.appointments.DoctorAvailability;
using MedicalAppointment.Consumption.ModelsMethods.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Consumption.ServicesConsumption.appointments
{
    public class DoctorAvailabilityServiceConsumption : IDoctorAvailabilityContracts
    {
        private readonly IBaseConsumption _baseConsumption;
        private readonly ILogger <DoctorAvailabilityServiceConsumption> _logger;
        private IConfiguration _configuration;

        public DoctorAvailabilityServiceConsumption(IBaseConsumption baseConsumption, ILogger<DoctorAvailabilityServiceConsumption> logger)
        {
            _baseConsumption = baseConsumption;
            _logger = logger;

        }

        public async Task<DoctorAvailabilityGetAllModel> GetAll()
        {
            DoctorAvailabilityGetAllModel doctorAvailabilityGetAll = new DoctorAvailabilityGetAllModel();

            try
            {
                doctorAvailabilityGetAll = await _baseConsumption.GetAllConsumption<DoctorAvailabilityGetAllModel>("DoctorAvailability/GetAllDoctorAvailabity");
            }
            catch (Exception ex)
            {
                doctorAvailabilityGetAll.isOkay = false;
                doctorAvailabilityGetAll.mensaje = "Error al obtener las disponibilidades del doctor";
                _logger.LogError($"{doctorAvailabilityGetAll.mensaje} {ex.ToString()}");
            }
            return doctorAvailabilityGetAll;
        }

        public async Task<DoctorAvailabilityGetByIdModel> GetById(int id)
        {
            DoctorAvailabilityGetByIdModel doctorAvailabilityGetById = new DoctorAvailabilityGetByIdModel();

            try
            {
                doctorAvailabilityGetById = await _baseConsumption.GetByIdConsumption<DoctorAvailabilityGetByIdModel>($"DoctorAvailability/GetEntityBy{id}");
            }
            catch (Exception ex)
            {
                doctorAvailabilityGetById.isOkay = false;
                doctorAvailabilityGetById.mensaje = "Error al obtener esa disponibilidad";
                _logger.LogError($"{doctorAvailabilityGetById.mensaje} {ex.Message}");
            }
            return doctorAvailabilityGetById;
        }

        public async Task<DoctorAvailabilitySaveDto> Save(DoctorAvailabilitySaveDto saveDto)
        {
            BaseResponseConsumption baseResponse = new BaseResponseConsumption();

            try
            {
                var doctoravailabilitySave = await _baseConsumption.SaveConsumption<DoctorAvailabilitySaveDto>("DoctorAvailability/SaveDoctorAvailability", saveDto);
            }
            catch (Exception ex)
            {
                baseResponse.isOkay = false;
                baseResponse.mensaje = "Error al guardar la disponibilidad del doctor";
                _logger.LogError($"{baseResponse.mensaje} {ex.ToString()}");
            }
            return (saveDto);
        }

        public async Task<DoctorAvailabilityUpdateDto> Update(DoctorAvailabilityUpdateDto updateDto)
        {
            BaseResponseConsumption baseResponse = new BaseResponseConsumption();

            try
            {
                var doctoravailabilityUpdate = await _baseConsumption.UpdateConsumption<DoctorAvailabilityUpdateDto>($"DoctorAvailability/UpdateDoctorAvailability?={updateDto.AvailabilityID}", updateDto);
            }
            catch (Exception ex)
            {
                baseResponse.isOkay = false;
                baseResponse.mensaje = "Error actualizando la disponibilidad del doctor";
                _logger.LogError($"{baseResponse.mensaje} {ex.ToString()}");
            }
            return (updateDto);
        }
    }
}
//http://localhost:5120/api/DoctorAvailability/UpdateDoctorAvailability?id=9