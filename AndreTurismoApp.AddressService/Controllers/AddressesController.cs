﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.AddressService.Data;
using AndreTurismoApp.Models;

using AndreTurismoApp.AddressService.Services;

namespace AndreTurismoApp.AddressService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AndreTurismoAppAddressServiceContext _context;

        public AddressesController(AndreTurismoAppAddressServiceContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
          if (_context.Address == null)
          {
              return NotFound();
          }
            return await _context.Address.ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
          if (_context.Address == null)
          {
              return NotFound();
          }
            var address = await _context.Address.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Address>> PutAddress(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return address;
        }

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("cep")]
        public async Task<ActionResult<Address>> PostAddress(string cep)
        {
          if (_context.Address == null)
          {
              return Problem("Entity set 'AndreTurismoAppAddressServiceContext.Address'  is null.");
          }
            var aux = PostOfficeService.GetAddress(cep).Result;
            Address address = new()
            {
                Street = aux.Street,
                Number = int.Parse(aux.Number),
                Neighborhood = aux.Neighborhood,
                PostalCode = aux.PostalCode,
                RegisterDate = DateTime.Now,
                City = new City()
                {
                    CityName = aux.City
                }
            };

            _context.Address.Add(address);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetAddress", new { id = address.Id }, address);
            return address;
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
            if (_context.Address == null)
            {
                return NotFound();
            }
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressExists(int id)
        {
            return (_context.Address?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet("{cep:length(8)}")]
        public async Task<ActionResult<AddressDTO>> GetPostOffices(string cep)
        {
            //Exemplo de chamada de serviço - TESTE
            return await PostOfficeService.GetAddress(cep);
        }
    }
}
