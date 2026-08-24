using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Labb1_MVC.Services;
using Labb1_MVC.Models;
using System.Collections.Generic;

namespace Labb1_MVC.Controllers
{
    
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public async Task<ActionResult> Index()
        {
            var pokemon = await _pokemonService.GetAllAsync();
            return View(pokemon);
        }

        public async Task<IActionResult> Details(int id)
        {
            var pokemon = await _pokemonService.GetByIdAsync(id);

            if (pokemon == null)
            {
                return RedirectToAction("Index");
            }

            return View(pokemon);
        }

    }
}
