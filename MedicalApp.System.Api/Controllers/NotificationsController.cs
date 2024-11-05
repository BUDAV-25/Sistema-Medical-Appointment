using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Persistance.Interfaces.system;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalApp.System.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationsRepository _notificationsRepository;

        public NotificationsController(INotificationsRepository notificationRepository)
        {
            _notificationsRepository = notificationRepository;
        }

        // GetAll Notifications
        [HttpGet("GetAllNotifications")]
        public async Task<IActionResult> Get()
        {
            var result = await _notificationsRepository.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Get Entity By Notifications
        [HttpGet("GetNotificationsBy{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _notificationsRepository.GetEntityBy(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Save Notifications
        [HttpPost("SaveNotifications")]
        public async Task<IActionResult> Post([FromBody] Notifications notifications)
        {
            var result = await _notificationsRepository.Save(notifications);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Update Notifications
        [HttpPut("UpdateNotifications{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Notifications notifications)
        {
            var result = await _notificationsRepository.Update(notifications);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Remove Notifications
        [HttpDelete("RemoveNotifications")]
        public async Task<IActionResult> Delete([FromBody] Notifications notifications)
        {
            var result = await _notificationsRepository.Remove(notifications);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
