using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaddieAPI.Data;
using BaddieAPI.Models;

namespace BaddieAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MicrosController : ControllerBase
{
    private readonly AppDbContext _context;

    public MicrosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/micros
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Micro>>> GetMicros()
        => await _context.Micro.AsNoTracking().ToListAsync();

    // GET: api/micros/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Micro>> GetMicro(int id)
    {
        var micro = await _context.Micro.FindAsync(id);
        if (micro is null) return NotFound();
        return micro;
    }

    // POST: api/micros
    [HttpPost]
    public async Task<ActionResult<Micro>> PostMicro(Micro micro)
    {
        _context.Micro.Add(micro);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMicro), new { id = micro.Id }, micro);
    }

    // PUT: api/micros/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutMicro(int id, Micro micro)
    {
        if (id != micro.Id) return BadRequest();

        _context.Entry(micro).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            var exists = await _context.Micro.AnyAsync(m => m.Id == id);
            if (!exists) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/micros/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMicro(int id)
    {
        var micro = await _context.Micro.FindAsync(id);
        if (micro is null) return NotFound();

        _context.Micro.Remove(micro);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}