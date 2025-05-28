using Microsoft.AspNetCore.Mvc;
using Project2.app.Models;
using Project2.app.Services.Interface;

namespace Project2.app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnemyController(IService<Enemy> enemyService) : ControllerBase
{
    private readonly IService<Enemy> _enemyService = enemyService;

    [HttpGet]
    public async Task<IActionResult> GetAllEnemies()
    {
        return Ok(await _enemyService.GetAllEntities());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEnemyById(int id)
    {
        try
        {
            var enemy = await _enemyService.GetEntityById(id);
            if (enemy is null)
            {
                return NotFound("Enemy does not exist!");
            }
            return Ok(enemy);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}