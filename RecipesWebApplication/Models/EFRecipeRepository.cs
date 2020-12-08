using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesWebApplication.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;

        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Recipe> Recipes => context.Recipes;

        public IQueryable<RecipeReview> Reviews => context.Reviews;
        public IQueryable<Cuisine> Cuisines => context.Cuisines;

        public void SaveRecipe(Recipe recipe)
        {
            if (recipe.RecipeID == 0)
            {
                context.Recipes.Add(recipe);
            }
            else
            {
                Recipe recipeEntry = context.Recipes
                    .FirstOrDefault(r => r.RecipeID == recipe.RecipeID);

                if (recipeEntry != null)
                {
                    recipeEntry.Name = recipe.Name;
                    //add save cuisine
                    recipeEntry.Cusine = recipe.Cusine;
                    recipeEntry.Ingredients = recipe.Ingredients;
                    recipeEntry.CookTime = recipe.CookTime;
                    recipeEntry.Instructions = recipe.Instructions;
                    recipeEntry.Servings = recipe.Servings;
                    recipeEntry.Calories = recipe.Calories;
                    recipeEntry.PrepTime = recipe.PrepTime;
                }
            }
            context.SaveChanges();
        }

        public Recipe DeleteRecipe(int recipeID)
        {
            Recipe recipeEntry = context.Recipes
                .FirstOrDefault(p => p.RecipeID == recipeID);

            if (recipeEntry != null)
            {
                context.Recipes.Remove(recipeEntry);
                context.SaveChanges();
            }

            return recipeEntry;
        }

        //saving reviews
        public void SaveReview(RecipeReview newRecipeReview)
        {
            if (newRecipeReview.RecID != 0 && newRecipeReview.ReviewID == 0)
            {
                context.Reviews.Add(newRecipeReview);
            }
            context.SaveChanges();
        }

        //savine and deleting cuisnines
        public void AddCuisine(Cuisine newCuisine)
        {
            if (newCuisine.CuisineID == 0)
            {
                context.Cuisines.Add(newCuisine);
            }
            else
            {
                Cuisine cuisineEntry = context.Cuisines
                    .FirstOrDefault(c => c.CuisineID == newCuisine.CuisineID);

                if (cuisineEntry != null)
                {
                    cuisineEntry.CuisineName = newCuisine.CuisineName;
                    cuisineEntry.CuisineOrigin = newCuisine.CuisineOrigin;
                }
            }
            context.SaveChanges();
        }

        public Cuisine DeletCuisine(int cuisineID)
        {
            Cuisine cEntry = context.Cuisines
                .FirstOrDefault(c => c.CuisineID == cuisineID);

            if (cEntry != null)
            {
                foreach (Recipe item in context.Recipes.Where(r => r.Cusine == cuisineID))
                {
                    item.Cusine = 0;
                }

                context.Cuisines.Remove(cEntry);
                context.SaveChanges();
            }
            return cEntry;
        }
    }
}
