using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using medicwall.Models;
using medicwall.Repositories.Contract;

namespace medicwall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMedicwallRepository<User> _userRepository;

        public UsersController(IMedicwallRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            IEnumerable<User> user = _userRepository.GetAll();
            return Ok(user);
        }

        // GET: api/users/1
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepository.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        //api/users/1
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUserAsync(int id, User user)
        {

            if (id != user.Id)
            {
                return BadRequest();
            }

            var updateReturn = await _userRepository.Update(id, user);

            if (updateReturn != null)
            {
                return Ok(user);
            }

            return BadRequest();
        }

        //api/users
        [HttpPost]
        public async Task<ActionResult<User>> AddUserAsync(User user)
        {
            var addReturn = await _userRepository.Add(user);

            if (addReturn != null)
            {
                return CreatedAtAction("GetUser", new { id = user.Id }, user);
            }

            return BadRequest();
        }

        // DELETE: api/users/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUserAsync(int id)
        {
            var user = await _userRepository.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            var deleteReturn = _userRepository.Delete(user);

            if (deleteReturn != null)
            {
                return CreatedAtAction("GetUser", new { id = user.Id }, user);
            }

            return BadRequest();

        }
    }
}
