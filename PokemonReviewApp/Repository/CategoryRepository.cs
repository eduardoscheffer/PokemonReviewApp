using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _datacontext;

        public CategoryRepository(DataContext dataContext)
        {
            _datacontext = dataContext;
        }
        public bool CategoriesExists(int categoryId) => _datacontext.Categories.Any(category => category.Id == categoryId);

        public ICollection<Category> GetCategories() => _datacontext.Categories.OrderBy(category => category.Id).ToList();

        public Category GetCategory(int id) => _datacontext.Categories.Where(category => category.Id == id).FirstOrDefault();

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId) => _datacontext.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
    }
}
