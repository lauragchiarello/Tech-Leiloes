using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechLeiloes.API.Data;
using TechLeiloes.API.Models;

namespace TechLeiloes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly AppDbContext _context;
        public StatusController(AppDbContext context) => _context = context;

        [HttpGet] public async Task<ActionResult<IEnumerable<Status>>> GetStatus() => await _context.Statuses.ToListAsync();
    }
}