using System.Linq;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistance;


namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesGroupByController : ControllerBase
    {
        private readonly DataContext _context;
        public GamesGroupByController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetId(int id)
        {
            var prod = _context.Producator.Where(prod => prod.Id == id);
            return Ok(prod);
        }
        public IActionResult GamesByProducator()
        {
            
            var gamezz = _context.Games.GroupBy(prod => prod.Id, prod => prod.Name);

            return Ok(gamezz);
        }
    }
}