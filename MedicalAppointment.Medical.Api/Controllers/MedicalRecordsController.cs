using MedicalAppointment.Domain.Entities.medical;
using MedicalAppointment.Persistance.Interfaces.medical;
using MedicalAppointment.Persistance.Repositories.medical;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointment.Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IMedicalRecordsRepository medical_RecordsRepository;
        public  MedicalRecordsController(IMedicalRecordsRepository medicalRecordsRepository)
        {
            medical_RecordsRepository = medicalRecordsRepository;
        }
        // GET: api/<MedicalRecordsController>
        [HttpGet("Get All Medical records")]
        public async Task<IActionResult> Get()
        {
            var result = await medical_RecordsRepository.GetAll();

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<MedicalRecordsController>/5
        [HttpGet("Get Medical records by{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await medical_RecordsRepository.GetEntityBy(id);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // POST api/<MedicalRecordsController>
        [HttpPost("Save Medical record")]
        public async Task<IActionResult> Post([FromBody] MedicalRecords records)
        {
            var result = await medical_RecordsRepository.Save(records);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // PUT api/<MedicalRecordsController>/5
        [HttpPut("Update  Record by{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MedicalRecords records)
        {
            records.RecordID = id;
            var result = await medical_RecordsRepository.Update(records);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // DELETE api/<MedicalRecordsController>/5
        [HttpDelete("Remove by {id}")]
        public async Task<IActionResult> Delete(int id, MedicalRecords records)
        {
            records.RecordID = id;
            var result = await medical_RecordsRepository.Remove(records);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
