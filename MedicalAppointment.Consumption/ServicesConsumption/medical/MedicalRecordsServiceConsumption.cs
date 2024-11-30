using MedicalAppointment.Application.Dtos.medical.MedicalRecords;
using MedicalAppointment.Consumption.Base;
using MedicalAppointment.Consumption.ContractsConsumption.medical;
using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Consumption.ModelsMethods.medical.MedicalRecordsTaskModel;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Consumption.ServicesConsumption.medical
{
    public class MedicalRecordsServiceConsumption : IMedicalRecordsContract
    {
        private readonly IBaseConsumption base_Consumption;
        private readonly ILogger<MedicalRecordsServiceConsumption> _logger;
        public MedicalRecordsServiceConsumption(IBaseConsumption baseConsumption, ILogger<MedicalRecordsServiceConsumption> logger)
        {
            base_Consumption = baseConsumption;
            _logger = logger;
        }
        public async Task<MedicalRecordsGetAllModel> GetAll()
        {
            MedicalRecordsGetAllModel model = new MedicalRecordsGetAllModel();
            try
            {
                model = await base_Consumption.GetAllConsumption<MedicalRecordsGetAllModel>("MedicalRecords/GetAllMedicalRecords");
            }
            catch (Exception ex)
            {
                model.isOkay = false;
                model.mensaje = "Error obteniendo los Records";
                _logger.LogError(model.mensaje, ex.ToString());
            }
            return model;
        }
        public async Task<MedicalRecordsGetByIdModel> GetById(int id)
        {
            MedicalRecordsGetByIdModel model = new MedicalRecordsGetByIdModel();
            try
            {
                model = await base_Consumption.GetByIdConsumption<MedicalRecordsGetByIdModel>($"MedicalRecords/GetMedicalRecordsby{id}");
            }
            catch (Exception ex)
            {
                model.isOkay = false;
                model.mensaje = "Error obteniendo el Record";
                _logger.LogError(model.mensaje, ex.ToString());
            }
            return model;
        }
        public async Task<MedicalRecordsSaveDto> Save(MedicalRecordsSaveDto recordSave)
        {
            BaseResponseConsumption model = new BaseResponseConsumption();
            try
            {
                recordSave.CreatedAt = DateTime.Now;
                var result = await base_Consumption.SaveConsumption<MedicalRecordsSaveDto>("MedicalRecords/SaveMedicalRecord", recordSave);
            }
            catch (Exception ex)
            {
                model.isOkay = false;
                model.mensaje = "Error guardando el record";
                _logger.LogError(model.mensaje, ex.ToString());
            }
            return recordSave;
        }
        public async Task<MedicalRecordsUpdateDto> Update(MedicalRecordsUpdateDto recordUpdate)
        {
            BaseResponseConsumption model = new BaseResponseConsumption();
            try
            {
                recordUpdate.UpdatedAt = DateTime.Now;
                var result = await base_Consumption.UpdateConsumption<MedicalRecordsUpdateDto>("MedicalRecords/UpdateRecordby", recordUpdate);
            }
            catch (Exception ex)
            {
                model.isOkay = false;
                model.mensaje = "Error actualizando el record";
                _logger.LogError(model.mensaje, ex.ToString());
            }
            return recordUpdate;
        }
    }
}
