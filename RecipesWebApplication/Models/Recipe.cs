using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecipesWebApplication.Models
{
    public class Recipe
    {
        
        private int recipeID;
        private string name;
        private string instructions;
        private int cookTime;
        private int servings;
        private double calories;
        private int prepTime;
        private string ingredients;
        private int cusine;

        [Required(ErrorMessage = "Please enter the name of the recipe.")]
        public string Name { get => name; set => name = value; }
        [Required(ErrorMessage = "Please enter the ingredients.")]
        public string Ingredients { get => ingredients; set => ingredients = value; }
        [Required(ErrorMessage = "Please enter the cooking instructions.")]
        public string Instructions { get => instructions; set => instructions = value; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter the cooking time.")]
        public int CookTime { get => cookTime; set => cookTime = value; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter the serving size.")]
        public int Servings { get => servings; set => servings = value; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter the calories.")]
        public double Calories { get => calories; set => calories = value; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter the preparation time.")]
        public int PrepTime { get => prepTime; set => prepTime = value; }
        public int RecipeID { get => recipeID; set => recipeID = value; }
        
        public int Cusine { get => cusine; set => cusine = value; }
    }
}
