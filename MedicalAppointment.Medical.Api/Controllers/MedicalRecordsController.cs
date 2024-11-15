using MedicalAppointment.Application.Contracts.medical;
using MedicalAppointment.Application.Dtos.medical.MedicalRecords;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IMedicalRecordsService medical_RecordsService;
        public  MedicalRecordsController(IMedicalRecordsService medicalRecordsService)
        {
            medical_RecordsService = medicalRecordsService;
        }
        // GET: api/<MedicalRecordsController>
        [HttpGet("Get All Medical records")]
        public async Task<IActionResult> Get()
        {
            var result = await medical_RecordsService.GetAll();

            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<MedicalRecordsController>/5
        [HttpGet("Get Medical records by{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await medical_RecordsService.GetById(id);

            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

        // POST api/<MedicalRecordsController>
        [HttpPost("Save Medical record")]
        public async Task<IActionResult> Post([FromBody] MedicalRecordsSaveDto dto)
        {
            var result = await medical_RecordsService.SaveAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

        // PUT api/<MedicalRecordsController>/5
        [HttpPut("Update  Record by{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MedicalRecordsUpdateDto dto)
        {
            dto.RecordID = id;
            var result = await medical_RecordsService.UpdateAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
