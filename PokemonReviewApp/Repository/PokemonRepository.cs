using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {   
        private readonly DataContext _context;

        public PokemonRepository(DataContext context) // traz o contexto do banco de dados pro repositorio para trabalhar com o banco
        {
            _context = context;
        }
        public ICollection<Pokemon> GetPokemns() // implementa a interface
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList(); // vai na table Pokemon no banco de dados e retorna uma lista com todos os pokemons em ordem de Id
        }

        public Pokemon GetPokemon(int id) => _context.Pokemon.Where(pokemon => pokemon.Id == id).FirstOrDefault(); // filtra a tabela Pokemon para pegar o primeiro Pokemon com a id informada;

        public Pokemon GetPokemon(string name) => _context.Pokemon.Where(pokemon => pokemon.Name == name).FirstOrDefault();

        public decimal GetPokemonRating(int id)
        {
           var review = _context.Reviews.Where(pokemon => pokemon.Id == id);
           if (!review.Any())
                return 0;
           return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public bool PokemonExists(int id) => _context.Pokemon.Any(pokemon => pokemon.Id == id);
    }
}
