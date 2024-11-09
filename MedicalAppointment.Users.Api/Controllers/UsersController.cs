using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Persistance.Interfaces.users;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository user_Repository;
        public UsersController(IUsersRepository user)
        {
            user_Repository = user;
        }
        // GET: api/<UsersController>
        [HttpGet("Get All Users")]
        public async Task<IActionResult> Get()
        {
            var result = await user_Repository.GetAll();

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<UsersController>/5
        [HttpGet("Get User By {id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await user_Repository.GetEntityBy(id);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // Find By Roles api<UsersController>/5
        [HttpGet("Find By Roles")]
        public async Task<IActionResult> FindByRole(int roleId)
        {
            var result = await user_Repository.FindUserRole(roleId);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // POST api/<UsersController>
        [HttpPost ("Save User")]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            var result = await user_Repository.Save(user);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // PUT api/<UsersController>/5
        [HttpPut("Update User By {id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            user.UserID = id;
            var result = await user_Repository.Update(user);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("Remove User{id}")]
        public async Task<IActionResult> Delete(User user)
        {
            var result = await user_Repository.Remove(user);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

    }
}
