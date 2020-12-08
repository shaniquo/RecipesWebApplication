using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;//to use the authorize attribute
using Microsoft.AspNetCore.Mvc;
using RecipesWebApplication.Models;
using RecipesWebApplication.Models.ViewModels;

namespace RecipesWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IRecipeRepository recipeRepository;
        
        public int PageSize = 3;
        public HomeController(IRecipeRepository repo)
        {
            recipeRepository = repo;
        }

        //use to flag as authorized before the user can access this action[Authorize]
        public ViewResult RecipeList(int recipePage = 1) => 
            View(
                    new RecipeListViewModel
                    {
                        RecipesPerPage =
                            recipeRepository.Recipes.OrderBy(p => p.Name)
                            .Skip((recipePage - 1) * PageSize)
                            .Take(PageSize),

                        PagingInfo = new PagingInfo
                        {
                            CurrentPage = recipePage,
                            ItemsPerPage = PageSize,
                            TotalItems = recipeRepository.Recipes.Count()
                        }
                    }
                );
        public ViewResult Menu(int recipePage = 1) =>
            View(
                    new RecipeListViewModel
                    {
                        RecipesPerPage =
                            recipeRepository.Recipes.OrderBy(p => p.Name)
                            .Skip((recipePage - 1) * PageSize)
                            .Take(PageSize),

                        PagingInfo = new PagingInfo
                        {
                            CurrentPage = recipePage,
                            ItemsPerPage = PageSize,
                            TotalItems = recipeRepository.Recipes.Count()
                        }
                    }
                );

        public ViewResult Index()
        {
            return View();
        }
        public ViewResult Contact()
        {
            return View();
        }
        public ViewResult Gallery()
        {
            return View();
        }

        [HttpGet]
        public ViewResult ReviewRecipe(int id)
        {            
            if (id == 0)
            {
                //No recipe selected therefore return to recipe list ;
                //returns to the view and shows the appropriate error messages
                return View("RecipeList", recipeRepository.Recipes.OrderBy(p => p.Name));                
            }
            else
            {               
                Recipe selectedRecipe = recipeRepository.Recipes.Where(p => p.RecipeID == id).FirstOrDefault();
                ViewBag.rSel = selectedRecipe.Name;
                ViewBag.rSelID = selectedRecipe.RecipeID;
                return View();
            }
        }

        [HttpPost]//saves the information the client entered
        public ViewResult ReviewRecipe(RecipeReview newReview)
        {
            if (ModelState.IsValid)
            {
                recipeRepository.SaveReview(newReview);
                //string message = $"Thanks for reviewing our /*{reviewedRecipe.Name} */ recipe";
                string message = $"Thanks for reviewing our recipe";
                return View("Thanks", message );//can redirected to thanks view
            }
            else
            {
                //returns to the view and shows the appropriate error messages
                return View();
            }
        }

        public ViewResult ViewRecipe(int id)
        {
            Recipe newRecipe = new Recipe();
            newRecipe = recipeRepository.Recipes.Where(p => p.RecipeID == id).FirstOrDefault();

            List<Cuisine> allCuisines = new List<Cuisine>();
            allCuisines = recipeRepository.Cuisines.ToList() as List<Cuisine>;
            ViewBag.Cuisines = allCuisines;

            //Cuisine rCusine = new Cuisine();
            //if (recipeRepository.Cuisines.Where(c => c.CuisineID == newRecipe.Cusine).FirstOrDefault().CuisineID != 0)
            //{
            //    rCusine = recipeRepository.Cuisines.Where(c => c.CuisineID == newRecipe.Cusine).FirstOrDefault();
            //}

            List<RecipeReview> recipeReview = new List<RecipeReview>();
            recipeReview = recipeRepository.Reviews.Where(r => r.RecID == id).AsEnumerable().ToList();
            ViewBag.Reviews = recipeReview;
            return View(newRecipe);            
        }
    }
}
