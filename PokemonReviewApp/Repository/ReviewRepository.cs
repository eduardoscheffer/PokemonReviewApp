using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _datacontext;

        public ReviewRepository(DataContext dataContext)
        {
            _datacontext = dataContext;
        }

        public Review GetReview(int reviewId) => _datacontext.Reviews.Where(review => review.Id == reviewId).FirstOrDefault();

        public ICollection<Review> GetReviewOfAPokemon(int pokeId) => _datacontext.Reviews.Where(p => p.Id == pokeId).ToList();

        public ICollection<Review> GetReviews() => _datacontext.Reviews.OrderBy(review => review.Id).ToList();

        public bool ReviewExists(int reviewId) => _datacontext.Reviews.Any(r => r.Id == reviewId);
    }
}
