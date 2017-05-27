using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMovies.Models
{
   public class Movie
    {
        public int MovieId { get; set; }
       [Required(ErrorMessage ="Please enter Movie Title")]
        public string MovieTitle { get; set; }
        [Required(ErrorMessage = "Please enter Genre")]
        public string Genre { get; set; }
        [Required RegularExpression("([1-9][0-9]*)",ErrorMessage = "Please enter Release year")]
        public int ReleaseYear { get; set; }
        [Required(ErrorMessage = "Please enter Amount")]
        public decimal Amount { get; set; }

        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
