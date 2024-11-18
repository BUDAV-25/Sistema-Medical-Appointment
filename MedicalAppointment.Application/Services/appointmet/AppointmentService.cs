using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Contracts.appointments;
using MedicalAppointment.Application.Dtos.appointments.Appointments;
using MedicalAppointment.Application.Response.appointments.Appointments;
using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Persistance.Interfaces.appointments;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// using MedicalAppointment.Domain.Entities.appointments;
using EntityAppointment = MedicalAppointment.Domain.Entities.appointments.Appointment;



namespace MedicalAppointment.Application.Services.appointmet
{
    public class AppointmentService : IAppointmentsService
    {
        private readonly IAppointmentsRepository _appointmentsRepository;
        private readonly ILogger<AppointmentService> _logger;

        public AppointmentService(IAppointmentsRepository appointmentsRepository, ILogger<AppointmentService> logger)
        {
            if (appointmentsRepository is null)
            {
                throw new ArgumentNullException(nameof(appointmentsRepository));
            }

            _appointmentsRepository = appointmentsRepository;
            _logger = logger;


        }

        public async Task<AppointmentsResponse> GetAll()
        {
            AppointmentsResponse appointmentsResponse = new AppointmentsResponse();

            try
            {
                var result = await _appointmentsRepository.GetAll();

                if (!result.Success)
                {
                    appointmentsResponse.IsSuccess = result.Success;
                    appointmentsResponse.Messages = result.Message;

                    return appointmentsResponse;
                }

                appointmentsResponse.Data = result.Data;

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

                if (!result.Success)
                {
                    appointmentsResponse.IsSuccess = result.Success;
                    appointmentsResponse.Messages = result.Message;

                    return appointmentsResponse;
                }

                appointmentsResponse.Data = result.Data;
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
                appointment.PatientID = dto.PatientID;
                appointment.DoctorID = dto.DoctorID;
                appointment.AppointmentDate = dto.AppointmentDate;
                appointment.StatusID = dto.StatusID;
                appointment.CreatedAt = dto.CreatedAt;

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
                var resultGetById = await _appointmentsRepository.GetEntityBy(dto.AppointmentID);

                if (!resultGetById.Success)
                {
                    appointmentsResponse.IsSuccess = resultGetById.Success;
                    appointmentsResponse.Messages = resultGetById.Message;

                    return appointmentsResponse;
                }

                EntityAppointment appointment = new EntityAppointment();

                appointment.AppointmentID = dto.AppointmentID;
                appointment.PatientID = dto.PatientID;
                appointment.DoctorID = dto.DoctorID;
                appointment.AppointmentDate = dto.AppointmentDate;
                appointment.StatusID = dto.StatusID;
                appointment.CreatedAt = dto.UpdateAt;
                appointment.UpdatedAt = dto.UpdateAt;

                var result = await _appointmentsRepository.Update(appointment);

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
