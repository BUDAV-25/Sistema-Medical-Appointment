﻿using MedicalAppointment.Application.Contracts.medical;
using MedicalAppointment.Application.Dtos.medical.AvailabilityModes;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityModesController : ControllerBase
    {
        private readonly IAvailabilityModesService availability_ModesService;
        public AvailabilityModesController(IAvailabilityModesService availabilityModesService)
        {
            availability_ModesService = availabilityModesService;
        }
        // GET: api/<AvailabilityModesController>
        [HttpGet("GetAllAvailabilityModes")]
        public async Task<IActionResult> Get()
        {
            var result = await availability_ModesService.GetAll();

            if(!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<AvailabilityModesController>/5
        [HttpGet("GetAvailabilityby{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await availability_ModesService.GetById(id);

            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

        // POST api/<AvailabilityModesController>
        [HttpPost("SaveAvailability")]
        public async Task<IActionResult> Post([FromBody] AvailabilityModesSaveDto dto)
        {
            var result = await availability_ModesService.SaveAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

        // PUT api/<AvailabilityModesController>/5
        [HttpPut("UpdateAvailability")]
        public async Task<IActionResult> Put([FromBody] AvailabilityModesUpdateDto dto)
        {
            var result = await availability_ModesService.UpdateAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
