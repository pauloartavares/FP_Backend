using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PF_Backend.Data;
using PF_Backend.Models;

namespace PF_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortionsController : ControllerBase
    {
        private readonly PF_BackendContext _context;

        public PortionsController(PF_BackendContext context)
        {
            _context = context;
        }

        // GET: api/Portions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Portion>>> GetPortions()
        {
            return await _context.Portions.ToListAsync();
        }

        // GET: api/Portions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Portion>> GetPortions(int id)
        {
            var portions = await _context.Portions.FindAsync(id);

            if (portions == null)
            {
                return NotFound();
            }

            return portions;
        }

        // PUT: api/Portions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPortions(int id, Portion portions)
        {
            if (id != portions.Id)
            {
                return BadRequest();
            }

            _context.Entry(portions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortionsExists(id))
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

        // POST: api/Portions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Portion>> PostPortions(Portion portions)
        {
            _context.Portions.Add(portions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPortions", new { id = portions.Id }, portions);
        }

        // DELETE: api/Portions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortions(int id)
        {
            var portions = await _context.Portions.FindAsync(id);
            if (portions == null)
            {
                return NotFound();
            }

            _context.Portions.Remove(portions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PortionsExists(int id)
        {
            return _context.Portions.Any(e => e.Id == id);
        }
    }
}
