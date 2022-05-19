using Microsoft.EntityFrameworkCore;
using MyMovies.EFDataBase.Models;

namespace MyMovies.EFDataBase.MoviesContext
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }

    }
}
