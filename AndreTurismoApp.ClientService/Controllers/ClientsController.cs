﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.ClientService.Data;
using AndreTurismoApp.Models;
using AndreTurismoApp.ClientService.Services;

namespace AndreTurismoApp.ClientService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly AndreTurismoAppClientServiceContext _context;

        public ClientsController(AndreTurismoAppClientServiceContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClient()
        {
          if (_context.Client == null)
          {
              return NotFound();
          }
            return await _context.Client.ToListAsync();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
          if (_context.Client == null)
          {
              return NotFound();
          }
            var client = await _context.Client.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Client>> PutClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return client;
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
          if (_context.Client == null)
          {
              return Problem("Entity set 'AndreTurismoAppClientServiceContext.Client'  is null.");
          }
            var dto = ClientAddressService.GetAddress(client.Address.PostalCode).Result;
            Address address = new()
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
            client.Address = address;
            _context.Client.Add(client);
            await _context.SaveChangesAsync();

            return client;
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteClient(int id)
        {
            if (_context.Client == null)
            {
                return NotFound();
            }
            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            return (_context.Client?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
