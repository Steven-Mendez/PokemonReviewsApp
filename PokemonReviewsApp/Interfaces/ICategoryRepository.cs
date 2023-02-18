using PokemonReviewsApp.Models;

namespace PokemonReviewsApp.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory();
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
        bool CategoryExists(int id);
    }
}
