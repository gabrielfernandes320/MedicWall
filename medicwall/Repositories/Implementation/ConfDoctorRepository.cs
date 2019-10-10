using Microsoft.EntityFrameworkCore;
using medicwall.Models;
using medicwall.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medicwall.Repositories.Implementation
{
    public class ConfDoctorRepository : IMedicwallRepository<ConfDoctor>
    {

            readonly medicwallContext _medicwallContext;

            public ConfDoctorRepository(medicwallContext context)
            {
                _medicwallContext = context;
            }

        public IEnumerable<ConfDoctor> GetAll()
        {
                return _medicwallContext.ConfDoctor.ToList();
        }

        public async Task<ConfDoctor> Get(int id)
        {
            var confDoctor = await _medicwallContext.ConfDoctor.FindAsync(id);
            return confDoctor;
        }

        public object Update(int id, ConfDoctor confDoctor)
        {
            _medicwallContext.Entry(confDoctor).State = EntityState.Modified;

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

            return confDoctor;

        }

        public async Task<ConfDoctor> Update(int id, object obj)
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
            return _medicwallContext.ConfDoctor.Any(e => e.Id == id);
        }

        public async Task<ConfDoctor> Add(object obj)
        {
            _medicwallContext.ConfDoctor.Add((ConfDoctor)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (ConfDoctor)obj;
        }

        public async Task<ConfDoctor> Delete(object obj)
        {
            _medicwallContext.ConfDoctor.Remove((ConfDoctor)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (ConfDoctor)obj;
        }

    }
}
