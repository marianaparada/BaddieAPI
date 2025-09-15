using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaddieAPI.Data;
using BaddieAPI.Models;

namespace BaddieAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AvionController : ControllerBase
{
    private readonly AppDbContext _context;

    public AvionController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/avion
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Avion>>> GetAviones()
    {
        return await _context.Aviones.AsNoTracking().ToListAsync();
    }

    // GET: api/avion/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Avion>> GetAvion(int id)
    {
        var avion = await _context.Aviones.FindAsync(id);
        if (avion == null) return NotFound();
        return avion;
    }

    // POST: api/avion
    [HttpPost]
    public async Task<ActionResult<Avion>> PostAvion(Avion avion)
    {
        _context.Aviones.Add(avion);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAvion), new { id = avion.Id }, avion);
    }

    // PUT: api/avion/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutAvion(int id, Avion avion)
    {
        if (id != avion.Id) return BadRequest("El Id de la ruta y del cuerpo no coinciden.");

        _context.Entry(avion).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            var exists = await _context.Aviones.AnyAsync(a => a.Id == id);
            if (!exists) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/avion/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAvion(int id)
    {
        var avion = await _context.Aviones.FindAsync(id);
        if (avion == null) return NotFound();

        _context.Aviones.Remove(avion);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
