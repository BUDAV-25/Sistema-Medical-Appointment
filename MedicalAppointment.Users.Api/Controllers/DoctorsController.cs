using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Persistance.Interfaces.users;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsRepository doctors_Repository;
        public DoctorsController(IDoctorsRepository doctorsRepository) 
        {
            doctors_Repository = doctorsRepository;
        }
        // GET: api/<DoctorsController>
        [HttpGet("GetAllDoctors")]
        public async Task<IActionResult> Get()
        {
            var result = await doctors_Repository.GetAll();

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<DoctorsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DoctorsController>
        [HttpPost("SaveDoctors")]
        public async Task<IActionResult> Post([FromBody] Doctors doctors)
        {
            var result = await doctors_Repository.Save(doctors);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // PUT api/<DoctorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DoctorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
