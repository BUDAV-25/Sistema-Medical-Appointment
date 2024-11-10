using MedicalAppointment.Domain.Entities.medical;
using MedicalAppointment.Persistance.Interfaces.medical;
using MedicalAppointment.Persistance.Repositories.medical;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointment.Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtiesController : ControllerBase
    {
        private readonly ISpecialtiesRepository specialties_Repository;
        public SpecialtiesController(ISpecialtiesRepository specialtiesRepository)
        {
            specialties_Repository = specialtiesRepository;
        }

        // GET: api/<SpecialtiesController>
        [HttpGet("Get All Specialties")]
        public async Task<IActionResult> Get()
        {
            var result = await specialties_Repository.GetAll();

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<SpecialtiesController>/5
        [HttpGet("Get Specialty by {id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await specialties_Repository.GetEntityBy(id);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // POST api/<SpecialtiesController>
        [HttpPost("Save Specialty")]
        public async Task<IActionResult> Post([FromBody] Specialties specialties)
        {
            var result = await specialties_Repository.Save(specialties);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // PUT api/<SpecialtiesController>/5
        [HttpPut("Update Specialty by {id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Specialties specialties)
        {
            var result = await specialties_Repository.Update(specialties);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // DELETE api/<SpecialtiesController>/5
        [HttpDelete("Remove Specialty by {id}")]
        public async Task<IActionResult> Delete(int id, Specialties specialties)
        {
            var result = await specialties_Repository.Remove(specialties);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
