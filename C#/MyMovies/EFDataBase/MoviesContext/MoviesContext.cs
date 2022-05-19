using Microsoft.EntityFrameworkCore;
using MyMovies.EFDataBase.Models;

namespace MyMovies.EFDataBase.MoviesContext
{   
    /// <summary>
    /// Model bazy danych.
    /// </summary>
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }

    }
}
