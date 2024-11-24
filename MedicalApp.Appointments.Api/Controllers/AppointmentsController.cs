using MedicalAppointment.Application.Contracts.appointments;
using MedicalAppointment.Application.Dtos.appointments.Appointments;
using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Persistance.Interfaces.appointments;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalApp.Appointments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsService _appointmentsService;

        public AppointmentsController(IAppointmentsService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        //GetAll Appointments
        [HttpGet("GetAllAppointments")]
        public async Task<IActionResult> Get()
        {
            var result = await _appointmentsService.GetAll();

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // GetEntityBy Appointments
        [HttpGet("GetEntityByAppointments{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _appointmentsService.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Save Appointments
        [HttpPost("SaveAppointments")]
        public async Task<IActionResult> Post([FromBody] AppointmentsSaveDto appointmentsSaveDto)
        {
            var result = await _appointmentsService.SaveAsync(appointmentsSaveDto);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Update Appointments
        [HttpPut("UpdateAppointments")]
        public async Task<IActionResult> Put([FromBody] AppointmentsUpdateDto appointmentsUpdateDto)
        {
            var result = await _appointmentsService.UpdateAsync(appointmentsUpdateDto);

            if (!result.IsSuccess) 
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
