namespace PokemonReviewsApp.Models
{
    public class PokemonCategory
    {
        public int PokemonId { get; set; }
        public int CategoryId { get; set; }
        public Pokemon Pokemon { get; set; } = null!;
        public Category Category { get; set; } = null!;
    }
}
