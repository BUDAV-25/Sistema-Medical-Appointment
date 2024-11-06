using MedicalAppointment.Domain.Entities.medical;
using MedicalAppointment.Persistance.Interfaces.medical;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityModesController : ControllerBase
    {
        private readonly IAvailabilityModesRepository availability_ModesRepository;
        public AvailabilityModesController(IAvailabilityModesRepository availabilityModesRepository)
        {
            availability_ModesRepository = availabilityModesRepository;
        }
        // GET: api/<AvailabilityModesController>
        [HttpGet("Get All AvailabilityModes")]
        public async Task<IActionResult> Get()
        {
            var result = await availability_ModesRepository.GetAll();

            if(!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<AvailabilityModesController>/5
        [HttpGet("Get Availability by{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await availability_ModesRepository.GetEntityBy(id);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // POST api/<AvailabilityModesController>
        [HttpPost("Save Availability")]
        public async Task<IActionResult> Post([FromBody] AvailabilityModes availability)
        {
            var result = await availability_ModesRepository.Save(availability);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // PUT api/<AvailabilityModesController>/5
        [HttpPut("Update Availability {id}")]
        public async Task<IActionResult> Put(short id, [FromBody] AvailabilityModes availability)
        {
            availability.SAvailabilityModeID = id;
            var result = await availability_ModesRepository.Update(availability);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // DELETE api/<AvailabilityModesController>/5
        [HttpDelete("Remove {id}")]
        public async Task<IActionResult> Delete(short id, AvailabilityModes availability)
        {
            availability.SAvailabilityModeID = id;
            var result = await availability_ModesRepository.Remove(availability);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
