using Microsoft.EntityFrameworkCore;
using medicwall.Models;
using medicwall.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medicwall.Repositories.Implementation
{
    public class ExpertiseRepository : IMedicwallRepository<Expertise>
    {

            readonly medicwallContext _medicwallContext;

            public ExpertiseRepository(medicwallContext context)
            {
                _medicwallContext = context;
            }

        public IEnumerable<Expertise> GetAll()
        {
                return _medicwallContext.Expertise.ToList();
        }

        public async Task<Expertise> Get(int id)
        {
            var expertise = await _medicwallContext.Expertise.FindAsync(id);
            return expertise;
        }

        public object Update(int id, Expertise expertise)
        {
            _medicwallContext.Entry(expertise).State = EntityState.Modified;

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

            return expertise;

        }

        public async Task<Expertise> Update(int id, object obj)
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
            return _medicwallContext.Expertise.Any(e => e.Id == id);
        }

        public async Task<Expertise> Add(object obj)
        {
            _medicwallContext.Expertise.Add((Expertise)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (Expertise)obj;
        }

        public async Task<Expertise> Delete(object obj)
        {
            _medicwallContext.Expertise.Remove((Expertise)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (Expertise)obj;
        }

      
    }
}
