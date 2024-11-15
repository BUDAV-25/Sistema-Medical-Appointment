﻿using MedicalAppointment.Application.Contracts.users;
using MedicalAppointment.Application.Dtos.users.Doctor;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService doctor_Service;
        public DoctorController(IDoctorService doctorService) 
        {
            doctor_Service = doctorService;
        }
        
        // GET: api/<DoctorsController>
        [HttpGet("Get All Doctors")]
        public async Task<IActionResult> Get()
        {
            var result = await doctor_Service.GetAll();

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<DoctorsController>/5
        [HttpGet("Get Doctor by {id}")]
        public async Task<IActionResult> GetEntityBy(int id)
        {
            var result = await doctor_Service.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // POST api/<DoctorsController>
        [HttpPost("SaveDoctor")]
        public async Task<IActionResult> Post([FromBody] DoctorSaveDto dto)
        {
            var result = await doctor_Service.SaveAsync(dto);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<DoctorsController>/5
        [HttpPut("UpdateDoctor by {id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DoctorUpdateDto dto)
        {
            dto.DoctorID = id;
            var result = await doctor_Service.UpdateAsync(dto);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
