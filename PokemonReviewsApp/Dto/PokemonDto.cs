using PokemonReviewsApp.Models;

namespace PokemonReviewsApp.Dto
{
    public class PokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
    }
}
