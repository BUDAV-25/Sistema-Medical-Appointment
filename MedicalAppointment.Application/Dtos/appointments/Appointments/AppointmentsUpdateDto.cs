

namespace MedicalAppointment.Application.Dtos.appointments.Appointments
{
    public class AppointmentsUpdateDto : AppointmentsBaseDto
    {
        public int AppointmentID { get; set; }
        public DateTime UpdateAt { get; set; }

    }
}
