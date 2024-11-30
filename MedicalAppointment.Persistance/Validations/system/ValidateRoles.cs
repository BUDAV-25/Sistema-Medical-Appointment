

using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Domain.Result;
using System.Diagnostics.Contracts;

namespace MedicalAppointment.Persistance.Validations.system
{
    public class ValidateRoles
    {
        public OperationResult ValidationSaveRoles (Roles roles, OperationResult result)
        {
            if (roles == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }
            if (string.IsNullOrEmpty(roles.RoleName) || roles.RoleName.Length > 50)
            {
                result.Success = false;
                result.Message = "Debe de tener un nombre con un maximo de 50 caracteres";
                return result;
            }

            return result;
        }

        public OperationResult ValidationUpdateRoles(Roles roles, OperationResult result)
        {
            if (roles == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";
                return result;
            }
            if (string.IsNullOrEmpty(roles.RoleName) || roles.RoleName.Length > 50)
            {
                result.Success = false;
                result.Message = "Debe de tener un nombre con un maximo de 50 caracteres";
                return result;
            }
            if (roles.UpdatedAt == null)
            {
                result.Success = false;
                result.Message = "Se requiere la fecha de modificacion";
                return result;
            }
            if (roles.IsActive == null)
            {
                result.Success = false;
                result.Message = "Se requiere la activacion";
                return result;
            }

            return result;
        }

        public OperationResult ValidationRemoveRoles(Roles roles, OperationResult result)
        {
            if (roles == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }
            if (roles.RoleID <= 0)
            {
                result.Success = false;
                result.Message = "Se requiere el RoleID";
                return result;
            }

            return result;
        }
    }
}
