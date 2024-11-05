using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Persistance.Interfaces.system;
using MedicalAppointment.Persistance.Repositories.system;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalApp.System.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }


        // GetAll Status
        [HttpGet("GetAllStatus")]
        public async Task<IActionResult> Get()
        {
            var result = await _statusRepository.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GetEntityBy Status
        [HttpGet("GetRolesBy{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _statusRepository.GetEntityBy(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Save Status
        [HttpPost("SaveStatus")]
        public async Task<IActionResult> Post([FromBody] Status status)
        {
            var result = await _statusRepository.Save(status);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Update Status
        [HttpPut("UpdateStatus{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Status status)
        {
            var result = await _statusRepository.Update(status);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Delete Status
        [HttpDelete("RemoveStatus")]
        public async Task<IActionResult> Delete([FromBody] Status status)
        {
            var result = await _statusRepository.Remove(status);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
