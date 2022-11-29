using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Course_Homework.Models
{
    public class Rating
    {
        [Key]
        public int RatingID { get; set; }

        [Display(Name = "Rating")]
        public decimal RatingPlace { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Language")]
        public string Language { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Distributed by")]
        public string DistributedBy { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Award")]
        public string Award { get; set; }

        [Display(Name = "Box office")]
        public decimal BoxOffice { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}