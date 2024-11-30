using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.medical;

namespace MedicalAppointment.Consumption.ModelsMethods.medical.MedicalRecordsTaskModel
{
    public class MedicalRecordsGetAllModel : BaseResponseConsumption
    {
        public List<MedicalRecordsModel> Model { get; set; }
    }
}
