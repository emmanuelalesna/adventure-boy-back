using Microsoft.AspNetCore.Mvc;

namespace Project2.app.Controllers;

[ApiController]
[Route("/")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello world!");
    }
    [HttpGet("api/[controller]/helloworld")]
    public IActionResult GetHelloWorld()
    {
        return Ok("Hello world 2!");
    }
}