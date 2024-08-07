using Microsoft.AspNetCore.Mvc;
using Project2.app.Models;
using Project2.app.Services;
using Project2.app.Services.Interface;

namespace Project2.app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpellController(IService<Spell> spellService) : ControllerBase
    {
        private readonly IService<Spell> _spellService = spellService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spell>>> GetAll()
        {
            var spells = await _spellService.GetAllEntities();
            return Ok(spells);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Spell>> GetSpell(int id)
        {
            var spell = await _spellService.GetEntityById(id);

            if (spell == null)
            {
                return NotFound("Spell doesn't exist");
            }

            return Ok(spell);
        }
    }
}
