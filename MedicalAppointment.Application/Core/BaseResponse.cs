

namespace MedicalAppointment.Application.Core
{
    public abstract class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string? Messages { get; set; }
    }
}
