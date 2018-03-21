using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public DateTime ReleasedTime { get; set; }

        public DateTime AddedDate { get; set; }
        [Required]
        [Display(Name = "Number in Stock")]
        [Range(0, 12)]
        public int NumberInStock { get; set; }

        public Genre Genre { get; set; }
        [Display(Name = "Genre Type")]
        public int GenreId { get; set; }



        public Byte NumberAvailable { get; set; }
    }


}