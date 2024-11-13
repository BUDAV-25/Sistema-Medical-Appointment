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
        private readonly IAppointmentsService _appointmentsService;

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

                List<AppointmentsGetDto> appointment = ((List<EntityAppointment>)result.Data).Select(appointments => new AppointmentsGetDto()
                {
                    AppointmentID = appointments.AppointmentID,
                    PatientID = appointments.PatientID,
                    DoctorID = appointments.DoctorID,
                    AppointmentDate = appointments.AppointmentDate,
                    StatusID = appointments.StatusID

                }).ToList();

                appointmentsResponse.IsSuccess = result.Success;
                appointmentsResponse.Data = appointment;



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
                };

                appointmentsResponse.IsSuccess = result.Success;
                appointmentsResponse.Data = appointmentsGetDto;
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
                appointmentToUpdate.AppointmentDate = dto.AppointmentDate;
                appointmentToUpdate.StatusID = dto.StatusID;
                appointmentToUpdate.UpdatedAt = dto.UpdateAt;

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
