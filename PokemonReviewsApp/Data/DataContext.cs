using Microsoft.EntityFrameworkCore;
using PokemonReviewsApp.Models;

namespace PokemonReviewsApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Owner> Owners { get; set; } = null!;
        public DbSet<Pokemon> Pokemons { get; set; } = null!;
        public DbSet<PokemonCategory> PokemonCategories { get; set; } = null!;
        public DbSet<PokemonOwner> PokemonOwners { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Reviewer> Reviewers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composed Primary Key PokemonCategory
            modelBuilder.Entity<PokemonCategory>()
                .HasKey(pc => new { pc.PokemonId, pc.CategoryId });

            // PokemonCategory >--| Pokemon
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(pc => pc.Pokemon)
                .WithMany(p => p.PokemonCategories)
                .HasForeignKey(pc => pc.PokemonId);

            // PokemonCategory >--| Category
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.PokemonCategories)
                .HasForeignKey(pc => pc.CategoryId);

            // Composed Primary Key PokemonOwner
            modelBuilder.Entity<PokemonOwner>()
                .HasKey(po => new { po.PokemonId, po.OwnerId });

            // PokemonOwner >--| Pokemon
            modelBuilder.Entity<PokemonOwner>()
                .HasOne(po => po.Pokemon)
                .WithMany(p => p.PokemonOwners)
                .HasForeignKey(po => po.PokemonId);

            // PokemonOwner >--| Owner
            modelBuilder.Entity<PokemonOwner>()
                .HasOne(po => po.Owner)
                .WithMany(o => o.PokemonOwners)
                .HasForeignKey(po => po.OwnerId);
        }
    }
}
