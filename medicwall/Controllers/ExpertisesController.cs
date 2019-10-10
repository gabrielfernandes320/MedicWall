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
    public class ExpertisesController : ControllerBase
    {
        private readonly IMedicwallRepository<Expertise> _expertiseRepository;

        public ExpertisesController(IMedicwallRepository<Expertise> expertiseRepository)
        {
            _expertiseRepository = expertiseRepository;
        }

        // GET: api/expertises
        [HttpGet]
        public ActionResult<IEnumerable<Expertise>> GetAllExpertises()
        {
            IEnumerable<Expertise> expertise = _expertiseRepository.GetAll();
            return Ok(expertise);
        }

        // GET: api/expertises/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Expertise>> GetExpertise(int id)
        {
            var expertise = await _expertiseRepository.Get(id);
            if (expertise == null)
            {
                return NotFound();
            }

            return Ok(expertise);
        }

        //api/expertises/1
        [HttpPut("{id}")]
        public async Task<ActionResult<Expertise>> UpdateExpertiseAsync(int id, Expertise expertise)
        {

            if (id != expertise.Id)
            {
                return BadRequest();
            }

            var updateReturn = await _expertiseRepository.Update(id, expertise);

            if (updateReturn != null)
            {
                return Ok(expertise);
            }

            return BadRequest();
        }

        //api/expertises
        [HttpPost]
        public async Task<ActionResult<Expertise>> AddExpertiseAsync(Expertise expertise)
        {
            var addReturn = await _expertiseRepository.Add(expertise);

            if (addReturn != null)
            {
                return CreatedAtAction("GetExpertise", new { id = expertise.Id }, expertise);
            }

            return BadRequest();
        }

        // DELETE: api/expertises/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Expertise>> DeleteExpertiseAsync(int id)
        {
            var expertise = await _expertiseRepository.Get(id);
            if (expertise == null)
            {
                return NotFound();
            }

            var deleteReturn = _expertiseRepository.Delete(expertise);

            if (deleteReturn != null)
            {
                return CreatedAtAction("GetExpertise", new { id = expertise.Id }, expertise);
            }

            return BadRequest();

        }
    }
}
