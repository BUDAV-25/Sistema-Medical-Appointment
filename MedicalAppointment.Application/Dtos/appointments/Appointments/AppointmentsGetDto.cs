

namespace MedicalAppointment.Application.Dtos.appointments.Appointments
{
    public class AppointmentsGetDto : AppointmentsBaseDto
    {
        public int AppointmentID { get; set; }
        public string PatienName { get; set; }

    }
}
