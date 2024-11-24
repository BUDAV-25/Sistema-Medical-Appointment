using MedicalAppointment.Domain.Entities.Insurance;
using MedicalAppointment.Persistance.Interfaces.Insurance;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalApp.Insurance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworktypeController : ControllerBase 
    {
        private INetworkTypeRepository _typeRepository;

        public NetworktypeController(INetworkTypeRepository typeRepository)
        {
            this._typeRepository = typeRepository;
        }

        // GET: api/<NetworktypeController>

        [HttpGet("GetNetworktype")]
        public async Task< IActionResult> Get()
        {
           var result = await _typeRepository.GetAll();
            if(!result.Success) 
                return BadRequest();

            return Ok(result);
        }

        // GET api/<NetworktypeController>/5
        [HttpGet("Get Networktype by{id}")]

        public async Task<IActionResult> Get(int id) 
        {
            var result = await _typeRepository.GetEntityBy(id);
                if (!result.Success)
                    return BadRequest(result);
                return Ok(result);
            }

        // POST api/<NetworktypeController>
        [HttpPost("Save Networktype")]
        public async Task<IActionResult> post([FromBody] NetworkType networkType)
        {
            var result = await _typeRepository.Save(networkType);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);

        }

        // PUT api/<InsuranceController>/5
        [HttpPut("ModifyNeworktype")]
        public async Task<IActionResult> put([FromBody] NetworkType networkType)
        {
            var result = await _typeRepository.Update(networkType);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);

        }

        // DELETE api/<InsuranceController>/5
        [HttpDelete("DisableNetworktype")]
        public async Task<IActionResult> DisableInsurance(NetworkType networkType)
        {

            var result = await _typeRepository.Remove(networkType);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
