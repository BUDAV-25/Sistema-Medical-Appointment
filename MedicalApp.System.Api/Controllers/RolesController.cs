using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Persistance.Interfaces.system;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalApp.System.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        // GetAll Roles
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> Get()
        {
            var result = await _rolesRepository.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GetEntityBy Roles
        [HttpGet("GetRolesBy{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _rolesRepository.GetEntityBy(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Save Roles
        [HttpPost("SaveRoles")]
        public async Task<IActionResult> Post([FromBody] Roles roles)
        {
            var result = await _rolesRepository.Save(roles);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Update Roles
        [HttpPut("UpdateRoles{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Roles roles)
        {
            var result = await _rolesRepository.Update(roles);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Delete Roles
        [HttpDelete("RemoveRoles")]
        public async Task<IActionResult> Delete([FromBody] Roles roles)
        {
            var result = await _rolesRepository.Remove(roles);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
