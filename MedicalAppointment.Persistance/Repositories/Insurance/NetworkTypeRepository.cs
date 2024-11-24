
using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Domain.Entities.Insurance;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.Insurance;
using MedicalAppointment.Persistance.Models.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace MedicalAppointment.Persistance.Repositories.Insurance
{

    public sealed class NetworkTypeRepository(MedicalAppointmentContext medicalAppointmentContext,
      ILogger<NetworkTypeRepository> logger) : BaseRepository<NetworkType>(medicalAppointmentContext), INetworkTypeRepository
    {
          private readonly ILogger<NetworkTypeRepository>logger = logger;


         
        private readonly MedicalAppointmentContext medical_AppointmentContext = medicalAppointmentContext;
        public Task<OperationResult> GetBynetworkdescription(string Description)
        {
            throw new NotImplementedException();
        }

        public async override Task<OperationResult> Save(NetworkType entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Name) || entity.Name.Length > 50)
            {
                result.Success = false;
                result.Message = " El nombre es requerido y no puede pasar de 50 caracteres ";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Description) || entity.Description.Length > 255)
            {
                result.Success = false;
                result.Message = "La descripcion es requerido y no puede pasar de 255 caracteres";
                return result;
            }
            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "El tipo de Red es requerido ";
                logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }


             public async override Task<OperationResult> Update(NetworkType entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Name) || entity.Name.Length > 50)
            {
                result.Success = false;
                result.Message = " El nombre es requerido y no puede pasar de 50 caracteres ";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Description) || entity.Description.Length > 255)
            {
                result.Success = false;
                result.Message = "La descripcion es requerido y no puede pasar de 255 caracteres";
                return result;
            }

            try
            {
                NetworkType? networkTypeUPdate = await medical_AppointmentContext.NetworkTypes.FindAsync(entity.NetworkTypeId);

                networkTypeUPdate.NetworkTypeId = entity.NetworkTypeId;
                networkTypeUPdate.Name = entity.Name;
                networkTypeUPdate.Description = entity.Description;
                networkTypeUPdate.CreatedAt = entity.CreatedAt;
                networkTypeUPdate.UpdatedAt = entity.UpdatedAt;
                networkTypeUPdate.IsActive = entity.IsActive;

                result = await base.Update(networkTypeUPdate);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar la red";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> Remove(NetworkType entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Name) || entity.Name.Length > 50)
            {
                result.Success = false;
                result.Message = " El nombre es requerido y no puede pasar de 50 caracteres ";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Description) || entity.Description.Length > 255)
            {
                result.Success = false;
                result.Message = "La descripcion es requerido y no puede pasar de 255 caracteres";
                return result;
            }

            try
            {
                NetworkType? networkTypeToRemove = await medical_AppointmentContext.NetworkTypes.FindAsync(entity.NetworkTypeId);
                networkTypeToRemove.NetworkTypeId = entity.NetworkTypeId;
                networkTypeToRemove.Name = entity.Name;
                networkTypeToRemove.Description = entity.Description;
                networkTypeToRemove.CreatedAt = entity.CreatedAt;
                networkTypeToRemove.UpdatedAt = entity.UpdatedAt;               
                
                await base.Update(networkTypeToRemove);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al remover la red";
                logger.LogError(result.Message, ex.ToString());
            }

            return result;

        }

        public async override Task<OperationResult> GetAll()
        {

            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from networktype in medical_AppointmentContext.NetworkTypes
                                    
                                     select new NetworkTypeModel()

                                     {
                                        NetworkTypeId = networktype.NetworkTypeId,
                                        Name = networktype.Name,
                                        Description = networktype.Description,
                                           
                                     }).AsNoTracking()
                                     .ToListAsync();

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "El error al obtener los datos";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async override Task<OperationResult> GetEntityBy(int id )
        {

            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from networktype in medical_AppointmentContext.NetworkTypes
                                     where networktype.NetworkTypeId == id
                                     select new NetworkTypeModel()

                                     {
                                         NetworkTypeId = networktype.NetworkTypeId,
                                         Name = networktype.Name,
                                         Description = networktype.Description,

                                     }).AsNoTracking()
                                     .ToListAsync();

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "El error al obtener los datos";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }




    }
}
