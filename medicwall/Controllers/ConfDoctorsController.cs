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
    public class ConfDoctorController : ControllerBase
    {
        private readonly IMedicwallRepository<ConfDoctor> _confDoctorsRepository;

        public ConfDoctorController(IMedicwallRepository<ConfDoctor> confDoctorsRepository)
        {
            _confDoctorsRepository = confDoctorsRepository;
        }

        // GET: api/confDoctors
        [HttpGet]
        public ActionResult<IEnumerable<ConfDoctor>> GetAllConfDoctors()
        {
            IEnumerable<ConfDoctor> confDoctors = _confDoctorsRepository.GetAll();
            return Ok(confDoctors);
        }

        // GET: api/confDoctors/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfDoctor>> GetConfDoctor(int id)
        {
            var confDoctors = await _confDoctorsRepository.Get(id);
            if (confDoctors == null)
            {
                return NotFound();
            }

            return Ok(confDoctors);
        }

        //api/confDoctors/1
        [HttpPut("{id}")]
        public async Task<ActionResult<ConfDoctor>> UpdateConfDoctorAsync(int id, ConfDoctor confDoctors)
        {

            if (id != confDoctors.Id)
            {
                return BadRequest();
            }

            var updateReturn = await _confDoctorsRepository.Update(id, confDoctors);

            if (updateReturn != null)
            {
                return Ok(confDoctors);
            }

            return BadRequest();
        }

        //api/confDoctors
        [HttpPost]
        public async Task<ActionResult<ConfDoctor>> AddConfDoctorAsync(ConfDoctor confDoctors)
        {
            var addReturn = await _confDoctorsRepository.Add(confDoctors);

            if (addReturn != null)
            {
                return CreatedAtAction("GetConfDoctor", new { id = confDoctors.Id }, confDoctors);
            }

            return BadRequest();
        }

        // DELETE: api/confDoctors/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConfDoctor>> DeleteConfDoctorAsync(int id)
        {
            var confDoctors = await _confDoctorsRepository.Get(id);
            if (confDoctors == null)
            {
                return NotFound();
            }

            var deleteReturn = _confDoctorsRepository.Delete(confDoctors);

            if (deleteReturn != null)
            {
                return CreatedAtAction("GetConfDoctor", new { id = confDoctors.Id }, confDoctors);
            }

            return BadRequest();

        }
    }
}

