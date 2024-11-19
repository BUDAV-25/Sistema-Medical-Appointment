using MedicalAppointment.Application.Contracts.system;
using MedicalAppointment.Application.Dtos.system.Notification;
using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Persistance.Interfaces.system;
using Microsoft.AspNetCore.Mvc;
using MedicalAppointment.IOC.Dependencies.system;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalApp.System.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // GetAll Notifications
        [HttpGet("GetAllNotifications")]
        public async Task<IActionResult> Get()
        {
            var result = await _notificationService.GetAll();

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Get Entity By Notifications
        [HttpGet("GetNotificationsBy{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _notificationService.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Save Notifications
        [HttpPost("SaveNotifications")]
        public async Task<IActionResult> Post([FromBody] NotificationSaveDto notificationSaveDto)
        {
            var result = await _notificationService.SaveAsync(notificationSaveDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Update Notifications
        [HttpPut("UpdateNotifications{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] NotificationUpdateDto notificationUpdateDto)
        {
            var result = await _notificationService.UpdateAsync(notificationUpdateDto);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
