﻿using MedicalAppointment.Domain.Entities.medical;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.medical;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistance.Repositories.medical
{
    public sealed class MedicalRecordsRepository(MedicalAppointmentContext medicalAppointmentContext, 
        ILogger<MedicalRecordsRepository> logger): BaseRepository<MedicalRecords>(medicalAppointmentContext), IMedicalRecordsRepository
    {
        private readonly MedicalAppointmentContext medicalAppointmentContext = medicalAppointmentContext;
        private readonly ILogger<MedicalRecordsRepository> logger = logger;
    }
}