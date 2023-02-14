namespace PokemonReviewsApp.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Gym { get; set; } = null!;
        public Country Country { get; set; } = null!;
    }
}
