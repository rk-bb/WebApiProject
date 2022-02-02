using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiE2C.Models;

namespace WebApiE2C.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotClesController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public MotClesController(DataBaseContext context)

        {
            _context = context;
        }

        // GET: api/MotCles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotCles>>> GetMotCle()
        {
            return await _context.MotCle.ToListAsync();
        }

        // GET: api/MotCles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MotCles>> GetMotCles(int id)
        {
            var motCles = await _context.MotCle.FindAsync(id);

            if (motCles == null)
            {
                return NotFound();
            }

            return motCles;
        }

        // PUT: api/MotCles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotCles(int id, MotCles motCles)
        {
            if (id != motCles.Id)
            {
                return BadRequest();
            }

            _context.Entry(motCles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotClesExists(id))
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

        // POST: api/AddMotsCles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MotCles>> AddMotCles(MotCles motCles)
        {
            _context.MotCle.Add(motCles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotCles", new { id = motCles.Id }, motCles);
        }

        // DELETE: api/MotCles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotCles(int id)
        {
            var motCles = await _context.MotCle.FindAsync(id);
            if (motCles == null)
            {
                return NotFound();
            }

            _context.MotCle.Remove(motCles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotClesExists(int id)
        {
            return _context.MotCle.Any(e => e.Id == id);
        }
    }
}
