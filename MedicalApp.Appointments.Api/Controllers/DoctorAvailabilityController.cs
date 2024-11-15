using MedicalAppointment.Application.Contracts.appointments;
using MedicalAppointment.Application.Dtos.appointments.DoctorAvailability;
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
        private readonly IDoctorAvailabilityService _doctorAvailabilityService;

        public DoctorAvailabilityController(IDoctorAvailabilityService doctorAvailabilityService)
        {
            _doctorAvailabilityService = doctorAvailabilityService;
        }
        // GetAll DoctorAvailability
        [HttpGet("GetAllDoctorAvailabity")]
        public async Task<IActionResult> Get()
        {
            var result = await _doctorAvailabilityService.GetAll();

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GetEntityBy DoctorAvailability
        [HttpGet("GetEntityBy{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _doctorAvailabilityService.GetById(id);

            if (!result.IsSuccess) 
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Save DoctorAvailability
        [HttpPost("SaveDoctorAvailability")]
        public async Task<IActionResult> Post([FromBody] DoctorAvailabilitySaveDto doctorAvailabilitySaveDto)
        {
            var result = await _doctorAvailabilityService.SaveAsync(doctorAvailabilitySaveDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Update DoctorAvailability
        [HttpPut("UpdateDoctorAvailability")]
        public async Task<IActionResult> Put(int id, [FromBody] DoctorAvailabilityUpdateDto doctorAvailabilityUpdateDto)
        {
            var result = await _doctorAvailabilityService.UpdateAsync(doctorAvailabilityUpdateDto);

            if (!result.IsSuccess) 
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
