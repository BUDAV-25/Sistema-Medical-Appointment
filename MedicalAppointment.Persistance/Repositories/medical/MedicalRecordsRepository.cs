using MedicalAppointment.Domain.Entities.medical;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.medical;
using MedicalAppointment.Persistance.Models.medical;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistance.Repositories.medical
{
    public sealed class MedicalRecordsRepository(MedicalAppointmentContext medicalAppointmentContext, 
        ILogger<MedicalRecordsRepository> logger): BaseRepository<MedicalRecords>(medicalAppointmentContext), IMedicalRecordsRepository
    {
        private readonly MedicalAppointmentContext medical_AppointmentContext = medicalAppointmentContext;
        private readonly ILogger<MedicalRecordsRepository> logger = logger;
        public async override Task<OperationResult> Save(MedicalRecords entity)
        {
            OperationResult result = new OperationResult();
            if (entity == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }
            if(entity.PatientID <= 0)
            {
                result.Success = false;
                result.Message = "Es requerido el paciente";
                return result;
            }
            if(entity.DoctorID <= 0)
            {
                result.Success = false;
                result.Message = "Es requerido el doctor";
                return result;
            }
            if (string.IsNullOrEmpty(entity.Diagnosis))
            {
                result.Success = false;
                result.Message = "Es requerido el diagnostico del paciente";
                return result;
            }
            if(string.IsNullOrEmpty(entity.Treatment))
            {
                result.Success = false;
                result.Message = "Es requerido un tratamiento para el paciente";
                return result;
            }
            if (entity.DateOfVisit == null)
            {
                result.Success = false;
                result.Message = "Es necesario una fecha de visita";
                return result;
            }
            if(await base.Exists( recort => recort.RecordID == entity.RecordID))
            {
                result.Success = false;
                result.Message = "El record ya existe";
                return result;
            }
            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el record";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> Update(MedicalRecords entity)
        {
            OperationResult result = new OperationResult();
            if (entity == null)
            {
                result.Success = false;
                result.Message = "Es requerida la entidad";
                return result;
            }
            if (entity.RecordID <= 0)
            {
                result.Success = false;
                result.Message = "El id del record en necesario para esta accion";
                return result;
            }
            if (entity.PatientID <= 0)
            {
                result.Success = false;
                result.Message = "Es requerido el paciente";
                return result;
            }
            if (entity.DoctorID <= 0)
            {
                result.Success = false;
                result.Message = "Es requerido el doctor";
                return result;
            }
            if (string.IsNullOrEmpty(entity.Diagnosis))
            {
                result.Success = false;
                result.Message = "Es requerido el diagnostico del paciente";
                return result;
            }
            if (string.IsNullOrEmpty(entity.Treatment))
            {
                result.Success = false;
                result.Message = "Es requerido un tratamiento para el paciente";
                return result;
            }
            if (entity.DateOfVisit == null)
            {
                result.Success = false;
                result.Message = "Es necesario una fecha de visita";
                return result;
            }
            try
            {
                MedicalRecords? recordsToUpdate = await medical_AppointmentContext.MedicalRecords.FindAsync(entity.RecordID);
                recordsToUpdate.PatientID = entity.PatientID;
                recordsToUpdate.DoctorID = entity.PatientID;
                recordsToUpdate.Diagnosis = entity.Diagnosis;
                recordsToUpdate.Treatment = entity.Treatment;
                recordsToUpdate.DateOfVisit = entity.DateOfVisit;

                result = await base.Update(entity);
            }
            catch (Exception)
            {
                result.Success = false;
                result.Message = "Error al actualizar el Record Medico";
                return result;
            }
            return result;
        }
        public async override Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = await (from records in medical_AppointmentContext.MedicalRecords
                                     join patient in medical_AppointmentContext.Patient on records.PatientID equals patient.PatientID
                                     join doctor in medical_AppointmentContext.Doctor on records.DoctorID equals doctor.DoctorID
                                     select new MedicalRecordsModel()
                                     {
                                         RecordID = records.RecordID,
                                         PatientID = patient.PatientID,
                                         DoctorID = doctor.DoctorID,
                                         Diagnosis = records.Diagnosis,
                                         Treatment = records.Treatment,
                                         DateOfVisit = records.DateOfVisit
                                     }).AsNoTracking()
                                    .ToListAsync();
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los records";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> GetEntityBy(int Id)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = await (from records in medical_AppointmentContext.MedicalRecords
                                     join patient in medical_AppointmentContext.Patient on records.PatientID equals patient.PatientID
                                     join doctor in medical_AppointmentContext.Doctor on records.DoctorID equals doctor.DoctorID
                                     where records.RecordID == Id
                                     select new MedicalRecordsModel()
                                     {
                                         RecordID = records.RecordID,
                                         PatientID = patient.PatientID,
                                         DoctorID = doctor.DoctorID,
                                         Diagnosis = records.Diagnosis,
                                         Treatment = records.Treatment,
                                         DateOfVisit = records.DateOfVisit
                                     }).AsNoTracking()
                                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los records";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
