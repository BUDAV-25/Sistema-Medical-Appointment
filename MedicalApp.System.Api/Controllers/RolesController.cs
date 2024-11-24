using MedicalAppointment.Application.Contracts.system;
using MedicalAppointment.Application.Dtos.system.Roles;
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
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        // GetAll Roles
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> Get()
        {
            var result = await _rolesService.GetAll();

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GetEntityBy Roles
        [HttpGet("GetRolesBy{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _rolesService.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Save Roles
        [HttpPost("SaveRoles")]
        public async Task<IActionResult> Post([FromBody] RolesSaveDto rolesSaveDto)
        {
            var result = await _rolesService.SaveAsync(rolesSaveDto);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Update Roles
        [HttpPut("UpdateRoles{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RolesUpdateDto rolesUpdateDto)
        {
            rolesUpdateDto.UpdateAt = DateTime.Now;

            var result = await _rolesService.UpdateAsync(rolesUpdateDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
