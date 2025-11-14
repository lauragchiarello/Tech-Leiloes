using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechLeiloes.API.Data;
using TechLeiloes.API.Models;

namespace TechLeiloes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImoveisController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ImoveisController(AppDbContext context) => _context = context;

        [HttpGet] public async Task<ActionResult<IEnumerable<Imovel>>> GetImoveis()
         => await _context.Imoveis.Include(i => i.Fotos).ToListAsync();

        [HttpGet("{id}")] public async Task<ActionResult<Imovel>> GetImovel(int id)
         => await _context.Imoveis.Include(i => i.Fotos).FirstOrDefaultAsync(i => i.Id == id) is Imovel im ? im : NotFound();

        [HttpPost] public async Task<ActionResult<Imovel>> PostImovel(Imovel imovel) 
        { _context.Imoveis.Add(imovel); 
            await _context.SaveChangesAsync(); 
            return CreatedAtAction(nameof(GetImovel), new { id = imovel.Id }, imovel); }
        
        [HttpPut("{id}")] public async Task<IActionResult> PutImovel(int id, Imovel imovel)
         { if (id != imovel.Id) return BadRequest(); 
            _context.Entry(imovel).State = EntityState.Modified; 
            await _context.SaveChangesAsync(); return NoContent(); }
        
        [HttpDelete("{id}")] public async Task<IActionResult> DeleteImovel(int id) 
        { var imovel = await _context.Imoveis.FindAsync(id); 
            if (imovel == null) return NotFound(); _context.Imoveis.Remove(imovel); 
            await _context.SaveChangesAsync(); return NoContent(); }
    }
}

