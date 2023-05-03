using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.AirfareService.Data;
using AndreTurismoApp.Models;
using AndreTurismoApp.AirfareService.Services;

namespace AndreTurismoApp.AirfareService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirfaresController : ControllerBase
    {
        private readonly AndreTurismoAppAirfareServiceContext _context;

        public AirfaresController(AndreTurismoAppAirfareServiceContext context)
        {
            _context = context;
        }

        // GET: api/Airfares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Airfare>>> GetAirfare()
        {
          if (_context.Airfare == null)
          {
              return NotFound();
          }
            return await _context.Airfare.ToListAsync();
        }

        // GET: api/Airfares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Airfare>> GetAirfare(int id)
        {
          if (_context.Airfare == null)
          {
              return NotFound();
          }
            var airfare = await _context.Airfare.FindAsync(id);

            if (airfare == null)
            {
                return NotFound();
            }

            return airfare;
        }

        // PUT: api/Airfares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Airfare>> PutAirfare(int id, Airfare airfare)
        {
            if (id != airfare.Id)
            {
                return BadRequest();
            }

            _context.Entry(airfare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirfareExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return airfare;
        }

        // POST: api/Airfares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Airfare>> PostAirfare(Airfare airfare)
        {
          if (_context.Airfare == null)
          {
              return Problem("Entity set 'AndreTurismoAppAirfareServiceContext.Airfare'  is null.");
          }
            var dto = AirfareAddressService.GetAddress(airfare.Origin.PostalCode).Result;
            Address origin = new()
            {
                Street = dto.Street,
                Number = int.Parse(dto.Number),
                Neighborhood = dto.Neighborhood,
                PostalCode = dto.PostalCode,
                RegisterDate = DateTime.Now,
                City = new()
                {
                    CityName = dto.City
                }
            };
            var dto2 = AirfareAddressService.GetAddress(airfare.Origin.PostalCode).Result;

            Address destiny = new()
            {
                Street = dto2.Street,
                Number = int.Parse(dto2.Number),
                Neighborhood = dto2.Neighborhood,
                PostalCode = dto2.PostalCode,
                RegisterDate = DateTime.Now,
                City = new()
                {
                    CityName = dto2.City
                }
            };
            var c = AirfareCustomerService.GetClient(airfare.Client.Id).Result;
            Client customer = new Client()
            {
                Id = c.Id,
                Name = c.Name,
                Phone = c.Phone,
                Address = new Address()
                {
                    Id = c.Address.Id,
                    Street = c.Address.Street,
                    Number = c.Address.Number,
                    Neighborhood = c.Address.Neighborhood,
                    PostalCode = c.Address.PostalCode,
                    City = new City()
                    {
                        Id = c.Address.City.Id,
                        CityName = c.Address.City.CityName
                    }
                }
            };

            airfare.Origin = origin;
            airfare.Destiny = destiny;
            airfare.Client = customer;
            _context.Airfare.Add(airfare);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirfare", new { id = airfare.Id }, airfare);
        }

        // DELETE: api/Airfares/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Airfare>> DeleteAirfare(int id)
        {
            if (_context.Airfare == null)
            {
                return NotFound();
            }
            var airfare = await _context.Airfare.FindAsync(id);
            if (airfare == null)
            {
                return NotFound();
            }

            _context.Airfare.Remove(airfare);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirfareExists(int id)
        {
            return (_context.Airfare?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
