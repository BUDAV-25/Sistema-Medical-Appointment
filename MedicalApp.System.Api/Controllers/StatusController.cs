using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Persistance.Interfaces.system;
using MedicalAppointment.Persistance.Repositories.system;
using Microsoft.AspNetCore.Mvc;
using MedicalAppointment.Application.Services.System;
using MedicalAppointment.Application.Contracts.system;
using MedicalAppointment.Application.Dtos.system.Status;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalApp.System.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }


        // GetAll Status
        [HttpGet("GetAllStatus")]
        public async Task<IActionResult> Get()
        {
            var result = await _statusService.GetAll();

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GetEntityBy Status
        [HttpGet("GetStatusBy{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _statusService.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Save Status
        [HttpPost("SaveStatus")]
        public async Task<IActionResult> Post([FromBody] StatusSaveDto statusSaveDto)
        {
            var result = await _statusService.SaveAsync(statusSaveDto);
            
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Update Status
        [HttpPut("UpdateStatus{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StatusUpdateDto statusUpdateDto)
        {
            var result = await _statusService.UpdateAsync(statusUpdateDto);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
