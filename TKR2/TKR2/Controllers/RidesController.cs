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
    public class RidesController : ControllerBase
    {
        private readonly Context _context;
        private readonly IManager _mng;

        public RidesController(Context context, IManager mng)
        {
            _mng = mng;
            _context = context;
        }

        // GET: api/Rides
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ride>>> GetRides()
        {
            return await _context.Rides.ToListAsync();
        }

        [Authorize]
        [HttpGet("ridesuser/{id}")]
        public async Task<ActionResult<IEnumerable<Ride>>> GetRidesUser(int id)
        {
            return await _context.Rides.Where(r => r.UserId == id).ToListAsync();
        }

        // GET: api/Rides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ride>> GetRide(int id)
        {
            var ride = await _context.Rides.FindAsync(id);

            if (ride == null)
            {
                return NotFound();
            }

            return ride;
        }

        // PUT: api/Rides/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRide(int id, Ride ride)
        {
            if (id != ride.Id)
            {
                return BadRequest();
            }

            _context.Entry(ride).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RideExists(id))
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
        [Authorize(Roles = "admin , user")]
        [HttpPut]
        public async Task<ActionResult<Ride>> ChangeRide([FromForm] int id, [FromForm] int id_ride, [FromForm] string new_address)
        {
            var user = _context.Users.Include(i => i.Rides).FirstOrDefault(i => i.Id == id);
            if (user != null)
            {
                if (user.ChangeAddressTo(id_ride, new_address))
                {
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("ChangeRide", new
                    {
                        result = "Адрес был изменен."
                    });
                }
                else
                {
                    return CreatedAtAction("ChangeRide", new
                    {
                        result = "У пользователя нет такой поездки."
                    });
                }
            }
            else
            {
                return CreatedAtAction("ChangeRide", new
                {
                    result = "Пользователя с таким id не существует."
                });
            }
        }
        // POST: api/Rides
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "admin , user")]
        [HttpPost("{id}")]
        public async Task<ActionResult<Ride>> PostRide(Ride ride, int id)
        {
            ride.User = _context.Users.FirstOrDefault(i => i.Id == id);
            if (ride.User != null)
            {
                ride.Driver = _mng.SelectDriverForUser(_context.Users.FirstOrDefault(i => i.Id == id), _context.Drivers.ToList());
                _context.Rides.Add(ride);
                await _context.SaveChangesAsync();
                return CreatedAtAction("PostRide", new { id = ride.Id }, ride);
            } else
            {
                return CreatedAtAction("PostRide", new
                {
                    result = "Пользователя с таким id не существует."
                });
            }
        }
        [Authorize(Roles = "admin , driver")]
        [HttpPut("startride/{id}")]
        public async Task<ActionResult<Ride>> StartRide(int id)
        {
            var ride = _context.Rides.FirstOrDefault(i => i.Id == id);
            if (ride != null)
            {
                ride.TimeBegin = DateTime.Now;
                await _context.SaveChangesAsync();
                return CreatedAtAction("StartRide", new
                {
                    result = "Поездка началась."
                });
            }
            else
            {
                return CreatedAtAction("StartRide", new
                {
                    result = "Поездки с таким id не существует."
                });
            }
        }
        [Authorize(Roles = "admin , driver")]
        [HttpPut("endride/{id}")]
        public async Task<ActionResult<Ride>> EndRide(int id)
        {
            var ride = _context.Rides.FirstOrDefault(i => i.Id == id);
            if (ride != null)
            {
                ride.TimeEnd = DateTime.Now;
                ride.CalcPrice();
                await _context.SaveChangesAsync();
                return CreatedAtAction("EndRide", new
                {
                    result = "Поездка закончена."
                });
            }
            else
            {
                return CreatedAtAction("EndRide", new
                {
                    result = "Поездки с таким id не существует."
                });
            }
        }
        // DELETE: api/Rides/5
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ride>> DeleteRide(int id)
        {
            var ride = await _context.Rides.FindAsync(id);
            if (ride == null)
            {
                return NotFound();
            }

            _context.Rides.Remove(ride);
            await _context.SaveChangesAsync();

            return ride;
        }

        private bool RideExists(int id)
        {
            return _context.Rides.Any(e => e.Id == id);
        }
    }
}
