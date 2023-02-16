using PokemonReviewsApp.Data;
using PokemonReviewsApp.Interfaces;
using PokemonReviewsApp.Models;

namespace PokemonReviewsApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        public readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemons.Where(pokemon => pokemon.Id == id).FirstOrDefault()!;
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemons.Where(pokemon => pokemon.Name == name).FirstOrDefault()!;
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review = _context.Reviews.Where(review => review.Pokemon.Id == pokeId);

            if (review is null || !review.Any())
                return 0;

            return Convert.ToDecimal(review.Average(review => review.Rating));
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemons.OrderBy(pokemon => pokemon.Id).ToList();
        }

        public bool PokemonExits(int pokemonId)
        {
            return _context.Pokemons.Any(pokemon => pokemon.Id == pokemonId);
        }
    }
}
