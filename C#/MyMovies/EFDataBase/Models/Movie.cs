using System;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.EFDataBase.Models
{
    public class Movie
    {
        //Konfiguracja relacji Movies
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Range(1900, 2100)]
        public int? RealseDate { get; set; }
    }
}
