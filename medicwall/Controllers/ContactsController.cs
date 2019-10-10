using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using medicwall.Models;
using medicwall.Repositories.Contract;

namespace medicwall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMedicwallRepository<Contact> _contactRepository;

        public ContactsController(IMedicwallRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // GET: api/contacts
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetAllContacts()
        {
            IEnumerable<Contact> contact = _contactRepository.GetAll();
            return Ok(contact);
        }

        // GET: api/contacts/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _contactRepository.Get(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        //api/contacts/1
        [HttpPut("{id}")]
        public async Task<ActionResult<Contact>> UpdateContactAsync(int id, Contact contact)
        {

            if (id != contact.Id)
            {
                return BadRequest();
            }

            var updateReturn = await _contactRepository.Update(id, contact);

            if (updateReturn != null)
            {
                return Ok(contact);
            }

            return BadRequest();
        }

        //api/contacts
        [HttpPost]
        public async Task<ActionResult<Contact>> AddContactAsync(Contact contact)
        {
            var addReturn = await _contactRepository.Add(contact);

            if (addReturn != null)
            {
                return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
            }

            return BadRequest();
        }

        // DELETE: api/contacts/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contact>> DeleteContactAsync(int id)
        {
            var contact = await _contactRepository.Get(id);
            if (contact == null)
            {
                return NotFound();
            }

            var deleteReturn = _contactRepository.Delete(contact);

            if (deleteReturn != null)
            {
                return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
            }

            return BadRequest();

        }
    }
}
