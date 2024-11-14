using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Persistance.Interfaces.users;
using MedicalAppointment.Persistance.Repositories.users;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointment.Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository patient_Repository;
        public PatientsController(IPatientRepository patient) 
        {
            patient_Repository = patient;
        }
        // GET: api/<PatientsController>
        [HttpGet("Get All Patients")]
        public async Task<IActionResult> Get()
        {
            var result = await patient_Repository.GetAll();

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<PatientsController>/5
        [HttpGet("Get Patient by {id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await patient_Repository.GetEntityBy(id);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // POST api/<PatientsController>
        [HttpPost("Save Patient")]
        public async Task<IActionResult> Post([FromBody] Patient patient)
        {
            var result = await patient_Repository.Save(patient);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // PUT api/<PatientsController>/5
        [HttpPut("Update Patient {id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Patient patient)
        {
            var result = await patient_Repository.Update(patient);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // DELETE api/<PatientsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Patient patient)
        {
            var result = await patient_Repository.Remove(patient);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
