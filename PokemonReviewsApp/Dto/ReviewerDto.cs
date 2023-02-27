using PokemonReviewsApp.Models;

namespace PokemonReviewsApp.Dto
{
    public class ReviewerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public ICollection<Review> Reviews { get; set; } = null!;
    }
}
