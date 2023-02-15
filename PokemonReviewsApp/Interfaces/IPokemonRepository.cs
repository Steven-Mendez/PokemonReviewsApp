using PokemonReviewsApp.Models;

namespace PokemonReviewsApp.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
    }
}
