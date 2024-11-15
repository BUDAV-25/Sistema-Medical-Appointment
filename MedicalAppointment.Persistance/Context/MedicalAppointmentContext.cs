using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Domain.Entities.Insurance;
using MedicalAppointment.Domain.Entities.medical;
using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Domain.Entities.users;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Persistance.Context
{
    public partial class MedicalAppointmentContext : DbContext
    {
        public MedicalAppointmentContext(DbContextOptions<MedicalAppointmentContext> options) : base(options)
        {

        }

        #region "appointment Entities"
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DoctorAvailability> DoctorAvailability { get; set; }
        #endregion

        #region "Insurance Entities"
        public DbSet<InsuranceProviders> InsuranceProviders { get; set; }
        public DbSet<NetworkType> NetworkTypes { get; set; }
        #endregion

        #region "medical Entities"
        public DbSet<AvailabilityModes> AvailabilityModes { get; set; }
        public DbSet<MedicalRecords> MedicalRecords { get; set; }
        public DbSet<Specialties> Specialties { get; set; }
        #endregion

        #region "system Entities"
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Status> Status { get; set; }
        #endregion

        #region "users Entities"
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<User> User { get; set; }
        #endregion
    }
}
