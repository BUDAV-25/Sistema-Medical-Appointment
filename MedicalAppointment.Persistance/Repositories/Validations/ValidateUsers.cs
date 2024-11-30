using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Domain.Result;

namespace MedicalAppointment.Persistance.Repositories.Validations
{
    public class ValidateUsers
    {
        public OperationResult ValidationsUser(User user, OperationResult result)
        {
            if (user == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";
                return result;
            }
            if (string.IsNullOrEmpty(user.FirstName))
            {
                result.Success = false;
                result.Message = "Es requerido el nombre del usuario";
                return result;
            }
            if (string.IsNullOrEmpty(user.LastName))
            {
                result.Success = false;
                result.Message = "Requerimos el apellido";
                return result;
            }
            if (string.IsNullOrEmpty(user.Email))
            {
                result.Success = false;
                result.Message = "Necesitamos el e-mail del usuario";
                return result;
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                result.Success = false;
                result.Message = "Por seguridad, se requiere una contraseña";
                return result;
            }
            return result;
        }
        public OperationResult ValidationsDoctor(Doctor doctor, OperationResult result)
        {
            if (doctor == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";

                return result;
            }
            if (doctor.SpecialtyID == 0)
            {
                result.Success = false;
                result.Message = "La especialidad del es requerida";

                return result;
            }
            if (string.IsNullOrEmpty(doctor.LicenseNumber) || doctor.LicenseNumber.Length > 50)
            {
                result.Success = false;
                result.Message = "La licencia del doctor es requerida y no puede ser mayor 50 caracteres.";
                return result;
            }
            if (string.IsNullOrEmpty(doctor.PhoneNumber) || doctor.PhoneNumber.Length > 15)
            {
                result.Success = false;
                result.Message = "Es necesario el número telefónico y no puede ser mayor a 15 caracteres.";
                return result;
            }
            if (doctor.YearsOfExperience <= 0)
            {
                result.Success = false;
                result.Message = "Es necesario saber los años de experiencia";
                return result;
            }
            if (string.IsNullOrEmpty(doctor.Education))
            {
                result.Success = false;
                result.Message = "Es requerida la educación del doctor";
                return result;
            }
            if (doctor.LicenseExpirationDate == null)
            {
                result.Success = false;
                result.Message = "Se requiere la fecha en que expira la licencia";

                return result;
            }
            return result;
        }
        public OperationResult ValidationsPatient(Patient patient, OperationResult result)
        {
            if (patient == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";
                return result;
            }
            if (patient.DateOfBirth == null)
            {
                result.Success = false;
                result.Message = "Se requiere la fecha de nacimiento del paciente";
                return result;
            }
            if (patient.Gender == null)
            {
                result.Success = false;
                result.Message = "Es necesario saber el género del paciente";
                return result;
            }
            if (string.IsNullOrEmpty(patient.PhoneNumber) || patient.PhoneNumber.Length > 15)
            {
                result.Success = false;
                result.Message = "Para comunicarnos es necesario el número telefónico del paciente y que no pase de 15 caracteres";
                return result;
            }
            if (string.IsNullOrEmpty(patient.Address) || patient.Address.Length > 255)
            {
                result.Success = false;
                result.Message = "Se requiere la direcciónn del paciente y que no sobre pase de 255 caracteres";
                return result;
            }
            if (string.IsNullOrEmpty(patient.EmergencyContactName) || patient.EmergencyContactName.Length > 100)
            {
                result.Success = false;
                result.Message = "Se requiere el nombre de emergencia para el paciente y que no sobre pase de 100 caracteres";
                return result;
            }
            if (string.IsNullOrEmpty(patient.EmergencyContactPhone) || patient.EmergencyContactPhone.Length > 15)
            {
                result.Success = false;
                result.Message = "Se requiere el número de emergencia para el paciente y que sobre pase de 15 caracteres";
                return result;
            }
            if (patient.BloodType == null)
            {
                result.Success = false;
                result.Message = "Es requerido el tipo de sangre del paciente";
                return result;
            }
            if (patient.Allergies == null)
            {
                result.Success = false;
                result.Message = "Por la salud del paciente es necesario saber cuales son sus alergias";
                return result;
            }
            if (patient.InsuranceProviderID <= 0)
            {
                result.Success = false;
                result.Message = "Es requerido el seguro del paciente";
                return result;
            }
            return result;
        }
    }
}
