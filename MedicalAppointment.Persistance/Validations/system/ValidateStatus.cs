

using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Domain.Result;

namespace MedicalAppointment.Persistance.Validations.system
{
    public class ValidateStatus
    {
        public OperationResult ValidationSaveStatus (Status status, OperationResult result)
        {
            if (status == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }
            if (string.IsNullOrEmpty(status.StatusName))
            {
                result.Success = false;
                result.Message = "El Status requiere no puedes estar vacio ni null";
                return result;
            }

            return result;
        }
        
        public OperationResult ValidationUpdateStatus(Status status, OperationResult result)
        {
            if (status == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";
                return result;
            }
            if (status.StatusID <= 0)
            {
                result.Success = false;
                result.Message = "Se requiere el StatusID";
                return result;
            }
            if (string.IsNullOrEmpty(status.StatusName) || status.StatusName.Length == 50)
            {
                result.Success = false;
                result.Message = "El Status requiere un nombre no mayor a 50 caracteres";
                return result;
            }

            return result;
        }

        public OperationResult ValidationRemoveStatus(Status status, OperationResult result)
        {
            if (status == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";
                return result;
            }
            if (status.StatusID <= 0)
            {
                result.Success = false;
                result.Message = "Se requiere el StatusID";
                return result;
            }

            return result;
        }
    }
}
