using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Project2.app.Controllers
{
    public class GameController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly ICombatService _combatService;
        private readonly IScenarioService _scenarioService;
        private readonly IShopService _shopService;

        public GameController(
            IPlayerService playerService,
            ICombatService combatService,
            IScenarioService scenarioService,
            IShopService shopService)
        {
            _playerService = playerService;
            _combatService = combatService;
            _scenarioService = scenarioService;
            _shopService = shopService;
        }

        // Scenario 1
        public IActionResult Scenario1()
        {
            _playerService.AddGold(5); // Update player gold
            ViewData["Description"] = "You come across your neighbor's old house but it seems like nobody is home. The door is wide open and you don't hear anything from inside the house. Upon entering the home you find that the place has been ransacked and most of the furniture is destroyed. Out from the bedroom, your zombified neighbor pops out looking for flesh to consume! As you collect yourself you find that your fallen neighbor had a few gold pieces on his person. You bury him, give him a make-shift headstone and continue making your way towards the kingdom.";
            ViewData["Gold"] = _playerService.GetGold();
            return View();
        }

        // Scenario 2
        public IActionResult Scenario2(string choice)
        {
            if (choice == "a")
            {
                return RedirectToAction("Combat", new { enemyType = "GenericEnemy" });
            }
            else if (choice == "b")
            {
                ViewData["Message"] = "You decide to run and hide, avoiding the wolves.";
                return View("Scenario3");
            }
            else
            {
                return BadRequest("Invalid choice.");
            }
        }

        // Scenario 3
        public IActionResult Scenario3(string choice)
        {
            if (choice == "a")
            {
                _playerService.SetGold(0); // Player gives all gold to bandits
                ViewData["Message"] = "You give all your gold to the bandits.";
                return View("Scenario4");
            }
            else if (choice == "b")
            {
                return RedirectToAction("Combat", new { enemyType = "GenericEnemy" });
            }
            else
            {
                return BadRequest("Invalid choice.");
            }
        }

        // Scenario 4
        public IActionResult Scenario4()
        {
            var shopItems = _shopService.GetShopItems();
            ViewData["Description"] = "When you finish your business with the bandits you hear a gust of wind blow by and all of a sudden there's a wagon behind you pulled by a stout pony. In the wagon is a cloaked figure who asks 'Whadda ya buyin'?.";
            ViewData["ShopItems"] = shopItems;
            return View();
        }

        // Scenario 5
        public IActionResult Scenario5()
        {
            ViewData["Description"] = "After shopping to your heart's content, you appear on the other side of the forest. But bizarrely enough, it's snowing, in the middle of Summer. Something is clearly wrong, as apparent from a group of sentient snowmen approaching.";
            return View("Scenario6");
        }

        // Scenario 6
        public IActionResult Scenario6(string choice)
        {
            if (choice == "a")
            {
                return RedirectToAction("Combat", new { enemyType = "IceWizard" });
            }
            else if (choice == "b")
            {
                ViewData["Message"] = "You decide it’s not worth it and continue on your way.";
                return View("Scenario7");
            }
            else
            {
                return BadRequest("Invalid choice.");
            }
        }

        // Scenario 7
        public IActionResult Scenario7(string choice)
        {
            if (choice == "a")
            {
                return RedirectToAction("Combat", new { enemyType = "Ogre" });
            }
            else if (choice == "b")
            {
                _playerService.DeductGold(10); // Example cost for bribing
                ViewData["Message"] = "You bribe the ogre to let you pass.";
                return View("Scenario8");
            }
            else
            {
                return BadRequest("Invalid choice.");
            }
        }

        // Scenario 8
        public IActionResult Scenario8(string choice)
        {
            if (choice == "a")
            {
                return RedirectToAction("Combat", new { enemyType = "Gnoll" });
            }
            else if (choice == "b")
            {
                ViewData["Message"] = "You decide to keep moving and avoid the situation.";
                return View("Scenario9");
            }
            else
            {
                return BadRequest("Invalid choice.");
            }
        }

        // Scenario 9
        public IActionResult Scenario9(string choice)
        {
            if (choice == "a")
            {
                _playerService.DeductGold(50); // Example cost for becoming a thrall
                ViewData["Message"] = "You bow to the evil figure and become his thrall.";
                return View("EndGame");
            }
            else if (choice == "b")
            {
                return RedirectToAction("Combat", new { enemyType = "EvilFigure" });
            }
            else
            {
                return BadRequest("Invalid choice.");
            }
        }

        // Combat Scenario
        public IActionResult Combat(string enemyType)
        {
            ViewData["EnemyType"] = enemyType;
            ViewData["CombatMessage"] = "A combat scenario is taking place!";
            // Implement combat logic here
            return View();
        }

        // End Game
        public IActionResult EndGame()
        {
            ViewData["Message"] = "The adventure comes to an end.";
            return View();
        }
    }
}

