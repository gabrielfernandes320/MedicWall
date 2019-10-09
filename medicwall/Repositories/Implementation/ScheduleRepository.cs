using Microsoft.EntityFrameworkCore;
using medicwall.Models;
using medicwall.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medicwall.Repositories.Implementation
{
    public class ScheduleRepository : IMedicwallRepository<Schedule>
    {

            readonly medicwallContext _medicwallContext;

            public ScheduleRepository(medicwallContext context)
            {
                _medicwallContext = context;
            }

        public IEnumerable<Schedule> GetAll()
        {
                return _medicwallContext.Schedule.ToList();
        }

        public async Task<Schedule> Get(int id)
        {
            var schedule = await _medicwallContext.Schedule.FindAsync(id);
            return schedule;
        }

        public object Update(int id, Schedule schedule)
        {
            _medicwallContext.Entry(schedule).State = EntityState.Modified;

            try
            {
                _medicwallContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return schedule;

        }

        public async Task<Schedule> Update(int id, object obj)
        {
            _medicwallContext.Entry(obj).State = EntityState.Modified;
          
            try
            {
               await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return await Get(id);

        }

        public bool Exists(int id)
        {
            return _medicwallContext.Schedule.Any(e => e.Id == id);
        }

        public async Task<Schedule> Add(object obj)
        {
            _medicwallContext.Schedule.Add((Schedule)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (Schedule)obj;
        }

        public async Task<Schedule> Delete(object obj)
        {
            _medicwallContext.Schedule.Remove((Schedule)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (Schedule)obj;
        }

      
    }
}
