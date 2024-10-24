using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Domain.Repositories;

namespace MedicalAppointment.Persistance.Interfaces.appointments
{
    public interface IDoctorAvailability : IBaseRepository<DoctorAvailability>
    {
        void SetDoctorAvailability(int doctorId, DateTime startDateTime, DateTime endDateTime);
        List<DateTime> GetDoctorAvailability(int doctorId, DateTime startDate, DateTime endDate);
        void BlockDoctorTimeSlot(int doctorId, DateTime startDateTime, DateTime endDateTime);
        bool IsDoctorAvailable(int doctorId, DateTime dateTime);


    }
}
