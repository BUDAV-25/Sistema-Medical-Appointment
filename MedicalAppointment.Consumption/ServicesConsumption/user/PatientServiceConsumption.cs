using MedicalAppointment.Application.Dtos.users.Patient;
using MedicalAppointment.Consumption.Base;
using MedicalAppointment.Consumption.ContractsConsumption.users;
using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Web.ModelsMethods.users.PatientTaskModel;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Consumption.ServicesConsumption.user
{
    public class PatientServiceConsumption : IPatientContract
    {
        private readonly IBaseConsumption base_Consumption;
        private readonly ILogger<PatientServiceConsumption> _logger;
        public PatientServiceConsumption(IBaseConsumption baseConsumption, ILogger<PatientServiceConsumption> logger)
        {
            base_Consumption = baseConsumption;
            _logger = logger;
        }
        public async Task<PatientGetAllModel> GetAll()
        {
            PatientGetAllModel patientGetAllModel = new PatientGetAllModel();
            try
            {
                patientGetAllModel = await base_Consumption.GetAllConsumption<PatientGetAllModel>("Patient/GetAllPatients");
            }
            catch (Exception ex)
            {
                patientGetAllModel.isOkay = false;
                patientGetAllModel.mensaje = "Error obteniendo los pacientes";
                _logger.LogError(patientGetAllModel.mensaje, ex.ToString());
            }
            return patientGetAllModel;
        }
        public async Task<PatientGetByIdModel> GetById(int id)
        {
            PatientGetByIdModel patientGetByIdModel = new PatientGetByIdModel();
            try
            {
                patientGetByIdModel = await base_Consumption.GetByIdConsumption<PatientGetByIdModel>($"Patient/GetPatientby{id}");
            }
            catch (Exception ex)
            {
                patientGetByIdModel.isOkay = false;
                patientGetByIdModel.mensaje = "Error obteniendo el paciente";
                _logger.LogError(patientGetByIdModel.mensaje, ex.ToString());
            }
            return patientGetByIdModel;
        }
        public async Task<PatientSaveDto> Save(PatientSaveDto patientSave)
        {
            BaseResponseConsumption model = new BaseResponseConsumption();
            try
            {
                patientSave.CreatedAt = DateTime.Now;
                var response = await base_Consumption.SaveConsumption<PatientSaveDto>("Patient/SavePatient", patientSave);
            }
            catch (Exception ex)
            {
                model.isOkay = false;
                model.mensaje = "Error guardando el paciente";
                _logger.LogError(model.mensaje, ex.ToString());
            }
            return patientSave;
        }
        public async Task<PatientUpdateDto> Update(PatientUpdateDto patientUpdate)
        {
            BaseResponseConsumption model = new BaseResponseConsumption();
            try
            {
                patientUpdate.UpdatedAt = DateTime.Now;
                var result = await base_Consumption.UpdateConsumption<PatientUpdateDto>("Patient/UpdatePatient", patientUpdate);
            }
            catch (Exception ex)
            {
                model.isOkay = false;
                model.mensaje = "Error actualizando el paciente";
                _logger.LogError(model.mensaje, ex.ToString());
            }
            return patientUpdate;
        }
    }
}
