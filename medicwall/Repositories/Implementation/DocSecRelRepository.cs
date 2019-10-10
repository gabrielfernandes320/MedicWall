using Microsoft.EntityFrameworkCore;
using medicwall.Models;
using medicwall.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medicwall.Repositories.Implementation
{
    public class DocsecRelRepository : IMedicwallRepository<DocsecRel>
    {

            readonly medicwallContext _medicwallContext;

            public DocsecRelRepository(medicwallContext context)
            {
                _medicwallContext = context;
            }

        public IEnumerable<DocsecRel> GetAll()
        {
                return _medicwallContext.DocsecRel.ToList();
        }

        public async Task<DocsecRel> Get(int id)
        {
            var docSecRel = await _medicwallContext.DocsecRel.FindAsync(id);
            return docSecRel;
        }

        public object Update(int id, DocsecRel docSecRel)
        {
            _medicwallContext.Entry(docSecRel).State = EntityState.Modified;

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

            return docSecRel;

        }

        public async Task<DocsecRel> Update(int id, object obj)
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
            return _medicwallContext.DocsecRel.Any(e => e.Id == id);
        }

        public async Task<DocsecRel> Add(object obj)
        {
            _medicwallContext.DocsecRel.Add((DocsecRel)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (DocsecRel)obj;
        }

        public async Task<DocsecRel> Delete(object obj)
        {
            _medicwallContext.DocsecRel.Remove((DocsecRel)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (DocsecRel)obj;
        }

      
    }
}
