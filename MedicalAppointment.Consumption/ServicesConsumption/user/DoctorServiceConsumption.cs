using MedicalAppointment.Application.Dtos.users.Doctor;
using MedicalAppointment.Consumption.Base;
using MedicalAppointment.Consumption.ContractsConsumption.users;
using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Web.Models.users.DoctorTaskModel;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Consumption.ServicesConsumption.user
{
    public class DoctorServiceConsumption : IDoctorContract
    {
        private readonly IBaseConsumption base_Consumption;
        private readonly ILogger<DoctorServiceConsumption> _logger;
        public DoctorServiceConsumption(IBaseConsumption baseConsumption, ILogger<DoctorServiceConsumption> logger)
        {
            base_Consumption = baseConsumption;
            _logger = logger;
        }
        public async Task<DoctorGetAllModel> GetAll()
        {
            DoctorGetAllModel doctorGetAllModel = new DoctorGetAllModel();
            try
            {
                doctorGetAllModel = await base_Consumption.GetAllConsumption<DoctorGetAllModel>("Doctor/GetAllDoctors");
            }
            catch (Exception ex)
            {
                doctorGetAllModel.isOkay = false;
                doctorGetAllModel.mensaje = "Error obteniendo los doctores";
                _logger.LogError(doctorGetAllModel.mensaje, ex.ToString());
            }
            return doctorGetAllModel;
        }

        public async Task<DoctorGetByIdModel> GetById(int id)
        {
            DoctorGetByIdModel doctorGetByIdModel = new DoctorGetByIdModel();
            try
            {
                doctorGetByIdModel = await base_Consumption.GetByIdConsumption<DoctorGetByIdModel>($"Doctor/GetDoctorby{id}");
            }
            catch (Exception ex)
            {
                doctorGetByIdModel.isOkay = false;
                doctorGetByIdModel.mensaje = "Error obteniendo el doctor";
                _logger.LogError(doctorGetByIdModel.mensaje, ex.ToString());
            }
            return doctorGetByIdModel;
        }

        public async Task<DoctorSaveDto> Save(DoctorSaveDto doctorSave)
        {
            BaseResponseConsumption model = new BaseResponseConsumption();
            try
            {
                doctorSave.CreatedAt = DateTime.Now;
                var response = await base_Consumption.SaveConsumption<DoctorSaveDto>("Doctor/SaveDoctor", doctorSave);
            }
            catch (Exception ex)
            {
                model.isOkay = false;
                model.mensaje = "Error guardando el Doctor";
                _logger.LogError(model.mensaje, ex.ToString());
            }
            return doctorSave;
        }

        public async Task<DoctorUpdateDto> Update(DoctorUpdateDto doctorUpdate)
        {
            BaseResponseConsumption model = new BaseResponseConsumption();
            try
            {
                doctorUpdate.UpdatedAt = DateTime.Now;
                var response = await base_Consumption.UpdateConsumption<DoctorUpdateDto>("Doctor/UpdateDoctorby", doctorUpdate);
            }
            catch (Exception ex)
            {
                model.isOkay = false;
                model.mensaje = "Error actualizando el Doctor";
                _logger.LogError(model.mensaje, ex.ToString());
            }
            return doctorUpdate;
        }
    }
}
