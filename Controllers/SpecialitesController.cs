using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GSB_BM.Models;

namespace GSB_BM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialitesController : ControllerBase
    {
        private readonly GSBContext _context;

        public SpecialitesController(GSBContext context)
        {
            _context = context;
        }

        // GET: api/Specialites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specialite>>> GetSpecialites()
        {
          if (_context.Specialites == null)
          {
              return NotFound();
          }
            return await _context.Specialites.ToListAsync();
        }

        // GET: api/Specialites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Specialite>> GetSpecialite(int id)
        {
          if (_context.Specialites == null)
          {
              return NotFound();
          }
            var specialite = await _context.Specialites.FindAsync(id);

            if (specialite == null)
            {
                return NotFound();
            }

            return specialite;
        }

        // PUT: api/Specialites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialite(int id, Specialite specialite)
        {
            if (id != specialite.Idspecialite)
            {
                return BadRequest();
            }

            _context.Entry(specialite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialiteExists(id))
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

        // POST: api/Specialites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Specialite>> PostSpecialite(Specialite specialite)
        {
          if (_context.Specialites == null)
          {
              return Problem("Entity set 'GSBContext.Specialites'  is null.");
          }
            _context.Specialites.Add(specialite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecialite", new { id = specialite.Idspecialite }, specialite);
        }

        // DELETE: api/Specialites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialite(int id)
        {
            if (_context.Specialites == null)
            {
                return NotFound();
            }
            var specialite = await _context.Specialites.FindAsync(id);
            if (specialite == null)
            {
                return NotFound();
            }

            _context.Specialites.Remove(specialite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpecialiteExists(int id)
        {
            return (_context.Specialites?.Any(e => e.Idspecialite == id)).GetValueOrDefault();
        }
    }
}
