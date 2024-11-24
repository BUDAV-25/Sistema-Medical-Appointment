

namespace MedicalAppointment.Application.Dtos.appointments.Appointments
{
    public class AppointmentsBaseDto
    {
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int StatusID { get; set; }

    }
}
