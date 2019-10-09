using Microsoft.EntityFrameworkCore;
using medicwall.Models;
using medicwall.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medicwall.Repositories.Implementation
{
    public class ContactRepository : IMedicwallRepository<Contact>
    {

            readonly medicwallContext _medicwallContext;

            public ContactRepository(medicwallContext context)
            {
                _medicwallContext = context;
            }

        public IEnumerable<Contact> GetAll()
        {
                return _medicwallContext.Contact.ToList();
        }

        public async Task<Contact> Get(int id)
        {
            var contact = await _medicwallContext.Contact.FindAsync(id);
            return contact;
        }

        public object Update(int id, Contact contact)
        {
            _medicwallContext.Entry(contact).State = EntityState.Modified;

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

            return contact;

        }

        public async Task<Contact> Update(int id, object obj)
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
            return _medicwallContext.Contact.Any(e => e.Id == id);
        }

        public async Task<Contact> Add(object obj)
        {
            _medicwallContext.Contact.Add((Contact)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (Contact)obj;
        }

        public async Task<Contact> Delete(object obj)
        {
            _medicwallContext.Contact.Remove((Contact)obj);

            try
            {
                await _medicwallContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return (Contact)obj;
        }

      
    }
}
