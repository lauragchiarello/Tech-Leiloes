using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechLeiloes.API.Data;
using TechLeiloes.API.Models;

namespace TechLeiloes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeiloeirosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LeiloeirosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet] public async Task<ActionResult<IEnumerable<Leiloeiro>>> GetLeiloeiros() => await _context.Leiloeiros.ToListAsync();
        
        [HttpGet("{id}")] public async Task<ActionResult<Leiloeiro>> GetLeiloeiro(int id) => await _context.Leiloeiros.FindAsync(id) is Leiloeiro l ? l : NotFound();
        
        [HttpPost] public async Task<ActionResult<Leiloeiro>> PostLeiloeiro(Leiloeiro leiloeiro) { _context.Leiloeiros.Add(leiloeiro); await _context.SaveChangesAsync(); return CreatedAtAction(nameof(GetLeiloeiro), new { id = leiloeiro.Id }, leiloeiro); }
       
        [HttpPut("{id}")] public async Task<IActionResult> PutLeiloeiro(int id, Leiloeiro leiloeiro) { if (id != leiloeiro.Id) return BadRequest(); _context.Entry(leiloeiro).State = EntityState.Modified; await _context.SaveChangesAsync(); return NoContent(); }

        [HttpDelete("{id}")] public async Task<IActionResult> DeleteLeiloeiro(int id) { var leiloeiro = await _context.Leiloeiros.FindAsync(id); if (leiloeiro == null) return NotFound(); _context.Leiloeiros.Remove(leiloeiro); await _context.SaveChangesAsync(); return NoContent(); }
    }
}