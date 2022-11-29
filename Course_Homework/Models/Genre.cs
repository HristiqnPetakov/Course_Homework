using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Course_Homework.Models
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Genre")]
        public string GenrePlace { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Produced by")]
        public string ProducedBy { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Based on")]
        public string BasedOn { get; set; }

        [Display(Name = "Running time")]
        public float RunningTime { get; set; }

        [Display(Name = "Budget")]
        public decimal Budget { get; set; }

        [Display(Name = "Nominations")]
        public long Nominations { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }


    }
}