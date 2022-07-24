using Microsoft.AspNetCore.Mvc;
using PokeApiNet;
using System.Diagnostics;
using WhoIsThisPokemon.Models;
using WhoIsThisPokemon.Services;

namespace WhoIsThisPokemon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetRandomPokemon _getRandomPokemon;

        public HomeController(ILogger<HomeController> logger,IGetRandomPokemon getRandomPokemon)
        {
            _logger = logger;
            _getRandomPokemon = getRandomPokemon;
        }

        public IActionResult Index()
        {
            var response = _getRandomPokemon.GetNextPokemon();
            return View(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}