using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Persistance.Interfaces.appointments;
using MedicalAppointment.Persistance.Repositories.appointments;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalApp.Appointments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAvailabilityController : ControllerBase
    {
        private readonly IDoctorAvailabilityRepository _doctorAvailabityrepository;

        public DoctorAvailabilityController(IDoctorAvailabilityRepository doctorAvailabityrepository)
        {
            _doctorAvailabityrepository = doctorAvailabityrepository;
        }
        // GetAll DoctorAvailability
        [HttpGet("GetAllDoctorAvailabity")]
        public async Task<IActionResult> Get()
        {
            var result = await _doctorAvailabityrepository.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GetEntityBy DoctorAvailability
        [HttpGet("GetEntityBy{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _doctorAvailabityrepository.GetEntityBy(id);

            if (!result.Success) 
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Save DoctorAvailability
        [HttpPost("SaveDoctorAvailability")]
        public async Task<IActionResult> Post([FromBody] DoctorAvailability doctorAvailability)
        {
            var result = await _doctorAvailabityrepository.Save(doctorAvailability);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Update DoctorAvailability
        [HttpPut("UpdateDoctorAvailability")]
        public async Task<IActionResult> Put(int id, [FromBody] DoctorAvailability doctorAvailability)
        {
            var result = await _doctorAvailabityrepository.Update(doctorAvailability);

            if (!result.Success) 
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Remove DoctorAvailability
        [HttpDelete("RemoveDoctorAvailability")]
        public async Task<IActionResult> Delete([FromBody] DoctorAvailability doctorAvailability)
        {
            var result = await _doctorAvailabityrepository.Remove(doctorAvailability);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
