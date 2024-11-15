using MedicalAppointment.Application.Contracts.users;
using MedicalAppointment.Application.Dtos.users.Patient;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService patient_Service;
        public PatientController(IPatientService patientService) 
        {
            patient_Service = patientService;
        }

        // GET: api/<PatientsController>
        [HttpGet("Get All Patients")]
        public async Task<IActionResult> Get()
        {
            var result = await patient_Service.GetAll();

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<PatientsController>/5
        [HttpGet("Get Patient by {id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await patient_Service.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // POST api/<PatientsController>
        [HttpPost("Save Patient")]
        public async Task<IActionResult> Post([FromBody] PatientSaveDto dto)
        {
            var result = await patient_Service.SaveAsync(dto);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<PatientsController>/5
        [HttpPut("Update Patient {id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PatientUpdateDto dto)
        {
            var result = await patient_Service.UpdateAsync(dto);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
