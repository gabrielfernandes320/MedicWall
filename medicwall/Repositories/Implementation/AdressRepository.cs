using Microsoft.EntityFrameworkCore;
using medicwall.Models;
using medicwall.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medicwall.Repositories.Implementation
{
    public class AdressRepository : IMedicwallRepository<Adress>
    {

            readonly medicwallContext _medicwallContext;

            public AdressRepository(medicwallContext context)
            {
                _medicwallContext = context;
            }

        public IEnumerable<Adress> GetAll()
        {
                return _medicwallContext.Adress.ToList();
        }

        public async Task<Adress> Get(int id)
        {
            var adress = await _medicwallContext.Adress.FindAsync(id);
            return adress;
        }

        public object Update(int id, Adress adress)
        {
            _medicwallContext.Entry(adress).State = EntityState.Modified;

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

            return adress;

        }

        public async Task<Adress> Update(int id, object obj)
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
            return _medicwallContext.Adress.Any(e => e.Id == id);
        }

        public async Task<Adress> Add(object obj)
        {
            _medicwallContext.Adress.Add((Adress)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (Adress)obj;
        }

        public async Task<Adress> Delete(object obj)
        {
            _medicwallContext.Adress.Remove((Adress)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (Adress)obj;
        }

      
    }
}
