

namespace MedicalAppointment.Application.Core
{
    public abstract class BaseResponse
    {
        public BaseResponse()
        {
            this.IsSuccess = true;
        }
        public bool IsSuccess { get; set; }
        public string? Messages { get; set; }
    }
}
