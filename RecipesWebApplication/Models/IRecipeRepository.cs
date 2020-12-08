using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesWebApplication.Models
{
    public interface IRecipeRepository
    {
        IQueryable<Recipe> Recipes { get; }
        IQueryable<RecipeReview> Reviews { get; }
        IQueryable<Cuisine> Cuisines { get; }
        void SaveRecipe(Recipe recipe);
        void SaveReview(RecipeReview newRecipeReview);
        Recipe DeleteRecipe(int recipeID);
        void AddCuisine(Cuisine newCuisine);
        Cuisine DeletCuisine(int cuisineID);
    }
}
