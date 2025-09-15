using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaddieAPI.Data;
using BaddieAPI.Models;

namespace Prueba2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotosController : ControllerBase
    {
        private readonly AppDbContext _db;
        public MotosController(AppDbContext db) => _db = db;

        // GET: api/motos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moto>>> GetAll(
            [FromQuery] string? marca,
            [FromQuery] string? tipo,
            [FromQuery] int? anio,
            [FromQuery] bool? disponible)
        {
            var q = _db.Motos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(marca)) q = q.Where(m => m.Marca == marca);
            if (!string.IsNullOrWhiteSpace(tipo)) q = q.Where(m => m.Tipo == tipo);
            if (anio.HasValue) q = q.Where(m => m.Anio == anio.Value);
            if (disponible.HasValue) q = q.Where(m => m.Disponible == disponible.Value);

            return await q.OrderBy(m => m.Marca).ThenBy(m => m.Modelo).ToListAsync();
        }

        // GET: api/motos/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Moto>> GetOne(int id)
        {
            var moto = await _db.Motos.FindAsync(id);
            return moto is null ? NotFound() : Ok(moto);
        }

        // POST: api/motos
        [HttpPost]
        public async Task<ActionResult<Moto>> Create([FromBody] Moto input)
        {
            if (input.Id != 0) input.Id = 0;
            _db.Motos.Add(input);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOne), new { id = input.Id }, input);
        }

        // PUT: api/motos/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Moto input)
        {
            if (id != input.Id) return BadRequest("El ID no coincide");
            var exists = await _db.Motos.AnyAsync(m => m.Id == id);
            if (!exists) return NotFound();

            _db.Entry(input).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/motos/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var moto = await _db.Motos.FindAsync(id);
            if (moto is null) return NotFound();
            _db.Motos.Remove(moto);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
