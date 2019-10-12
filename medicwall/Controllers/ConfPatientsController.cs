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
    public class ConfPatientsController : ControllerBase
    {
        private readonly IMedicwallRepository<ConfPatient> _confPatientRepository;

        public ConfPatientsController(IMedicwallRepository<ConfPatient> confPatientRepository)
        {
            _confPatientRepository = confPatientRepository;
        }

        // GET: api/confPatients
        [HttpGet]
        public ActionResult<IEnumerable<ConfPatient>> GetAllConfPatients()
        {
            IEnumerable<ConfPatient> confPatient = _confPatientRepository.GetAll();
            return Ok(confPatient);
        }

        // GET: api/confPatients/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfPatient>> GetConfPatient(int id)
        {
            var confPatient = await _confPatientRepository.Get(id);
            if (confPatient == null)
            {
                return NotFound();
            }

            return Ok(confPatient);
        }

        //api/confPatients/1
        [HttpPut("{id}")]
        public async Task<ActionResult<ConfPatient>> UpdateConfPatientAsync(int id, ConfPatient confPatient)
        {

            if (id != confPatient.Id)
            {
                return BadRequest();
            }

            var updateReturn = await _confPatientRepository.Update(id, confPatient);

            if (updateReturn != null)
            {
                return Ok(confPatient);
            }

            return BadRequest();
        }

        //api/confPatients
        [HttpPost]
        public async Task<ActionResult<ConfPatient>> AddConfPatientAsync(ConfPatient confPatient)
        {
            var addReturn = await _confPatientRepository.Add(confPatient);

            if (addReturn != null)
            {
                return CreatedAtAction("GetConfPatient", new { id = confPatient.Id }, confPatient);
            }

            return BadRequest();
        }

        // DELETE: api/confPatients/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConfPatient>> DeleteConfPatientAsync(int id)
        {
            var confPatient = await _confPatientRepository.Get(id);
            if (confPatient == null)
            {
                return NotFound();
            }

            var deleteReturn = _confPatientRepository.Delete(confPatient);

            if (deleteReturn != null)
            {
                return CreatedAtAction("GetConfPatient", new { id = confPatient.Id }, confPatient);
            }

            return BadRequest();

        }
    }
}
