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
    public class DdocsecRelController : ControllerBase
    {
        private readonly IMedicwallRepository<DocsecRel> _ocsecRelRepository;

        public DdocsecRelController(IMedicwallRepository<DocsecRel> ocsecRelRepository)
        {
            _ocsecRelRepository = ocsecRelRepository;
        }

        // GET: api/docsecRel
        [HttpGet]
        public ActionResult<IEnumerable<DocsecRel>> GetAllDdocsecRel()
        {
            IEnumerable<DocsecRel> ocsecRel = _ocsecRelRepository.GetAll();
            return Ok(ocsecRel);
        }

        // GET: api/docsecRel/1
        [HttpGet("{id}")]
        public async Task<ActionResult<DocsecRel>> GetDocsecRel(int id)
        {
            var ocsecRel = await _ocsecRelRepository.Get(id);
            if (ocsecRel == null)
            {
                return NotFound();
            }

            return Ok(ocsecRel);
        }

        //api/docsecRel/1
        [HttpPut("{id}")]
        public async Task<ActionResult<DocsecRel>> UpdateDocsecRelAsync(int id, DocsecRel ocsecRel)
        {

            if (id != ocsecRel.Id)
            {
                return BadRequest();
            }

            var updateReturn = await _ocsecRelRepository.Update(id, ocsecRel);

            if (updateReturn != null)
            {
                return Ok(ocsecRel);
            }

            return BadRequest();
        }

        //api/docsecRel
        [HttpPost]
        public async Task<ActionResult<DocsecRel>> AddDocsecRelAsync(DocsecRel ocsecRel)
        {
            var addReturn = await _ocsecRelRepository.Add(ocsecRel);

            if (addReturn != null)
            {
                return CreatedAtAction("GetDocsecRel", new { id = ocsecRel.Id }, ocsecRel);
            }

            return BadRequest();
        }

        // DELETE: api/docsecRel/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<DocsecRel>> DeleteDocsecRelAsync(int id)
        {
            var ocsecRel = await _ocsecRelRepository.Get(id);
            if (ocsecRel == null)
            {
                return NotFound();
            }

            var deleteReturn = _ocsecRelRepository.Delete(ocsecRel);

            if (deleteReturn != null)
            {
                return CreatedAtAction("GetDocsecRel", new { id = ocsecRel.Id }, ocsecRel);
            }

            return BadRequest();

        }
    }
}
