

namespace MedicalAppointment.Consumption.Base
{
    public interface IBaseConsumption
    {

        Task<T> GetAllConsumption<T>(string url);
        Task<T> GetByIdConsumption<T>(string url);
        Task<T> SaveConsumption<T>(string url, T data);
        Task<T> UpdateConsumption<T>(string url, T data);


    }
}
