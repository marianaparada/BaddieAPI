using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaddieAPI.Data;
using BaddieAPI.Models;

namespace BaddieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BarcosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Barcos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Barco>>> GetBarcos()
        {
            return await _context.Barcos.ToListAsync();
        }

        // GET: api/Barcos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Barco>> GetBarco(int id)
        {
            var barco = await _context.Barcos.FindAsync(id);

            if (barco == null)
            {
                return NotFound();
            }

            return barco;
        }

        // POST: api/Barcos
        [HttpPost]
        public async Task<ActionResult<Barco>> PostBarco(Barco barco)
        {
            _context.Barcos.Add(barco);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBarco), new { id = barco.Id }, barco);
        }

        // PUT: api/Barcos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBarco(int id, Barco barco)
        {
            if (id != barco.Id)
            {
                return BadRequest();
            }

            _context.Entry(barco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarcoExists(id))
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

        // DELETE: api/Barcos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarco(int id)
        {
            var barco = await _context.Barcos.FindAsync(id);
            if (barco == null)
            {
                return NotFound();
            }

            _context.Barcos.Remove(barco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BarcoExists(int id)
        {
            return _context.Barcos.Any(e => e.Id == id);
        }
    }
}
