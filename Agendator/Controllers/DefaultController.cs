using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendator.Models;
using Agendator.Repositories.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Agendator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendatorController : ControllerBase
    {
        private readonly IAgendatorRepository<Role> _agendatorRepository;

        public AgendatorController(IAgendatorRepository<Role> agendatorRepository)
        {
            _agendatorRepository = agendatorRepository;
        }

        // GET: api/Agendator/GetAllRoles  
        [HttpGet]
        [Route("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            IEnumerable<Role> roles = _agendatorRepository.GetAllRoles();
            return Ok(roles);
        }

    }
}