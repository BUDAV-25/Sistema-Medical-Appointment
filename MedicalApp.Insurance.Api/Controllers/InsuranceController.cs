using MedicalAppointment.Domain.Entities.Insurance;
using MedicalAppointment.Persistance.Interfaces.Insurance;
using MedicalAppointment.Persistance.Models.Insurance;
using MedicalAppointment.Persistance.Repositories.Insurance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalApp.Insurance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private IInsuranceProvidersRepository _insuranceProviders;

        public InsuranceController(IInsuranceProvidersRepository insuranceProviders)
        {
            this._insuranceProviders = insuranceProviders;
        }
        // GET: api/<InsuranceController>
        [HttpGet("GetInsurance")]
        public async Task<IActionResult> Get()
        {
            var result = await _insuranceProviders.GetAll();
            if (!result.Success)
                return BadRequest();

            return Ok(result);


        }
        // GET api/<InsuranceController>/5
        [HttpGet("Get Insurance by{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _insuranceProviders.GetEntityBy(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        // POST api/<InsuranceController>
        [HttpPost("Save insurance")]
        public async Task<IActionResult> Post([FromBody] InsuranceProviders insures)
        {
            var result = await _insuranceProviders.Save(insures);

            if (!result.Success)
                return BadRequest(result);
                return Ok(result);

        }
        

        // PUT api/<InsuranceController>/5
        [HttpPut("ModifyInsurance")]
        public async Task<IActionResult> put([FromBody] InsuranceProviders insures)
        {
            var result = await _insuranceProviders.Update(insures);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);

        }

        // DELETE api/<InsuranceController>/5
        [HttpDelete("DisableInsurance")]
        public async Task<IActionResult> DisableInsurance(InsuranceProviders insurance) 
        {
        
            var result = await _insuranceProviders.Remove(insurance);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
