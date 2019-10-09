using Microsoft.EntityFrameworkCore;
using medicwall.Models;
using medicwall.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medicwall.Repositories.Implementation
{
    public class DocumentRepository : IMedicwallRepository<Document>
    {

            readonly medicwallContext _medicwallContext;

            public DocumentRepository(medicwallContext context)
            {
                _medicwallContext = context;
            }

        public IEnumerable<Document> GetAll()
        {
                return _medicwallContext.Document.ToList();
        }

        public async Task<Document> Get(int id)
        {
            var product = await _medicwallContext.Document.FindAsync(id);
            return product;
        }

        public object Update(int id, Document product)
        {
            _medicwallContext.Entry(product).State = EntityState.Modified;

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

            return product;

        }

        public async Task<Document> Update(int id, object obj)
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
            return _medicwallContext.Document.Any(e => e.Id == id);
        }

        public async Task<Document> Add(object obj)
        {
            _medicwallContext.Document.Add((Document)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return (Document)obj;
        }

        public async Task<Document> Delete(object obj)
        {
            _medicwallContext.Document.Remove((Document)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (Document)obj;
        }

      
    }
}
