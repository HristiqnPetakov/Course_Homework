using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Course_Homework.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Movie name")]
        public string Name { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Directed by")]
        public string DirectedBy { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Written by")]
        public string WrittenBy { get; set; }

        [Display(Name = "Release date ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }


        [Display(Name = "Rating")]
        public int RatingId { get; set; }
        public virtual Rating Rating { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

    }
}