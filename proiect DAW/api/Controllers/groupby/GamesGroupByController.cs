using System.Linq;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistance;


namespace api.Controllers.groupBy
{
    [Route("[controller]")]
    [ApiController]
    public class GamesGroupByController : ControllerBase
    {
        private readonly DataContext _context;
        public GamesGroupByController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("{id:int}")]
        public IActionResult GetId(int id)
        {
            var prod = _context.Producator.Where(prod => prod.Id == id);
            return Ok(prod);
        }
        [HttpGet]
        public IActionResult GamesByProducator()
        {
            
            var gamezz = _context.Games.GroupBy(gamezz => gamezz.Idprod, gamezz => gamezz.Name);

            return Ok(gamezz);
        }
    }
}