using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesWebApplication.Controllers
{
    [Authorize]//the entire class requires authentication
    public class AdminController : Controller
    {
        private IRecipeRepository repository;

        public AdminController(IRecipeRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            List<Cuisine> allCuisines = new List<Cuisine>();
            allCuisines = repository.Cuisines.ToList() as List<Cuisine>;
            ViewBag.Cuisines = allCuisines;
            return View(repository.Recipes.OrderBy(p => p.Name));
        }

        public ViewResult Edit(int RecipeID)
        {
            List<Cuisine> allCuisines = new List<Cuisine>();
            allCuisines = repository.Cuisines.ToList() as List<Cuisine>;
            ViewBag.Cuisines = allCuisines;

            return View(repository.Recipes
                .FirstOrDefault(p => p.RecipeID == RecipeID));
        }

        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(recipe);
                TempData["message"] = $"{recipe.Name} has been saved!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(recipe);
            }
        }

        public ViewResult Create()
        {
            List<Cuisine> allCuisines = new List<Cuisine>();
            allCuisines = repository.Cuisines.ToList() as List<Cuisine>;
            ViewBag.Cuisines = allCuisines;

            return View("Edit", new Recipe());
        }

        [HttpPost]
        public IActionResult Delete(int recipeId)
        {
            Recipe deletedRecipe = repository.DeleteRecipe(recipeId);

            if (deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.Name} was deleted!";
            }

            return RedirectToAction("Index");
        }

    }
}
