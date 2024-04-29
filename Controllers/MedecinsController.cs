using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GSB_BM.Models;
using Microsoft.AspNetCore.Authorization;

namespace GSB_BM.Controllerss
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedecinsController : ControllerBase
    {
        private readonly GSBContext _context;

        public MedecinsController(GSBContext context)
        {
            _context = context;
        }

        // GET: api/Medecins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medecin>>> GetMedecins()
        {
          if (_context.Medecins == null)
          {
              return NotFound();
          }
            return await _context.Medecins.ToListAsync();
        }

        // GET: api/Medecins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medecin>> GetMedecin(int id)
        {
          if (_context.Medecins == null)
          {
              return NotFound();
          }
            var medecin = await _context.Medecins.FindAsync(id);

            if (medecin == null)
            {
                return NotFound();
            }

            return medecin;
        }

        // PUT: api/Medecins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedecin(int id, Medecin medecin)
        {
            if (id != medecin.Idmedecin)
            {
                return BadRequest();
            }

            _context.Entry(medecin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedecinExists(id))
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

        // POST: api/Medecins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medecin>> PostMedecin(Medecin medecin)
        {
          if (_context.Medecins == null)
          {
              return Problem("Entity set 'GSBContext.Medecins'  is null.");
          }
            _context.Medecins.Add(medecin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedecin", new { id = medecin.Idmedecin }, medecin);
        }

        // DELETE: api/Medecins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedecin(int id)
        {
            if (_context.Medecins == null)
            {
                return NotFound();
            }
            var medecin = await _context.Medecins.FindAsync(id);
            if (medecin == null)
            {
                return NotFound();
            }

            _context.Medecins.Remove(medecin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedecinExists(int id)
        {
            return (_context.Medecins?.Any(e => e.Idmedecin == id)).GetValueOrDefault();
        }
    }
}
