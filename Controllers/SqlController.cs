using ManagedIdentity.Context;
using ManagedIdentity.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ManagedIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public SqlController(ApplicationContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wizzer>>> Get()
        {
            try
            {
                return await _context.Wizzers.ToListAsync();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{nome}/{hobby}")]
        public async Task<IActionResult> Post(string nome, string hobby)
        {
            var wizzer = new Wizzer
            {
                Nome = nome,
                Hobby = hobby
            };

            try
            {
                _context.Wizzers.Add(wizzer);
                await _context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
