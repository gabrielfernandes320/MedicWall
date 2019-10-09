using Microsoft.EntityFrameworkCore;
using medicwall.Models;
using medicwall.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medicwall.Repositories.Implementation
{
    public class DocSecRelRepository : IMedicwallRepository<DocSecRel>
    {

            readonly medicwallContext _medicwallContext;

            public DocSecRelRepository(medicwallContext context)
            {
                _medicwallContext = context;
            }

        public IEnumerable<DocSecRel> GetAll()
        {
                return _medicwallContext.DocSecRel.ToList();
        }

        public async Task<DocSecRel> Get(int id)
        {
            var docSecRel = await _medicwallContext.DocSecRel.FindAsync(id);
            return docSecRel;
        }

        public object Update(int id, DocSecRel docSecRel)
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

        public async Task<DocSecRel> Update(int id, object obj)
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
            return _medicwallContext.DocSecRel.Any(e => e.Id == id);
        }

        public async Task<DocSecRel> Add(object obj)
        {
            _medicwallContext.DocSecRel.Add((DocSecRel)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (DocSecRel)obj;
        }

        public async Task<DocSecRel> Delete(object obj)
        {
            _medicwallContext.DocSecRel.Remove((DocSecRel)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (DocSecRel)obj;
        }

      
    }
}
