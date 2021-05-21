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
    public class UsersController : ControllerBase
    {
        private readonly Context _context;

        public UsersController(Context context)
        {
            _context = context;
        }

        // GET: api/Users
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = _context.Users.Include(r => r.Rides);
            return await users.ToListAsync();
        }

        // GET: api/Users/5
        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = _context.Users.Include(r => r.Rides).FirstOrDefault(i => i.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [Authorize(Roles = "admin")]
        [HttpGet("topusers")]
        public CreatedAtActionResult TopUsers()
        {
            float amount = new float();
            List<Ride> rides = _context.Rides.ToList();
            List<User> users = _context.Users.ToList();
            Dictionary<string, float> amountperuser = new Dictionary<string, float>();
            foreach (var b in from User b in users select b)
            {
                amount = 0;
                foreach (var a in from Ride a in rides where a.UserId == b.Id select a)
                    amount += a.Price; 
                amountperuser.Add(b.Name, amount);
            }
            return CreatedAtAction("TopUsers", new { result = amountperuser.OrderByDescending(sum => sum.Value) });
        }
        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        [HttpPost("addride/{id}/{ids}")]
        public async Task<ActionResult<User>> AddRide(int id, int ids)
        {
            var user = _context.Users.FirstOrDefault(i => i.Id == id);
            if (user == null) return CreatedAtAction("AddRide", new
            {
                result = "Пользователя с таким id не существует."
            });
            Ride ride = new Ride();
            var ridecheck = _context.Rides.FirstOrDefault(i => i.Id == ids);
            if (ridecheck != null)
            {
                user.Rides.Add(ridecheck);
            }
            else return CreatedAtAction("AddRide", new
            {
                result = "Поездки с таким id не существует."
            });
            await _context.SaveChangesAsync();
            return CreatedAtAction("AddRide", new
            {
                result = "Поездка добавлена пользователю.",
                user.Name
            });
        }
        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostUser", new
            { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = _context.Users.Include(r => r.Rides).FirstOrDefault(i => i.Id == id);
            if (user == null)
            {
                return CreatedAtAction("DeleteUser", new
                {
                    result = "Пользователя с таким id не существует."
                });
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("DeleteUser", new
            {
                result = "Пользователь удален."
            });
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
