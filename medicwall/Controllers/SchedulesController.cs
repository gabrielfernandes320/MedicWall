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
    public class SchedulesController : ControllerBase
    {
        private readonly IMedicwallRepository<Schedule> _scheduleRepository;

        public SchedulesController(IMedicwallRepository<Schedule> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        // GET: api/schedules
        [HttpGet]
        public ActionResult<IEnumerable<Schedule>> GetAllSchedules()
        {
            IEnumerable<Schedule> schedule = _scheduleRepository.GetAll();
            return Ok(schedule);
        }

        // GET: api/schedules/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetSchedule(int id)
        {
            var schedule = await _scheduleRepository.Get(id);
            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule);
        }

        //api/schedules/1
        [HttpPut("{id}")]
        public async Task<ActionResult<Schedule>> UpdateScheduleAsync(int id, Schedule schedule)
        {

            if (id != schedule.Id)
            {
                return BadRequest();
            }

            var updateReturn = await _scheduleRepository.Update(id, schedule);

            if (updateReturn != null)
            {
                return Ok(schedule);
            }

            return BadRequest();
        }

        //api/schedules
        [HttpPost]
        public async Task<ActionResult<Schedule>> AddScheduleAsync(Schedule schedule)
        {
            var addReturn = await _scheduleRepository.Add(schedule);

            if (addReturn != null)
            {
                return CreatedAtAction("GetSchedule", new { id = schedule.Id }, schedule);
            }

            return BadRequest();
        }

        // DELETE: api/schedules/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Schedule>> DeleteScheduleAsync(int id)
        {
            var schedule = await _scheduleRepository.Get(id);
            if (schedule == null)
            {
                return NotFound();
            }

            var deleteReturn = _scheduleRepository.Delete(schedule);

            if (deleteReturn != null)
            {
                return CreatedAtAction("GetSchedule", new { id = schedule.Id }, schedule);
            }

            return BadRequest();

        }
    }
}
