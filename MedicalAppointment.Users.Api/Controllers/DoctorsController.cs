using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Persistance.Interfaces.users;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository doctor_Repository;
        public DoctorController(IDoctorRepository doctorsRepository) 
        {
            doctor_Repository = doctorsRepository;
        }
        // GET: api/<DoctorsController>
        [HttpGet("Get All Doctor")]
        public async Task<IActionResult> Get()
        {
            var result = await doctor_Repository.GetAll();

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<DoctorsController>/5
        [HttpGet("Get Doctor by {id}")]
        public async Task<IActionResult> GetEntityBy(int id)
        {
            var result = await doctor_Repository.GetEntityBy(id);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // POST api/<DoctorsController>
        [HttpPost("SaveDoctors")]
        public async Task<IActionResult> Post([FromBody] Doctor doctor)
        {
            var result = await doctor_Repository.Save(doctor);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // PUT api/<DoctorsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Doctor doctor)
        {
            var result = await doctor_Repository.Update(doctor);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // DELETE api/<DoctorsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Doctor doctor)
        {
            var result = await doctor_Repository.Remove(doctor);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
