using System;

namespace Vidly.DTO
{
    public class MovieDto
    {
        public int Id { get; set; }
        //[Required]
        //[MaxLength(255)]
        public string Name { get; set; }

        public DateTime ReleasedTime { get; set; }

        public DateTime AddedDate { get; set; }
        // [Required]
        //[Range(0, 12)]
        public int Stock { get; set; }


        // [Display(Name = "Genre Type")]
        public int GenreId { get; set; }
    }
}