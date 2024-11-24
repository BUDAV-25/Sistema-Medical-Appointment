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
        [HttpGet("GetAllPatients")]
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
        [HttpGet("GetPatientby{id}")]
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
        [HttpPost("SavePatient")]
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
        [HttpPut("UpdatePatient")]
        public async Task<IActionResult> Put([FromBody] PatientUpdateDto dto)
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
