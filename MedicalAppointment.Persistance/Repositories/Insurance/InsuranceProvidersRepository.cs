

using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Domain.Entities.Insurance;
using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.Insurance;
using MedicalAppointment.Persistance.Models.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace MedicalAppointment.Persistance.Repositories.Insurance
{
    public sealed class InsuranceProvidersRepository(MedicalAppointmentContext medicalAppointmentContext,
        ILogger<InsuranceProvidersRepository> logger) : BaseRepository<InsuranceProviders>(medicalAppointmentContext), IInsuranceProvidersRepository
    {
        private readonly ILogger<InsuranceProvidersRepository> logger = logger;
        private readonly MedicalAppointmentContext medical_AppointmentContext = medicalAppointmentContext;

        public Task<OperationResult> GetByCountry(string Country)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetByIsPreferred(string isPreferred)
        {
            throw new NotImplementedException();
        }

        public async override Task<OperationResult> Save(InsuranceProviders entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "la entidad es requerida";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Name) || entity.Name.Length > 100)
            {
                result.Success = false;
                result.Message = " El nombre es requerido y no puede pasar de 100 caracteres ";
                return result;
            }

            if (string.IsNullOrEmpty(entity.ContactNumber) || entity.ContactNumber.Length > 15)
            {
                result.Success = false;
                result.Message = "El numero de contacto es requerido y no puede pasar de 15 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Email) || entity.Email.Length > 100)
            {
                result.Success = false;
                result.Message = "El email debe ser requerido y no puede pasar de 100 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Website) || entity.Website.Length > 255)
            {
                result.Success = false;
                result.Message = "El wedsite debe ser requerido y no puede pasar de 255 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Address) || entity.Address.Length > 255)
            {
                result.Success = false;
                result.Message = "El address debe ser requerido y no puede pasar de 255 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.City) || entity.City.Length > 100)
            {
                result.Success = false;
                result.Message = " El city debe ser requerido y no puede pasar de 100 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.State) || entity.State.Length > 100)
            {
                result.Success = false;
                result.Message = "El state debe ser requerido y no puede pasar de 100 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Country) || entity.Country.Length > 100)
            {
                result.Success = false;
                result.Message = "El country debe ser requerido y no puede pasar de 100 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.ZipCode) || entity.ZipCode.Length > 10)
            {
                result.Success = false;
                result.Message = "El zipcode debe ser requerido y no puede pasar de 10 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.CoverageDetails))
            {
                result.Success = false;
                result.Message = "El coveragedetails debe ser requerido";
                return result;

            }

            if (string.IsNullOrEmpty(entity.LogoUrl) || entity.LogoUrl.Length > 255)
            {
                result.Success = false;
                result.Message = "El logourl debe ser requerido y no puede pasar de 255 caracteres";
                return result;

            }

            if (entity.NetworkTypeId <= 0)
            {
                result.Success = false;
                result.Message = "El Networktypeid debe ser reuquerido ";
                return result;
            }

            if (string.IsNullOrEmpty(entity.CustomerSupportContact) || entity.CustomerSupportContact.Length > 15)
            {
                result.Success = false;
                result.Message = "El customersupportcontact debe ser requerido y no puede pasar de 15 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.AcceptedRegions) || entity.AcceptedRegions.Length > 255)
            {
                result.Success = false;
                result.Message = "El acceptedregions debe ser requerido y no puede pasar de 255 caracteres";
                return result;
            }

           

            try
            {
                result = await base.Save(entity);
                

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guadar el insurance";
                logger.LogError(result.Message, ex);
            }
            return result;
        }

        public async override Task<OperationResult> Update(InsuranceProviders entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)

            {
                result.Success = false;
                result.Message = "  Se requiere la entidad ";
                return result;
            }

            if (entity.InsuranceProviderID <= 0)
            {
                result.Success = false;
                result.Message = "El ID de la enditad es requeridad para realizar esta accion";

                return result;
            }


            if (string.IsNullOrEmpty(entity.Name) || entity.Name.Length > 100)
            {
                result.Success = false;
                result.Message = " El nombre es requerido y no puede pasar de 100 caracteres ";
                return result;
            }

            if (string.IsNullOrEmpty(entity.ContactNumber) || entity.ContactNumber.Length > 15)
            {
                result.Success = false;
                result.Message = "El numero de contacto es requerido y no puede pasar de 15 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Email) || entity.Email.Length > 100)
            {
                result.Success = false;
                result.Message = "El email debe ser requerido y no puede pasar de 100 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Website) || entity.Website.Length > 255)
            {
                result.Success = false;
                result.Message = "El wedsite debe ser requerido y no puede pasar de 255 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Address) || entity.Address.Length > 255)
            {
                result.Success = false;
                result.Message = "El address debe ser requerido y no puede pasar de 255 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.City) || entity.City.Length > 100)
            {
                result.Success = false;
                result.Message = " El city debe ser requerido y no puede pasar de 100 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.State) || entity.State.Length > 100)
            {
                result.Success = false;
                result.Message = "El state debe ser requerido y no puede pasar de 100 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.Country) || entity.Country.Length > 100)
            {
                result.Success = false;
                result.Message = "El country debe ser requerido y no puede pasar de 100 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.ZipCode) || entity.ZipCode.Length > 10)
            {
                result.Success = false;
                result.Message = "El zipcode debe ser requerido y no puede pasar de 10 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.CoverageDetails))
            {
                result.Success = false;
                result.Message = "El coveragedetails debe ser requerido";
                return result;

            }

            if (string.IsNullOrEmpty(entity.LogoUrl) || entity.LogoUrl.Length > 255)
            {
                result.Success = false;
                result.Message = "El logourl debe ser requerido y no puede pasar de 255 caracteres";
                return result;

            }

            if (entity.NetworkTypeId <= 0)
            {
                result.Success = false;
                result.Message = "El Networktypeid debe ser reuquerido ";
                return result;
            }

            if (string.IsNullOrEmpty(entity.CustomerSupportContact) || entity.CustomerSupportContact.Length > 15)
            {
                result.Success = false;
                result.Message = "El customersupportcontact debe ser requerido y no puede pasar de 15 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.AcceptedRegions) || entity.AcceptedRegions.Length > 255)
            {
                result.Success = false;
                result.Message = "El acceptedregions debe ser requerido y no puede pasar de 255 caracteres";
                return result;
            }

            if (string.IsNullOrEmpty(entity.AcceptedRegions) || entity.AcceptedRegions.Length > 255)
            {
                result.Success = false;
                result.Message = "El acceptedregions debe ser requerido y no puede pasar de 255 caracteres";
                return result;
            }


            try
            {
                InsuranceProviders? InsuranceUpdate = await medical_AppointmentContext.InsuranceProviders.FindAsync(entity.InsuranceProviderID);

                InsuranceUpdate.Name = entity.Name;
                InsuranceUpdate.ContactNumber = entity.ContactNumber;
                InsuranceUpdate.Email = entity.Email;
                InsuranceUpdate.Website = entity.Website;
                InsuranceUpdate.Address = entity.Address;
                InsuranceUpdate.City = entity.City;
                InsuranceUpdate.State = entity.State;
                InsuranceUpdate.Country = entity.Country;
                InsuranceUpdate.ZipCode = entity.ZipCode;
                InsuranceUpdate.LogoUrl = entity.LogoUrl;


                result = await base.Update(InsuranceUpdate);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizar la informacion del seguro";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async override Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = await (from insurance in medical_AppointmentContext.InsuranceProviders

                                     select new InsuranceProvidersModel()
                                     {
                                         InsuranceProviderID = insurance.InsuranceProviderID,
                                         Name = insurance.Name,
                                         ContactNumber = insurance.ContactNumber,
                                         Email = insurance.Email,
                                         Website = insurance.Website,
                                         Address = insurance.Address,
                                         City = insurance.City,
                                         State = insurance.State,
                                         ZipCode = insurance.ZipCode,
                                         LogoUrl = insurance.LogoUrl,
                                         IsPreferred = insurance.IsPreferred

                                     }).AsNoTracking()
                                     .ToListAsync();

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniedo los datos";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }
        public async override Task<OperationResult> Remove(InsuranceProviders entity)
        {
            OperationResult result = new OperationResult();
            if (entity == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;

            }

            if (entity.InsuranceProviderID == 0)
            {
                result.Success = false;
                result.Message = " Se requiere el InsuranceProviderID es requerido para realizar esta accion ";
                return result;
            }

            try
            {
                InsuranceProviders? insuranceProvidersToRemove = await medical_AppointmentContext.InsuranceProviders.FindAsync(entity.InsuranceProviderID);

                insuranceProvidersToRemove.InsuranceProviderID = entity.InsuranceProviderID;
                insuranceProvidersToRemove.Name = entity.Name;
                insuranceProvidersToRemove.ContactNumber = entity.ContactNumber;
                insuranceProvidersToRemove.Email = entity.Email;
                insuranceProvidersToRemove.Website = entity.Website;
                insuranceProvidersToRemove.Address = entity.Address;
                insuranceProvidersToRemove.City = entity.City;
                insuranceProvidersToRemove.State = entity.State;
                insuranceProvidersToRemove.Country = entity.Country;
                insuranceProvidersToRemove.ZipCode = entity.ZipCode;
                insuranceProvidersToRemove.CoverageDetails = entity.CoverageDetails;
                insuranceProvidersToRemove.LogoUrl = entity.LogoUrl;
                insuranceProvidersToRemove.IsPreferred = entity.IsPreferred;

                await base.Update(insuranceProvidersToRemove);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error al mover el seguro";
                logger.LogError(result.Message, ToString());


            }
            return result;
        }


             public async override Task<OperationResult> GetEntityBy(int ID)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = await (from insurance in medical_AppointmentContext.InsuranceProviders
                                     where insurance.InsuranceProviderID == ID
                                     select new InsuranceProvidersModel()
                                     {
                                         InsuranceProviderID = insurance.InsuranceProviderID,
                                         Name = insurance.Name,
                                         ContactNumber = insurance.ContactNumber,
                                         Email = insurance.Email,
                                         Website = insurance.Website,
                                         Address = insurance.Address,
                                         City = insurance.City,
                                         State = insurance.State,
                                         ZipCode = insurance.ZipCode,
                                         LogoUrl = insurance.LogoUrl,
                                         IsPreferred = insurance.IsPreferred

                                     }).AsNoTracking()
                                     .ToListAsync();

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniedo los datos";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public Task Save(InsuranceProvidersRepository insures)
        {
            throw new NotImplementedException();
        }
    }
}

