using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using System.ComponentModel;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")] // passa a rota 
    [ApiController] // diz que vai ser um controller
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository) // chama o repositorio pro contexto do Controller
        {
            _pokemonRepository = pokemonRepository;
        }

        [HttpGet] // Get na Route
        [ProducesResponseType(200)]
        public IActionResult GetPokemons() 
        {
            var pokemons = _pokemonRepository.GetPokemns(); // vai no repositorio e chama o metodo GetPokemons 

            if (!ModelState.IsValid) // se algo der errado
                return BadRequest(ModelState);
            return Ok(pokemons); // retorna o resultado do metodo GetPokemons do PokemonRepository : IPokemonRepository
        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
                return NotFound();

            var pokemon = _pokemonRepository.GetPokemon(pokeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemon);
        }

        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
                return NotFound();

            var rating = _pokemonRepository.GetPokemonRating(pokeId);
            if (!ModelState.IsValid) // se algo der errado
                return BadRequest(ModelState);

            return Ok(rating);
        }
    }
}
