using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.medical;

namespace MedicalAppointment.Consumption.ModelsMethods.medical.MedicalRecordsTaskModel
{
    public class MedicalRecordsGetByIdModel : BaseResponseConsumption
    {
        public MedicalRecordsModel Model { get; set; }
    }
}
