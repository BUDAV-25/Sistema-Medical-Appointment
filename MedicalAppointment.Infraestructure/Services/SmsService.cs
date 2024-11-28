using MedicalAppointment.Infraestructure.Interfaces;
using MedicalAppointment.Infraestructure.Models;
using MedicalAppointment.Infraestructure.Nucleo;
using Newtonsoft.Json;
using System.Text;


namespace MedicalAppointment.Infraestructure.Services
{
    public class SmsService : ISmsService
    {
        public async Task<NotificationResult> SendSms(SmsModel smsModel)
        {
            NotificationResult result = new NotificationResult();

            try
            {
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(smsModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                await httpClient.PostAsync("miur", content);
            }
            catch (Exception ex)
            {
                result.Messegue = $"Error enviando el SMS. {ex.Message}";
            }
            return result;
        }
    }
}
