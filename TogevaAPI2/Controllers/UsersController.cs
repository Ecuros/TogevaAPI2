using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TogevaAPI2.Models;

namespace TogevaAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TogevaDBContext _context;

        public UsersController(TogevaDBContext context)
        {
            _context = context;
        }

        // GET: api/Users1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost]
        [Route("np")]
        public async Task<ActionResult> UpdatePassword([FromBody] User model)
        {
            User user = (User)_context.Users.Where(u => u.Email == model.Email ).FirstOrDefault();
            if(user!=null)
            {
                if (user.password == model.password)
                {
                    user.password = model.newPassword;
                    await _context.SaveChangesAsync();
                    //await _context.SaveChangesAsync();
                    return Ok(model);
                }
            }            
            return BadRequest();
        }
        [HttpPost("register")]
        
        public async Task<ActionResult> RegisterUser([FromBody] User model)
        {
            User user = (User)_context.Users.Where(u => u.Email == model.Email).FirstOrDefault();
            User b = new User();
            model.Id = b.Id; //not proud of that
            if (user == null)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return Ok(model);
            }
            return BadRequest();
        }


        // GET: api/Users1/5
        [HttpPost("user")]
        public async Task<User> GetUser(User user)
        {
            return  _context.Users.Where(u => u.Id == user.Id).FirstOrDefault();
        }

        [HttpPost("email")]
        public User getAnnouncesByUser([FromBody] Announce announce)
        {
            return _context.Users.Where(u => u.Id == announce.UserId).FirstOrDefault();
        }

        // DELETE: api/Users1/5
        /*[HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }*/

        /*private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }*/
    }
}
