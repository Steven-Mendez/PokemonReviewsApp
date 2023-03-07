using AutoMapper;
using PokemonReviewsApp.Data;
using PokemonReviewsApp.Interfaces;
using PokemonReviewsApp.Models;

namespace PokemonReviewsApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReviewRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateReview(Review review)
        {
            _context.Reviews.Add(review);
            return Save();
        }

        public bool DeleteReviews(List<Review> reviews)
        {
            _context.RemoveRange(reviews);
            return Save();
        }

        public bool DeteleReview(Review review)
        {
            _context.Remove(review);
            return Save();
        }

        public Review GetReview(int reviewId)
        {
            return _context.Reviews.FirstOrDefault(r => r.Id == reviewId)!;
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfAPokemon(int pokeId)
        {
            return _context.Reviews.Where(r => r.Pokemon.Id == pokeId).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _context.Reviews.Any(r => r.Id == reviewId);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool UpdateReview(Review review)
        {
            _context.Update(review);
            return Save();
        }
    }
}
