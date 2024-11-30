

using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Domain.Result;

namespace MedicalAppointment.Persistance.Validations.appointments
{
    public class ValidateAppointments
    {
        public OperationResult ValidationSaveAppointments (Appointment appointment, OperationResult result) 
        {
            if (appointment == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";

                return result;
            }
            if (appointment.PatientID <= 0)
            {
                result.Success = false;
                result.Message = "El ID del paciente es requerido.";
                return result;
            }
            if (appointment.DoctorID <= 0)
            {
                result.Success = false;
                result.Message = "El ID del doctor es requerido";
                return result;
            }
            if (appointment.AppointmentDate == null)
            {
                result.Success = false;
                result.Message = "La fecha es requerida";
                return result;
            }
            if (appointment.StatusID <= 0)
            {
                result.Success = false;
                result.Message = "El Estatus del ID es requerido";
                return result;
            }

            return result;
        }

        public OperationResult ValidationUpdateAppointments(Appointment appointment, OperationResult result)
        {
            if (appointment == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";
                return result;
            }
            if (appointment.AppointmentID <= 0)
            {
                result.Success = false;
                result.Message = "El AppointmentID es requerido";
                return result;
            }
            if (appointment.PatientID <= 0)
            {
                result.Success = false;
                result.Message = "El ID del paciente es requerido.";
                return result;
            }
            if (appointment.DoctorID <= 0)
            {
                result.Success = false;
                result.Message = "El ID del doctor es requerido";
                return result;
            }
            if (appointment.AppointmentDate == null)
            {
                result.Success = false;
                result.Message = "La fecha es requerida";
                return result;
            }
            if (appointment.StatusID <= 0)
            {
                result.Success = false;
                result.Message = "El Estatus del ID es requerido";
                return result;
            }

            return result;
        }

        public OperationResult ValidationRemoveAppointment(Appointment appointment, OperationResult result) 
        {
            if (appointment == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }
            if (appointment.AppointmentID <= 0)
            {
                result.Success = false;
                result.Message = "Se requiere el AppointmentID es requerido para realizar esta acción";
                return result;
            }

            return result;
        }
    }
}
