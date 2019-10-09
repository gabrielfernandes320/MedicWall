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
    public class DocumentsController : ControllerBase
    {
        private readonly IMedicwallRepository<Document> _documentRepository;

        public DocumentsController(IMedicwallRepository<Document> documentRepository)
        {
            _documentRepository = documentRepository;
        }

        // GET: api/documents
        [HttpGet]
        public ActionResult<IEnumerable<Document>> GetAllDocuments()
        {
            IEnumerable<Document> document = _documentRepository.GetAll();
            return Ok(document);
        }

        // GET: api/documents/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetDocument(int id)
        {
            var document = await _documentRepository.Get(id);
            if (document == null)
            {
                return NotFound();
            }

            return Ok(document);
        }

        //api/documents/1
        [HttpPut("{id}")]
        public async Task<ActionResult<Document>> UpdateDocumentAsync(int id, Document document)
        {

            if (id != document.Id)
            {
                return BadRequest();
            }

            var updateReturn = await _documentRepository.Update(id, document);

            if (updateReturn != null)
            {
                return Ok(document);
            }

            return BadRequest();
        }

        //api/documents
        [HttpPost]
        public async Task<ActionResult<Document>> AddDocumentAsync(Document document)
        {
            var addReturn = await _documentRepository.Add(document);

            if (addReturn != null)
            {
                return CreatedAtAction("GetDocument", new { id = document.Id }, document);
            }

            return BadRequest();
        }

        // DELETE: api/documents/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Document>> DeleteDocumentAsync(int id)
        {
            var document = await _documentRepository.Get(id);
            if (document == null)
            {
                return NotFound();
            }

            var deleteReturn = _documentRepository.Delete(document);

            if (deleteReturn != null)
            {
                return CreatedAtAction("GetDocument", new { id = document.Id }, document);
            }

            return BadRequest();

        }
    }
}
