using Microsoft.AspNetCore.Mvc;
using Project2.app.Models;
using Project2.app.Services;

namespace Project2.app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpellController : ControllerBase
    {
        private readonly SpellService _spellService;

        public SpellController(SpellService spellService)
        {
            _spellService = spellService;
        }

        [HttpGet(Name = "GetAllSpells")]
        public async Task<ActionResult<IEnumerable<Spell>>> GetAll()
        {
            var spells = await _spellService.GetAllEntities();
            return Ok(spells);
        }

        [HttpGet("{spellId}", Name = "GetSpellById")]
        public async Task<ActionResult<Spell>> GetSpell(int spellId)
        {
            var spell = await _spellService.GetEntityById(spellId);

            if (spell == null)
            {
                return NotFound("Spell doesn't exist");
            }

            return Ok(spell);
        }
    }
}
