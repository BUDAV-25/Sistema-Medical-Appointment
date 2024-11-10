

using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Contracts.appointments;
using MedicalAppointment.Application.Dtos.appointments.Appointments;
using MedicalAppointment.Application.Response.appointments.Appointments;
using MedicalAppointment.Application.Services;
using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Persistance.Interfaces.appointments;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// using MedicalAppointment.Domain.Entities.appointments;
using EntityAppointment = MedicalAppointment.Domain.Entities.appointments.Appointment;



namespace MedicalAppointment.Application.Services.Configuration
{
    public class AppointmentService : IAppointmentsService
    {
        private readonly IAppointmentsRepository _appointmentsRepository;
        private readonly ILogger<AppointmentService> _logger;
        private readonly IAppointmentsService _appointmentsService;

        public AppointmentService(IAppointmentsRepository appointmentsRepository, ILogger<AppointmentService> logger, IAppointmentsService appointmentsService)
        {
            if (appointmentsRepository is null)
            {
                throw new ArgumentNullException(nameof(appointmentsRepository));
            }

            _appointmentsRepository = appointmentsRepository;
            _logger = logger;
            _appointmentsService = appointmentsService;
        }

        public async Task<AppointmentsResponse> GetAll()
        {
            AppointmentsResponse appointmentsResponse = new AppointmentsResponse();

            try
            {
                var result = await _appointmentsRepository.GetAll();

                List<AppointmentsGetDto> appointment = ((List<EntityAppointment>)result.Data).Select(appointments => new AppointmentsGetDto()
                {
                    AppointmentID = appointments.AppointmentID,
                    PatientID = appointments.PatientID,
                    DoctorID = appointments.DoctorID,
                    AppointmentDate = appointments.AppointmentDate,
                    StatusID = appointments.StatusID,
                    CreatedAt = appointments.CreatedAt,

                }).ToList();

                appointmentsResponse.IsSuccess = result.Success;
                appointmentsResponse.Model = appointment;

            }
            catch (Exception ex)
            {
                appointmentsResponse.IsSuccess = false;
                appointmentsResponse.Messages = "Error al obtener las citas";
                _logger.LogError(appointmentsResponse.Messages, ex.ToString());

            }

            return appointmentsResponse;

        }

        public async Task<AppointmentsResponse> GetById(int id)
        {
            AppointmentsResponse appointmentsResponse = new AppointmentsResponse();

            try
            {
                var result = await _appointmentsRepository.GetEntityBy(id);

                EntityAppointment appointment = (EntityAppointment)result.Data;
                AppointmentsGetDto appointmentsGetDto = new AppointmentsGetDto()
                {
                    AppointmentID = appointment.AppointmentID,
                    PatientID = appointment.PatientID,
                    DoctorID = appointment.DoctorID,
                    AppointmentDate = appointment.AppointmentDate,
                    StatusID = appointment.StatusID,
                    CreatedAt = appointment.CreatedAt,
                };

                appointmentsResponse.IsSuccess = result.Success;
                appointmentsResponse.Model = appointmentsGetDto;
            }
            catch (Exception ex)
            {
                appointmentsResponse.IsSuccess = false;
                appointmentsResponse.Messages = "Error al obtener el appointment by ID";
                _logger.LogError(appointmentsResponse.Messages, ex.ToString());

            }

            return appointmentsResponse;
        }

        public async Task<AppointmentsResponse> SaveAsync(AppointmentsSaveDto dto)
        {
            AppointmentsResponse appointmentsResponse = new AppointmentsResponse();

            try
            {
                EntityAppointment appointment = new EntityAppointment();

                appointment.AppointmentID = dto.AppointmentID;
                appointment.PatientID = dto.PatientID;
                appointment.DoctorID = dto.DoctorID;
                appointment.AppointmentDate = (DateTime)dto.AppointmentDate;
                appointment.StatusID = dto.StatusID;
                appointment.CreatedAt = (DateTime)dto.CreatedAt;

                var result = await _appointmentsRepository.Save(appointment);

            }
            catch (Exception ex)
            {
                appointmentsResponse.IsSuccess = false;
                appointmentsResponse.Messages = "Error al guardar el appointment";
                _logger.LogError(appointmentsResponse.Messages, ex.ToString());

            }

            return appointmentsResponse;
        }

        public async Task<AppointmentsResponse> UpdateAsync(AppointmentsUpdateDto dto)
        {
            AppointmentsResponse appointmentsResponse = new AppointmentsResponse();

            try
            {
                var resultEntity = await _appointmentsRepository.GetEntityBy(dto.AppointmentID);

                EntityAppointment appointmentToUpdate = (EntityAppointment)resultEntity.Data;

                appointmentToUpdate.PatientID = dto.PatientID;
                appointmentToUpdate.DoctorID = dto.DoctorID;
                appointmentToUpdate.AppointmentDate = (DateTime)dto.AppointmentDate;
                appointmentToUpdate.StatusID = dto.StatusID;
                appointmentToUpdate.UpdatedAt = (DateTime)dto.UpdateAt;

            }
            catch (Exception ex)
            {
                appointmentsResponse.IsSuccess = false;
                appointmentsResponse.Messages = "Error al actualizar el appointment";
                _logger.LogError(appointmentsResponse.Messages, ex.ToString());

            }
            return appointmentsResponse;
        }
    }
}
