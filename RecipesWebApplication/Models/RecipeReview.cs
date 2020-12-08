using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesWebApplication.Models
{
    public class RecipeReview
    {
        
        private int reviewID;
        private int recID;
        private string yourName;
        private string comment;
        private int ratings;

        public int RecID { get => recID; set => recID = value; }
        [Required(ErrorMessage = "Please enter your name.")]
        public string YourName { get => yourName; set => yourName = value; }
        [Required(ErrorMessage = "Please enter your comment.")]
        public string Comment { get => comment; set => comment = value; }
        [Required(ErrorMessage = "Please select a rating.")]
        public int Ratings { get => ratings; set => ratings = value; }
        [Key]
        public int ReviewID { get => reviewID; set => reviewID = value; }
    }
}
