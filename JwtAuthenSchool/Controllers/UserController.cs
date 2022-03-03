#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JwtAuthenSchool.Models.Authentication;
using JwtAuthenSchool.Services;
using Microsoft.AspNetCore.Authorization;

namespace JwtAuthenSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin,User,Sys")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly SQLContext _context;

        public UserController(SQLContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        [Route("GetUserInfo")]
        public async Task<ActionResult<IEnumerable<Users>>> GetUserInfo()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUserInfo(long id)
        {
            var userInfo = await _context.Users.FindAsync(id);

            if (userInfo == null)
            {
                return NotFound();
            }

            return userInfo;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInfo(long id, Users userInfo)
        {
            if (id != userInfo.ID)
            {
                return BadRequest();
            }

            _context.Entry(userInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Users>> PostUserInfo(Users userInfo)
        {
            _context.Users.Add(userInfo);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUserInfo", new { id = userInfo.Id }, userInfo);
            return CreatedAtAction(nameof(GetUserInfo), new { id = userInfo.ID }, userInfo);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInfo(long id)
        {
            var userInfo = await _context.Users.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserInfoExists(long id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
