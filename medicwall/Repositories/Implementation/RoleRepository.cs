using Microsoft.EntityFrameworkCore;
using medicwall.Models;
using medicwall.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medicwall.Repositories.Implementation
{
    public class RoleRepository : IMedicwallRepository<Role>
    {

            readonly medicwallContext _medicwallContext;

            public RoleRepository(medicwallContext context)
            {
                _medicwallContext = context;
            }

        public IEnumerable<Role> GetAll()
        {
                return _medicwallContext.Role.ToList();
        }

        public async Task<Role> Get(int id)
        {
            var role = await _medicwallContext.Role.FindAsync(id);
            return role;
        }

        public object Update(int id, Role role)
        {
            _medicwallContext.Entry(role).State = EntityState.Modified;

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

            return role;

        }

        public async Task<Role> Update(int id, object obj)
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
            return _medicwallContext.Role.Any(e => e.Id == id);
        }

        public async Task<Role> Add(object obj)
        {
            _medicwallContext.Role.Add((Role)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (Role)obj;
        }

        public async Task<Role> Delete(object obj)
        {
            _medicwallContext.Role.Remove((Role)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (Role)obj;
        }

      
    }
}
