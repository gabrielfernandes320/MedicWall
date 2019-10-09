using Microsoft.EntityFrameworkCore;
using medicwall.Models;
using medicwall.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medicwall.Repositories.Implementation
{
    public class CityRepository : IMedicwallRepository<City>
    {

            readonly medicwallContext _medicwallContext;

            public CityRepository(medicwallContext context)
            {
                _medicwallContext = context;
            }

        public IEnumerable<City> GetAll()
        {
                return _medicwallContext.City.ToList();
        }

        public async Task<City> Get(int id)
        {
            var city = await _medicwallContext.City.FindAsync(id);
            return city;
        }

        public object Update(int id, City city)
        {
            _medicwallContext.Entry(city).State = EntityState.Modified;

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

            return city;

        }

        public async Task<City> Update(int id, object obj)
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
            return _medicwallContext.City.Any(e => e.Id == id);
        }

        public async Task<City> Add(object obj)
        {
            _medicwallContext.City.Add((City)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (City)obj;
        }

        public async Task<City> Delete(object obj)
        {
            _medicwallContext.City.Remove((City)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (City)obj;
        }

      
    }
}
