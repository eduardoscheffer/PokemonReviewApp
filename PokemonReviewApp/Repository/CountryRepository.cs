using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _datacontext;
        private readonly IMapper _mapper;

        public CountryRepository(DataContext dataContext, IMapper mapper) 
        {
            _datacontext = dataContext;
            _mapper = mapper;
        }

        public bool CountryExists(int id) => _datacontext.Countries.Any(c => c.Id == id);

        public ICollection<Country> GetCountries() => _datacontext.Countries.OrderBy(country => country.Id).ToList();

        public Country GetCountry(int id) => _datacontext.Countries.Where(country => country.Id == id).FirstOrDefault();

        public Country GetCountryByOwner(int ownerId) => _datacontext.Owners.Where(owner => owner.Id == ownerId).Select(c => c.Country).FirstOrDefault();

        public ICollection<Owner> GetOwnersFromACountry(int countryId) => _datacontext.Owners.Where(owner => owner.Id == countryId).ToList();
    }
}
