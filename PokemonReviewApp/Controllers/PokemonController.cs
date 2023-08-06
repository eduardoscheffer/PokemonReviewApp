using AutoMapper;
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
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper) // chama o repositorio pro contexto do Controller. chama o AutoMapper também
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        [HttpGet] // Get na Route
        [ProducesResponseType(200)]
        public IActionResult GetPokemons() 
        {
            // usando AutoMapper para mapear (transformar um objeto de um tipo em outro):
            // AutoMapper transforma uma List<Pokemon> em uma List<PokemonDto>:
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemns()); // vai no repositorio e chama o metodo GetPokemons. Usando o AutoMapper vai retornar um PokemonDto

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

            //            _mapper.Map<DestinationClass>(sourceObject);
            var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId));

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
