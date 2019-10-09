using Microsoft.EntityFrameworkCore;
using medicwall.Models;
using medicwall.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medicwall.Repositories.Implementation
{
    public class ConfPatientRepository : IMedicwallRepository<ConfPatient>
    {

            readonly medicwallContext _medicwallContext;

            public ConfPatientRepository(medicwallContext context)
            {
                _medicwallContext = context;
            }

        public IEnumerable<ConfPatient> GetAll()
        {
                return _medicwallContext.ConfPatient.ToList();
        }

        public async Task<ConfPatient> Get(int id)
        {
            var confPatient = await _medicwallContext.ConfPatient.FindAsync(id);
            return confPatient;
        }

        public object Update(int id, ConfPatient confPatient)
        {
            _medicwallContext.Entry(confPatient).State = EntityState.Modified;

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

            return confPatient;

        }

        public async Task<ConfPatient> Update(int id, object obj)
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
            return _medicwallContext.ConfPatient.Any(e => e.Id == id);
        }

        public async Task<ConfPatient> Add(object obj)
        {
            _medicwallContext.ConfPatient.Add((ConfPatient)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (ConfPatient)obj;
        }

        public async Task<ConfPatient> Delete(object obj)
        {
            _medicwallContext.ConfPatient.Remove((ConfPatient)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (ConfPatient)obj;
        }

      
    }
}
