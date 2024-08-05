using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private static int playerGold = 100;
        private static List<string> gameLog = new List<string>();

        // Scenario 1
        [HttpGet("Scenario1")]
        public IActionResult Scenario1()
        {
            gameLog.Add("You come across your neighbor's old house but it seems like nobody is home. The door is wide open and you don't hear anything from inside the house. Upon entering the home you find that the place has been ransacked and most of the furniture is destroyed.");
            gameLog.Add("Out from the bedroom, your zombified neighbor pops out looking for flesh to consume!");
            gameLog.Add("As you collect yourself you find that your fallen neighbor had a few gold pieces on his person. You bury him, give him a make-shift headstone and continue making your way towards the kingdom.");
            playerGold += 5; // Example of adding gold
            return Ok(new { Message = "Scenario 1 completed", PlayerGold = playerGold, GameLog = gameLog });
        }

        // Scenario 2
        [HttpGet("Scenario2")]
        public IActionResult Scenario2([FromQuery] string choice)
        {
            if (choice == "a")
            {
                return RedirectToAction("Combat");
            }
            else if (choice == "b")
            {
                gameLog.Add("You decide to run and hide, avoiding the wolves.");
                return RedirectToAction("Scenario3");
            }
            else
            {
                return BadRequest("Invalid choice.");
            }
        }

        // Scenario 3
        [HttpGet("Scenario3")]
        public IActionResult Scenario3([FromQuery] string choice)
        {
            if (choice == "a")
            {
                playerGold = 0;
                gameLog.Add("You give all your gold to the bandits.");
                return RedirectToAction("Scenario4");
            }
            else if (choice == "b")
            {
                return RedirectToAction("Combat");
            }
            else
            {
                return BadRequest("Invalid choice.");
            }
        }

        // Scenario 4
        [HttpGet("Scenario4")]
        public IActionResult Scenario4()
        {
            gameLog.Add("When you finish your business with the bandits you hear a gust of wind blow by and all of a sudden there's a wagon behind you pulled by a stout pony.");
            gameLog.Add("In the wagon is a cloaked figure who asks 'Whadda ya buyin'?'");
            return Ok(new { Message = "Scenario 4", GameLog = gameLog });
        }

        // Scenario 5
        [HttpGet("Scenario5")]
        public IActionResult Scenario5()
        {
            gameLog.Add("After shopping to your heart's content, you appear on the other side of the forest. But bizarrely enough, it's snowing, in the middle of Summer.");
            gameLog.Add("Something is clearly wrong, as apparent from a group of sentient snowmen approaching.");
            return RedirectToAction("Scenario6");
        }

        // Scenario 6
        [HttpGet("Scenario6")]
        public IActionResult Scenario6([FromQuery] string choice)
        {
            if (choice == "a")
            {
                return RedirectToAction("Combat");
            }
            else if (choice == "b")
            {
                gameLog.Add("You decide it’s not worth it and continue on your way.");
                return RedirectToAction("Scenario7");
            }
            else
            {
                return BadRequest("Invalid choice.");
            }
        }

        // Scenario 7
        [HttpGet("Scenario7")]
        public IActionResult Scenario7([FromQuery] string choice)
        {
            if (choice == "a")
            {
                return RedirectToAction("Combat");
            }
            else if (choice == "b")
            {
                playerGold -= 10; // Example cost for bribing
                gameLog.Add("You bribe the ogre to let you pass.");
                return RedirectToAction("Scenario8");
            }
            else
            {
                return BadRequest("Invalid choice.");
            }
        }

        // Scenario 8
        [HttpGet("Scenario8")]
        public IActionResult Scenario8([FromQuery] string choice)
        {
            if (choice == "a")
            {
                return RedirectToAction("Combat");
            }
            else if (choice == "b")
            {
                gameLog.Add("You decide to keep moving and avoid the situation.");
                return RedirectToAction("Scenario9");
            }
            else
            {
                return BadRequest("Invalid choice.");
            }
        }

        // Scenario 9
        [HttpGet("Scenario9")]
        public IActionResult Scenario9([FromQuery] string choice)
        {
            if (choice == "a")
            {
                playerGold -= 50; // Example cost for becoming a thrall
                gameLog.Add("You bow to the evil figure and become his thrall.");
                return RedirectToAction("EndGame");
            }
            else if (choice == "b")
            {
                return RedirectToAction("Combat");
            }
            else
            {
                return BadRequest("Invalid choice.");
            }
        }

        // Combat Scenario
        [HttpGet("Combat")]
        public IActionResult Combat()
        {
            gameLog.Add("A combat scenario is taking place!");
            return Ok(new { Message = "Combat scenario", GameLog = gameLog });
        }

        // End Game
        [HttpGet("EndGame")]
        public IActionResult EndGame()
        {
            gameLog.Add("The adventure comes to an end.");
            return Ok(new { Message = "End Game", GameLog = gameLog });
        }
    }
}
