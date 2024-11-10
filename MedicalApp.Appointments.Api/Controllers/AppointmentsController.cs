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
        private readonly IAppointmentsRepository _appointmentsRepository;

        public AppointmentsController(IAppointmentsRepository appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }

        //GetAll Appointments
        [HttpGet("GetAllAppointments")]
        public async Task<IActionResult> Get()
        {
            var result = await _appointmentsRepository.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // GetEntityBy Appointments
        [HttpGet("GetEntityByAppointments{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _appointmentsRepository.GetEntityBy(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Save Appointments
        [HttpPost("SaveAppointments")]
        public async Task<IActionResult> Post([FromBody] Appointment appointment)
        {
            var result = await _appointmentsRepository.Save(appointment);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Update Appointments
        [HttpPut("UpdateAppointments")]
        public async Task<IActionResult> Put(int id, [FromBody] Appointment appointment)
        {
            var result = await _appointmentsRepository.Update(appointment);

            if (!result.Success) 
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Delete Appointments
        [HttpDelete("RemoveAppointmets{id}")]
        public async Task<IActionResult> Delete([FromBody] Appointment appointment)
        {
            var result = await _appointmentsRepository.Remove(appointment);

            if (!result.Success) 
            {
                return BadRequest(result);
            }
            return Ok();
        }
    }
}
