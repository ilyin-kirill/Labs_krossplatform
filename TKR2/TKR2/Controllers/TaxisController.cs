using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TKR2.Models;
using Microsoft.AspNetCore.Authorization;

namespace TKR2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxisController : ControllerBase
    {
        private readonly Context _context;

        public TaxisController(Context context)
        {
            _context = context;
        }

        // GET: api/Taxis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taxi>>> GetTaxis()
        {
            return await _context.Taxis.ToListAsync();
        }

        // GET: api/Taxis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taxi>> GetTaxi(int id)
        {
            var taxi = await _context.Taxis.FindAsync(id);

            if (taxi == null)
            {
                return NotFound();
            }

            return taxi;
        }

        // PUT: api/Taxis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxi(int id, Taxi taxi)
        {
            if (id != taxi.Id)
            {
                return BadRequest();
            }

            _context.Entry(taxi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Taxis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Taxi>> PostTaxi(Taxi taxi)
        {
            _context.Taxis.Add(taxi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaxi", new { id = taxi.Id }, taxi);
        }

        // DELETE: api/Taxis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Taxi>> DeleteTaxi(int id)
        {
            var taxi = await _context.Taxis.FindAsync(id);
            if (taxi == null)
            {
                return NotFound();
            }

            _context.Taxis.Remove(taxi);
            await _context.SaveChangesAsync();

            return taxi;
        }

        private bool TaxiExists(int id)
        {
            return _context.Taxis.Any(e => e.Id == id);
        }
    }
}
