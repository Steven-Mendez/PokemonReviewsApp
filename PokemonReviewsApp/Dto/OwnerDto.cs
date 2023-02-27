using PokemonReviewsApp.Models;

namespace PokemonReviewsApp.Dto
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Gym { get; set; } = null!;
    }
}
