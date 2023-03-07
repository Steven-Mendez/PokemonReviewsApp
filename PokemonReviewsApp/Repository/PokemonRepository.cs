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

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault()!;
            var category = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault()!;

            var pokemonOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon,
            };

            _context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon = pokemon,
            };

            _context.Add(pokemonCategory);

            _context.Add(pokemon);

            return Save();
        }

        public bool DeletePokemon(Pokemon pokemon)
        {
            _context.Remove(pokemon);
            return Save();
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

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool UpdatePokemon(Pokemon pokemon)
        {
            _context.Update(pokemon);
            return Save();
        }
    }
}
