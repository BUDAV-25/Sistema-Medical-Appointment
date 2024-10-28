﻿using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Domain.Repositories;
using MedicalAppointment.Domain.Result;

namespace MedicalAppointment.Persistance.Interfaces.appointments
{
    public interface IDoctorAvailabilityRepository : IBaseRepository<DoctorAvailability>
    {

        //Define los horarios en los que un médico estará disponible para recibir citas.
        Task<OperationResult> SetDoctorAvailability(int doctorId, DateTime startDateTime, DateTime endDateTime);

        //Bloquea un periodo de tiempo específico en la agenda de un médico para evitar que se hagan citas (por ejemplo, si tiene vacaciones, eventos, etc.).
        Task<OperationResult> BlockDoctorTimeSlot(int doctorId, DateTime startDateTime, DateTime endDateTime);

    }
}