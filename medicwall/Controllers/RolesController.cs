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
    public class RolesController : ControllerBase
    {
        private readonly IMedicwallRepository<Role> _roleRepository;

        public RolesController(IMedicwallRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // GET: api/roles
        [HttpGet]
        public ActionResult<IEnumerable<Role>> GetAllRoles()
        {
            IEnumerable<Role> role = _roleRepository.GetAll();
            return Ok(role);
        }

        // GET: api/roles/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _roleRepository.Get(id);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        //api/roles/1
        [HttpPut("{id}")]
        public async Task<ActionResult<Role>> UpdateRoleAsync(int id, Role role)
        {

            if (id != role.Id)
            {
                return BadRequest();
            }

            var updateReturn = await _roleRepository.Update(id, role);

            if (updateReturn != null)
            {
                return Ok(role);
            }

            return BadRequest();
        }

        //api/roles
        [HttpPost]
        public async Task<ActionResult<Role>> AddRoleAsync(Role role)
        {
            var addReturn = await _roleRepository.Add(role);

            if (addReturn != null)
            {
                return CreatedAtAction("GetRole", new { id = role.Id }, role);
            }

            return BadRequest();
        }

        // DELETE: api/roles/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> DeleteRoleAsync(int id)
        {
            var role = await _roleRepository.Get(id);
            if (role == null)
            {
                return NotFound();
            }

            var deleteReturn = _roleRepository.Delete(role);

            if (deleteReturn != null)
            {
                return CreatedAtAction("GetRole", new { id = role.Id }, role);
            }

            return BadRequest();

        }
    }
}
