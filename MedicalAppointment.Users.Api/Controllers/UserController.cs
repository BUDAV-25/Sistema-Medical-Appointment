using MedicalAppointment.Application.Contracts.users;
using MedicalAppointment.Application.Dtos.users.User;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService user_Service;
        public UserController(IUserService userService)
        {
            user_Service = userService;
        }
        // GET: api/<UsersController>
        [HttpGet("Get All Users")]
        public async Task<IActionResult> Get()
        {
            var result = await user_Service.GetAll();

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<UsersController>/5
        [HttpGet("Get User By {id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await user_Service.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Find By Roles api<UsersController>/5
       /* [HttpGet("Find By Roles")]
        public async Task<IActionResult> FindByRole(int roleId)
        {
            var result = await user_Service.FindUserRole(roleId);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }*/

        // POST api/<UsersController>
        [HttpPost ("Save User")]
        public async Task<IActionResult> Post([FromBody] UserSaveDto dto)
        {
            var result = await user_Service.SaveAsync(dto);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<UsersController>/5
        [HttpPut("Update User By {id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserUpdateDto dto)
        {
            dto.UserID = id;
            var result = await user_Service.UpdateAsync(dto);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
