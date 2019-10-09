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
            private readonly IMedicwallRepository<ConfDoctor> _confDoctorRepository;

            public ConfDoctorController(IMedicwallRepository<ConfDoctor> confDoctorRepository)
            {
                _confDoctorRepository = confDoctorRepository;
            }

            // GET: api/confDoctor
            [HttpGet]
            public ActionResult<IEnumerable<ConfDoctor>> GetAllConfDoctors()
            {
                IEnumerable<ConfDoctor> confDoctor = _confDoctorRepository.GetAll();
                return Ok(confDoctor);
            }

            // GET: api/confDoctor/1
            [HttpGet("{id}")]
            public async Task<ActionResult<ConfDoctor>> GetConfDoctor(int id)
            {
                var confDoctor = await _confDoctorRepository.Get(id);
                if (confDoctor == null)
                {
                    return NotFound();
                }

                return Ok(confDoctor);
            }

            //api/confDoctor/1
            [HttpPut("{id}")]
            public async Task<ActionResult<ConfDoctor>> UpdateConfDoctorAsync(int id, ConfDoctor confDoctor)
            {

                if (id != confDoctor.Id)
                {
                    return BadRequest();
                }

                var updateReturn = await _confDoctorRepository.Update(id, confDoctor);

                if (updateReturn != null)
                {
                    return Ok(confDoctor);
                }

                return BadRequest();
            }

            //api/confDoctor
            [HttpPost]
            public async Task<ActionResult<ConfDoctor>> AddConfDoctorAsync(ConfDoctor confDoctor)
            {
                var addReturn = await _confDoctorRepository.Add(confDoctor);

                if (addReturn != null)
                {
                    return CreatedAtAction("GetConfDoctor", new { id = confDoctor.Id }, confDoctor);
                }

                return BadRequest();
            }

            // DELETE: api/confDoctor/1
            [HttpDelete("{id}")]
            public async Task<ActionResult<ConfDoctor>> DeleteConfDoctorAsync(int id)
            {
                var confDoctor = await _confDoctorRepository.Get(id);
                if (confDoctor == null)
                {
                    return NotFound();
                }

                var deleteReturn = _confDoctorRepository.Delete(confDoctor);

                if (deleteReturn != null)
                {
                    return CreatedAtAction("GetConfDoctor", new { id = confDoctor.Id }, confDoctor);
                }

                return BadRequest();

            }
        }
    }

