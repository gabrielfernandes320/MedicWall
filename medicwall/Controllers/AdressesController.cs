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
    public class AdressesController : ControllerBase
    {
            private readonly IMedicwallRepository<Adress> _adressRepository;

            public AdressesController(IMedicwallRepository<Adress> adressRepository)
            {
                _adressRepository = adressRepository;
            }

            // GET: api/adresses
            [HttpGet]
            public ActionResult<IEnumerable<Adress>> GetAllAdresss()
            {
                IEnumerable<Adress> adress = _adressRepository.GetAll();
                return Ok(adress);
            }

            // GET: api/adresses/1
            [HttpGet("{id}")]
            public async Task<ActionResult<Adress>> GetAdress(int id)
            {
                var adress = await _adressRepository.Get(id);
                if (adress == null)
                {
                    return NotFound();
                }

                return Ok(adress);
            }

            //api/adresses/1
            [HttpPut("{id}")]
            public async Task<ActionResult<Adress>> UpdateAdressAsync(int id, Adress adress)
            {

                if (id != adress.Id)
                {
                    return BadRequest();
                }

                var updateReturn = await _adressRepository.Update(id, adress);

                if (updateReturn != null)
                {
                    return Ok(adress);
                }

                return BadRequest();
            }

            //api/adresses
            [HttpPost]
            public async Task<ActionResult<Adress>> AddAdressAsync(Adress adress)
            {
                var addReturn = await _adressRepository.Add(adress);

                if (addReturn != null) 
                {
                    return CreatedAtAction("GetAdress", new { id = adress.Id }, adress);
                }

                return BadRequest();
            }

            // DELETE: api/adresses/1
            [HttpDelete("{id}")]
            public async Task<ActionResult<Adress>> DeleteAdressAsync(int id)
            {
                var adress = await _adressRepository.Get(id);
                if (adress == null)
                {
                    return NotFound();
                }

                var deleteReturn = _adressRepository.Delete(adress);

                if (deleteReturn != null)
                {
                    return CreatedAtAction("GetAdress", new { id = adress.Id }, adress);
                }

                return BadRequest();

            }
        }
    }

