using MedicalAppointment.Domain.Entities.medical;
using MedicalAppointment.Domain.Result;

namespace MedicalAppointment.Persistance.Repositories.Validations
{
    public class ValidateMedical
    {
        public OperationResult ValidationsAvailabilityModes(AvailabilityModes availabilityModes, OperationResult result)
        {
            if (availabilityModes == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }
            if (string.IsNullOrEmpty(availabilityModes.AvailabilityMode) || availabilityModes.AvailabilityMode.Length > 100)
            {
                result.Success = false;
                result.Message = "El modo es necesario y debe ser menor a 100 caracteres";
                return result;
            }
            return result;
        }
        public OperationResult ValidationsMedicalRecords(MedicalRecords records, OperationResult result)
        {
            if (records == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }
            if (records.PatientID <= 0)
            {
                result.Success = false;
                result.Message = "Es requerido el paciente";
                return result;
            }
            if (records.DoctorID <= 0)
            {
                result.Success = false;
                result.Message = "Es requerido el doctor";
                return result;
            }
            if (string.IsNullOrEmpty(records.Diagnosis))
            {
                result.Success = false;
                result.Message = "Es requerido el diagnostico del paciente";
                return result;
            }
            if (string.IsNullOrEmpty(records.Treatment))
            {
                result.Success = false;
                result.Message = "Es requerido un tratamiento para el paciente";
                return result;
            }
            if (records.DateOfVisit == null)
            {
                result.Success = false;
                result.Message = "Es necesario una fecha de visita";
                return result;
            }
            return result;
        }
        public OperationResult ValidationsSpecialties(Specialties specialties, OperationResult result)
        {
            if (specialties == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }
            if (string.IsNullOrEmpty(specialties.SpecialtyName))
            {
                result.Success = false;
                result.Message = "el nombre de la especialidad es requerido";
                return result;
            }
            return result;
        }
    }
}
