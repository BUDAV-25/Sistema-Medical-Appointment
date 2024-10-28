﻿

using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.appointments;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace MedicalAppointment.Persistance.Repositories.appointments
{
    public sealed class AppointmentsRepository(MedicalAppointmentContext medicalAppointmentContext,
        ILogger<AppointmentsRepository> logger) : BaseRepository<Appointments>(medicalAppointmentContext), IAppointmentsRepository
    {

        private readonly MedicalAppointmentContext medical_AppointmentContext = medicalAppointmentContext;
        private readonly ILogger<AppointmentsRepository> logger = logger;
        public async override Task<OperationResult> Save(Appointments entity)
        {
            OperationResult result = new OperationResult();
            if (entity == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";

                return result;
            }

            if (entity.PatientID <= 0)
            {
                result.Success = false;
                result.Message = "El ID del paciente es requerido.";
                return result;
            }

            if (entity.DoctorID <= 0)
            {
                result.Success = false;
                result.Message = "El ID del doctor es requerido";
                return result;
            }

            if (entity.AppointmentDate == null)
            {
                result.Success = false;
                result.Message = "La fecha es requerida";
                return result;
            }

            if (entity.StatusID <= 0)
            {
                result.Success = false;
                result.Message = "El Estatus del ID es requerido";
                return result;
            }

            try
            {
                result = await base.Save(entity);

            }

            catch (Exception ex) {
                result.Success = false;
                result.Message = "Error al guardar el appointments";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async override Task<OperationResult> Update(Appointments entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null) {

                result.Success = false;
                result.Message = "Se requiere la entidad";

                return result;
            }

            if (entity.AppointmentID <= 0)
            {
                result.Success = false;
                result.Message = "El AppointmentID es requerido";
                return result;
            }

            if (entity.PatientID <= 0)
            {
                result.Success = false;
                result.Message = "El ID del paciente es requerido.";
                return result;
            }

            if (entity.DoctorID <= 0)
            {
                result.Success = false;
                result.Message = "El ID del doctor es requerido";
                return result;
            }

            if (entity.AppointmentDate == null)
            {
                result.Success = false;
                result.Message = "La fecha es requerida";
                return result;
            }

            if (entity.StatusID <= 0)
            {
                result.Success = false;
                result.Message = "El Estatus del ID es requerido";
                return result;
            }

            if (entity.CreatedAt <= null)
            {
                result.Success = false;
                result.Message = "La fecha de creacion es requerida";
                return result;
            }

            if (entity.UpdatedAt == null)
            {
                result.Success = false;
                result.Message = "La fecha de actualizacion es requerida";
                return result;
            }
            
            try
            {
                Appointments? appointmentsToUpdate = await medical_AppointmentContext.Appointments.FindAsync(entity.AppointmentID);

                appointmentsToUpdate.AppointmentID = entity.AppointmentID;
                appointmentsToUpdate.PatientID = entity.PatientID;
                appointmentsToUpdate.DoctorID = entity.DoctorID;
                appointmentsToUpdate.AppointmentDate = entity.AppointmentDate;
                appointmentsToUpdate.StatusID = entity.AppointmentID;
                appointmentsToUpdate.CreatedAt = entity.CreatedAt;
                appointmentsToUpdate.UpdatedAt = entity.UpdatedAt;

                result = await base.Save(appointmentsToUpdate);

            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el appointments";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        


    }

        public async override Task<OperationResult> Remove(Appointments entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }

            if (entity.AppointmentID <= 0)
            {
                result.Success = false;
                result.Message = "Se requiere el AppointmentID es requerido para realizar esta acción";
                return result;
            }

            try
            {
                Appointments? appointmentsToRemove = await medical_AppointmentContext.Appointments.FindAsync(entity.AppointmentID);

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
                return result;
            }
        }

        public async override Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
        }




        public Task<OperationResult> ConfirmOrRejectAppointment(int appointmentId, bool isConfirmed, string? reason)
        {
            throw new NotImplementedException();
        }
    }
}

