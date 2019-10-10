using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medicwall.Models;
using medicwall.Repositories.Contract;
using Microsoft.AspNetCore.Mvc;

namespace medicwall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IMedicwallRepository<City> _cityRepository;

        public CitiesController(IMedicwallRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        // GET: api/cities
        [HttpGet]
        public ActionResult<IEnumerable<City>> GetAllCities()
        {
            IEnumerable<City> city = _cityRepository.GetAll();
            return Ok(city);
        }

        // GET: api/cities/1
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = await _cityRepository.Get(id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        //api/cities/1
        [HttpPut("{id}")]
        public async Task<ActionResult<City>> UpdateCityAsync(int id, City city)
        {

            if (id != city.Id)
            {
                return BadRequest();
            }

            var updateReturn = await _cityRepository.Update(id, city);

            if (updateReturn != null)
            {
                return Ok(city);
            }

            return BadRequest();
        }

        //api/cities
        [HttpPost]
        public async Task<ActionResult<City>> AddCityAsync(City city)
        {
            var addReturn = await _cityRepository.Add(city);

            if (addReturn != null)
            {
                return CreatedAtAction("GetCity", new { id = city.Id }, city);
            }

            return BadRequest();
        }

        // DELETE: api/cities/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<City>> DeleteCityAsync(int id)
        {
            var city = await _cityRepository.Get(id);
            if (city == null)
            {
                return NotFound();
            }

            var deleteReturn = _cityRepository.Delete(city);

            if (deleteReturn != null)
            {
                return CreatedAtAction("GetCity", new { id = city.Id }, city);
            }

            return BadRequest();

        }
    }
}