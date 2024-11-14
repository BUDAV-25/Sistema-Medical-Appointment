﻿

namespace MedicalAppointment.Application.Dtos.appointments.DoctorAvailability
{
    public class DoctorAvailabilityBaseDto
    {
        public int DoctorID { get; set; }
        public DateTime AvailableDate { get; set; }
        public TimeSpan StarTime { get; set; }
        public TimeSpan EndTime { get; set; }

    }
}
