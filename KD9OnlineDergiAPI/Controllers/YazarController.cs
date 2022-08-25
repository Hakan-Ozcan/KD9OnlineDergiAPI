using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KD9OnlineDergiAPI.Database;
using KD9OnlineDergiAPI.Model;

namespace KD9OnlineDergiAPI.Controllers
{
    [Route("yayin-evleri/[controller]")]
    [ApiController]
    public class YazarController : ControllerBase
    {
        private readonly DergiDbContext _context;

        public YazarController(DergiDbContext context)
        {
            _context = context;
        }

        // GET: api/Yazar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Yazar>>> GetYazarlar()
        {
          if (_context.Yazarlar == null)
          {
              return NotFound();
          }
            return await _context.Yazarlar.ToListAsync();
        }

        // GET: api/Yazar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Yazar>> GetYazar(int id)
        {
          if (_context.Yazarlar == null)
          {
              return NotFound();
          }
            var yazar = await _context.Yazarlar.FindAsync(id);

            if (yazar == null)
            {
                return NotFound();
            }

            return yazar;
        }

        // PUT: api/Yazar/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYazar(int id, Yazar yazar)
        {
            if (id != yazar.Id)
            {
                return BadRequest();
            }

            _context.Entry(yazar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YazarExists(id))
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

        // POST: api/Yazar
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Yazar>> PostYazar(Yazar yazar)
        {
          if (_context.Yazarlar == null)
          {
              return Problem("Entity set 'DergiDbContext.Yazarlar'  is null.");
          }
            _context.Yazarlar.Add(yazar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYazar", new { id = yazar.Id }, yazar);
        }

        // DELETE: api/Yazar/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYazar(int id)
        {
            if (_context.Yazarlar == null)
            {
                return NotFound();
            }
            var yazar = await _context.Yazarlar.FindAsync(id);
            if (yazar == null)
            {
                return NotFound();
            }

            _context.Yazarlar.Remove(yazar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YazarExists(int id)
        {
            return (_context.Yazarlar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
