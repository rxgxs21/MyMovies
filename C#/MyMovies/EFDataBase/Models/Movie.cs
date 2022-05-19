using System;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.EFDataBase.Models
{
    /// <summary>
    /// Model filmu w bazie danych.
    /// </summary>
    public class Movie
    { 
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
