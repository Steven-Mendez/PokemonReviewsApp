namespace PokemonReviewsApp.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public ICollection<Review> Reviews { get; set; } = null!;
    }
}
