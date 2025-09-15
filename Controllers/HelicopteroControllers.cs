using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba2.Data;
using Prueba2.Models;

namespace Prueba2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelicopteroController : ControllerBase
{
    private readonly AppDbContext _db;

    public HelicopteroController(AppDbContext db) => _db = db;

    // GET: api/helicoptero
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Helicoptero>>> GetAll()
        => Ok(await _db.Helicoptero.AsNoTracking().ToListAsync());

    // GET: api/helicoptero/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Helicoptero>> GetById(int id)
    {
        var h = await _db.Helicoptero.FindAsync(id);
        return h is null ? NotFound() : Ok(h);
    }

    // POST: api/helicoptero
    [HttpPost]
    public async Task<ActionResult<Helicoptero>> Create(Helicoptero dto)
    {
        _db.Helicoptero.Add(dto);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    // PUT: api/helicoptero/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Helicoptero dto)
    {
        var h = await _db.Helicoptero.FindAsync(id);
        if (h is null) return NotFound();

        h.Modelo = dto.Modelo;
        h.Fabricante = dto.Fabricante;
        h.CapacidadPasajeros = dto.CapacidadPasajeros;
        h.Anio = dto.Anio;
        h.PesoMaxKg = dto.PesoMaxKg;
        h.Activo = dto.Activo;

        await _db.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/helicoptero/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var h = await _db.Helicoptero.FindAsync(id);
        if (h is null) return NotFound();

        _db.Helicoptero.Remove(h);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}