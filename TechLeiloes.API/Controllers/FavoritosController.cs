using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechLeiloes.API.Data;
using TechLeiloes.API.Models;

namespace TechLeiloes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FavoritosController(AppDbContext context) => _context = context;

        [HttpGet] public async Task<ActionResult<IEnumerable<Favorito>>> GetFavoritos() => await _context.Favoritos.Include(f => f.Imovel).Include(f => f.Usuario).ToListAsync();
    }
}