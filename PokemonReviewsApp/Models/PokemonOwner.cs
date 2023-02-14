namespace PokemonReviewsApp.Models
{
    public class PokemonOwner
    {
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }
        public Pokemon Pokemon { get; set; } = null!;
        public Owner Owner { get; set; } = null!;
    }
}
