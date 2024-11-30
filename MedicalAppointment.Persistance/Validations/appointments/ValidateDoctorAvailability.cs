

using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Domain.Result;

namespace MedicalAppointment.Persistance.Validations.appointments
{
    public class ValidateDoctorAvailability
    {
        public OperationResult ValidationSaveDoctorAvailability(DoctorAvailability doctorAvailability, OperationResult result)
        {
            if (doctorAvailability == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida.";
                return result;

            }
            if (doctorAvailability.DoctorID <= 0)
            {
                result.Success = false;
                result.Message = "El doctor es requerido.";
                return result;
            }

            return result;
        }

        public OperationResult ValidationUpdateDoctorAvailability(DoctorAvailability doctorAvailability, OperationResult result) 
        {
            if (doctorAvailability == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida.";
                return result;
            }
            if (doctorAvailability.AvailabilityID <= 0)
            {
                result.Success = false;
                result.Message = "La disponivilidad es requerida.";
                return result;
            }
            if (doctorAvailability.DoctorID <= 0)
            {
                result.Success = false;
                result.Message = "Es requerido el ID del doctor para realizar esta acción.";
                return result;
            }
            if (doctorAvailability.AvailableDate == null)
            {
                result.Success = false;
                result.Message = "La fecha es requerida.";
                return result;
            }
            if (doctorAvailability.StartTime == null)
            {
                result.Success = false;
                result.Message = "La fecha inicial es requerida.";
                return result;
            }
            if (doctorAvailability.EndTime == null)
            {
                result.Success = false;
                result.Message = "La fecha final es requerida.";
                return result;
            }

            return result;
        }

        public OperationResult ValidationRemoveDoctorAvailability (DoctorAvailability doctorAvailability, OperationResult result) 
        {
            if (doctorAvailability == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida.";
                return result;
            }
            if (doctorAvailability.AvailabilityID <= 0)
            {
                result.Success = false;
                result.Message = "Se requiere el ID de la disponibilidad para realizar esta acción.";
                return result;
            }

            return result;
        }
    }
}
