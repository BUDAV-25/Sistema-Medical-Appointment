

namespace MedicalAppointment.Consumption.IClientService.appointments
{
    public interface IAppointmentsClientService <TModel, TSaveDto, TUpdateDto>
    {
        Task<TModel> GetAppointments();
        Task<TModel> GetAppointmentById(int id);
        Task<TSaveDto> SaveAppointment(TSaveDto saveDto);
        Task<TUpdateDto> UpdateAppointment(TUpdateDto updateDto);
    }
}
