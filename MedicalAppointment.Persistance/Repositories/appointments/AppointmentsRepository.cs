using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.appointments;
using MedicalAppointment.Persistance.Models.appointments;
using MedicalAppointment.Persistance.Validations.appointments;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace MedicalAppointment.Persistance.Repositories.appointments
{
    public sealed class AppointmentsRepository(MedicalAppointmentContext medicalAppointmentContext,
        ILogger<AppointmentsRepository> logger, ValidateAppointments validateAppointments) : BaseRepository<Appointment>(medicalAppointmentContext), IAppointmentsRepository
    {

        private readonly MedicalAppointmentContext medical_AppointmentContext = medicalAppointmentContext;
        private readonly ILogger<AppointmentsRepository> logger = logger;
        private readonly ValidateAppointments _validateAppointments = validateAppointments;

        public async override Task<OperationResult> Save(Appointment entity)
        {
            OperationResult result = new OperationResult();

            _validateAppointments.ValidationSaveAppointments(entity, result);

            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el appointments";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }

        public async override Task<OperationResult> Update(Appointment entity)
        {
            OperationResult result = new OperationResult();

            _validateAppointments.ValidationUpdateAppointments(entity, result);

            try
            {
                Appointment? appointmentsToUpdate = await medical_AppointmentContext.Appointments.FindAsync(entity.AppointmentID);

                appointmentsToUpdate.AppointmentID = entity.AppointmentID;
                appointmentsToUpdate.PatientID = entity.PatientID;
                appointmentsToUpdate.DoctorID = entity.DoctorID;
                appointmentsToUpdate.AppointmentDate = entity.AppointmentDate;
                appointmentsToUpdate.StatusID = entity.StatusID;
                appointmentsToUpdate.UpdatedAt = entity.UpdatedAt;

                result = await base.Update(appointmentsToUpdate);

            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el appointments";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }

        public async override Task<OperationResult> Remove(Appointment entity)
        {
            OperationResult result = new OperationResult();

            _validateAppointments.ValidationRemoveAppointment(entity, result);

            try
            {
                Appointment? appointmentsToRemove = await medical_AppointmentContext.Appointments.FindAsync(entity.AppointmentID);

                appointmentsToRemove.AppointmentID = entity.AppointmentID;
                appointmentsToRemove.PatientID = entity.PatientID;
                appointmentsToRemove.DoctorID = entity.DoctorID;
                appointmentsToRemove.AppointmentDate = entity.AppointmentDate;
                appointmentsToRemove.StatusID = entity.StatusID;
                appointmentsToRemove.CreatedAt = entity.CreatedAt;
                appointmentsToRemove.UpdatedAt = entity.UpdatedAt;

                await base.Update(appointmentsToRemove);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al remover el Appointment";
                logger.LogError(result.Message, ToString());
            }
            return result;

        }

        public async override Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from appointments in medical_AppointmentContext.Appointments
                                     join patient in medical_AppointmentContext.Patient on appointments.PatientID equals patient.PatientID
                                     join doctor in medical_AppointmentContext.Doctor on appointments.DoctorID equals doctor.DoctorID

                                     orderby appointments.CreatedAt descending

                                     select new AppointmentsModel()

                                     {
                                         AppointmentID = appointments.AppointmentID,
                                         PatientID = patient.PatientID,
                                         DoctorID = appointments.DoctorID,
                                         AppointmentDate = appointments.AppointmentDate,
                                         StatusID = appointments.StatusID,
                                         CreatedAt = appointments.CreatedAt,
                                         UpdateAt = appointments.UpdatedAt,

                                     }).AsNoTracking()
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los datos";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }

        public async override Task<OperationResult> GetEntityBy(int ID)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from appointments in medical_AppointmentContext.Appointments
                                     join patient in medical_AppointmentContext.Patient on appointments.PatientID equals patient.PatientID
                                     join doctor in medical_AppointmentContext.Doctor on appointments.DoctorID equals doctor.DoctorID
                                     where appointments.AppointmentID == ID

                                     select new AppointmentsModel()

                                     {
                                         AppointmentID = appointments.AppointmentID,
                                         PatientID = patient.PatientID,
                                         DoctorID = appointments.DoctorID,
                                         AppointmentDate = appointments.AppointmentDate,
                                         StatusID = appointments.StatusID,
                                         CreatedAt = appointments.CreatedAt,
                                         UpdateAt = appointments.UpdatedAt

                                     }).AsNoTracking()
                                     .FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener el GetEntityBy";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }




        public Task<OperationResult> ConfirmOrRejectAppointment(int appointmentId, bool isConfirmed, string? reason)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetAppointmentsByDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetAppointmentsByDoctor(int doctorId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetAppointmentsByPatient(int patientId)
        {
            throw new NotImplementedException();
        }

    }
}

