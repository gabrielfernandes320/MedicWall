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

            // GET: api/adresses/GetAllAdresss
            [HttpGet]
            [Route("GetAllAdresss")]
            public ActionResult<IEnumerable<Adress>> GetAllAdresss()
            {
                IEnumerable<Adress> adress = _adressRepository.GetAll();
                return Ok(adress);
            }

            // GET: api/adresses/GetAdress/1
            [HttpGet("GetAdress/{id}")]
            //[Route("GetAdress")]
            public async Task<ActionResult<Adress>> GetAdress(int id)
            {
                var product = await _adressRepository.Get(id);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }

        //api/adresses/UpdateAdress/1
        [HttpPut("UpdateAdress/{id}")]
            public async Task<ActionResult<Adress>> UpdateAdressAsync(int id, Adress product)
            {

                if (id != product.Id)
                {
                    return BadRequest();
                }

                var updateReturn = await _adressRepository.Update(id, product);

                if (updateReturn != null)
                {
                    return Ok(product);
                }

                return BadRequest();
            }

        //api/adresses/AddAdress
        [HttpPost]
            [Route("AddAdress")]
            public async Task<ActionResult<Adress>> AddAdressAsync(Adress product)
            {
                var addReturn = await _adressRepository.Add(product);

                if (addReturn != null)
                {
                    return CreatedAtAction("GetAdress", new { id = product.Id }, product);
                }

                return BadRequest();
            }

        // GET: api/adresses/DeleteAdress/1
        [HttpDelete("DeleteAdress/{id}")]
            public async Task<ActionResult<Adress>> DeleteAdressAsync(int id)
            {
                var product = await _adressRepository.Get(id);
                if (product == null)
                {
                    return NotFound();
                }

                var deleteReturn = _adressRepository.Delete(product);

                if (deleteReturn != null)
                {
                    return CreatedAtAction("GetAdress", new { id = product.Id }, product);
                }

                return BadRequest();


            }
        }
    }

