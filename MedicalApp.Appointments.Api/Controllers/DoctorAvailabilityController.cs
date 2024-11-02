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
        // GET: api/<DoctorAvailabilityController>
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

        // GET api/<DoctorAvailabilityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DoctorAvailabilityController>
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

        // PUT api/<DoctorAvailabilityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DoctorAvailabilityController>/5
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
