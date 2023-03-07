using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewsApp.Data;
using PokemonReviewsApp.Interfaces;
using PokemonReviewsApp.Models;

namespace PokemonReviewsApp.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReviewerRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateReviewer(Reviewer reviewer)
        {
            _context.Add(reviewer);
            return Save();
        }

        public bool DeleteReviewer(Reviewer reviewer)
        {
            _context.Remove(reviewer);
            return Save();
        }

        public Reviewer GetReviewer(int reviewerId)
        {
            return _context.Reviewers
                .Where(r => r.Id == reviewerId)
                .Include(r => r.Reviews)
                .FirstOrDefault()!;
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _context.Reviewers.ToList();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return _context.Reviews
                .Where(r => r.Reviewer.Id == reviewerId)
                .ToList();
        }

        public bool ReviwersExist(int reviewerId)
        {
            return _context.Reviewers.Any(r => r.Id == reviewerId);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool UpdateReviewer(Reviewer reviewer)
        {
            _context.Update(reviewer);
            return Save();
        }
    }
}
