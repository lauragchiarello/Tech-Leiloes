using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechLeiloes.API.Data;
using TechLeiloes.API.Models;

namespace TechLeiloes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FotosController(AppDbContext context) => _context = context;

        [HttpGet] public async Task<ActionResult<IEnumerable<Foto>>> GetFotos() => await _context.Fotos.ToListAsync();
        [HttpGet("{id}")] public async Task<ActionResult<Foto>> GetFoto(int id) => await _context.Fotos.FindAsync(id) is Foto f ? f : NotFound();
        [HttpPost] public async Task<ActionResult<Foto>> PostFoto(Foto foto) { _context.Fotos.Add(foto); await _context.SaveChangesAsync(); return CreatedAtAction(nameof(GetFoto), new { id = foto.Id }, foto); }
        [HttpPut("{id}")] public async Task<IActionResult> PutFoto(int id, Foto foto) { if (id != foto.Id) return BadRequest(); _context.Entry(foto).State = EntityState.Modified; await _context.SaveChangesAsync(); return NoContent(); }
        [HttpDelete("{id}")] public async Task<IActionResult> DeleteFoto(int id) { var foto = await _context.Fotos.FindAsync(id); if (foto == null) return NotFound(); _context.Fotos.Remove(foto); await _context.SaveChangesAsync(); return NoContent(); }
    }
}