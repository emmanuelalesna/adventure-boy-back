using Microsoft.AspNetCore.Mvc;
using Project2.app.Models;
using Project2.app.Services.Interface;

namespace Project2.app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpellController : ControllerBase
    {
        private readonly IService<Spell> _spellService;

        public SpellController(IService<Spell> spellService)
        {
            _spellService = spellService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spell>>> GetAll()
        {
            try
            {
                var spells = await _spellService.GetAllEntities();
                return Ok(spells);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Spell>> GetSpell(int id)
        {
            try
            {
                var spell = await _spellService.GetEntityById(id);

                if (spell == null)
                {
                    return NotFound("Spell doesn't exist");
                }

                return Ok(spell);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
