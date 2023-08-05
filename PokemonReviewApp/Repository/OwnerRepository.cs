using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _dataContext;

        public OwnerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ICollection<Owner> GetOwners() => _dataContext.Owners.OrderBy(owner => owner.Id).ToList();

        public Owner GetOwner(int ownerId) => _dataContext.Owners.Where(owner => owner.Id == ownerId).FirstOrDefault();

        public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
            => _dataContext.PokemonOwners
                .Where(pokemon => pokemon.OwnerId == pokeId)
                    .Select(p => p.Owner).ToList();

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId) 
            => _dataContext.PokemonOwners.Where(owner => owner.OwnerId == ownerId)
            .Select(o => o.Pokemon).ToList();

        public bool OwnerExists(int ownerId) => _dataContext.Owners.Any(owner => owner.Id == ownerId);
    }
}
