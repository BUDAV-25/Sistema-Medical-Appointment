﻿using MedicalAppointment.Application.Contracts.medical;
using MedicalAppointment.Application.Dtos.medical.Specialties;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtiesController : ControllerBase
    {
        private readonly ISpecialtiesService specialties_Service;
        public SpecialtiesController(ISpecialtiesService specialtiesService)
        {
            specialties_Service = specialtiesService;
        }

        // GET: api/<SpecialtiesController>
        [HttpGet("GetAllSpecialties")]
        public async Task<IActionResult> Get()
        {
            var result = await specialties_Service.GetAll();

            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<SpecialtiesController>/5
        [HttpGet("GetSpecialtyby{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await specialties_Service.GetById(id);

            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

        // POST api/<SpecialtiesController>
        [HttpPost("SaveSpecialty")]
        public async Task<IActionResult> Post([FromBody] SpecialtiesSaveDto dto)
        {
            var result = await specialties_Service.SaveAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

        // PUT api/<SpecialtiesController>/5
        [HttpPut("UpdateSpecialtyby")]
        public async Task<IActionResult> Put([FromBody] SpecialtiesUpdateDto dto)
        {
            var result = await specialties_Service.UpdateAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
