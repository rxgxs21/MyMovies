using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MyMovies.EFDataBase.Models;
using MyMovies.EFDataBase.MoviesContext;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// API relacji Movies
/// </summary>
namespace MyMovies.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private  MoviesContext _db;

        public MovieController(IConfiguration configuration, MoviesContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        /// <summary>
        /// Metoda zwraca odpowiedź w formie listy filmów formatu JSON.
        /// </summary>
        /// 
        /// <returns>Status</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var movies = _db.Movies.ToList();
                return Ok(movies);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured");
            }
        }
        
        /// <summary>
        /// Metoda tworzy nowy film w bazie danych.
        /// </summary>
        /// 
        /// <returns>Status</returns>
        [HttpPost]
        public IActionResult Create([FromBody] Movie movie)
        {
            Movie mov = new Movie();
            mov.Name = movie.Name;
            mov.RealseDate = movie.RealseDate;
            try
            {
                _db.Movies.Add(mov);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured");
            }
            return Ok();
        }

        /// <summary>
        /// Metoda edytuje dane filmu w bazie danych.
        /// </summary>
        /// 
        /// <returns>Status</returns>
        [HttpPut]
        public IActionResult Update([FromBody] Movie movie)
        {
            try
            {
                var mov = _db.Movies.FirstOrDefault(a => a.Id == movie.Id);
                if (mov == null) { return StatusCode(500, "Movie not found"); }
                mov.Name = movie.Name;
                mov.RealseDate = movie.RealseDate;

                _db.Entry(mov).State = EntityState.Modified;
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured");
            }
        }
        /// <summary>
        /// Metoda usuwa filmu z bazy danych.
        /// </summary>
        /// 
        /// <returns>Status</returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            try
            {
                var mov = _db.Movies.FirstOrDefault(a => a.Id == Id);
                if (mov == null) { return StatusCode(404, "Movie not found"); }
                _db.Entry(mov).State = EntityState.Deleted;
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured");
            }
        }
    }
}
