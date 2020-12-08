using Microsoft.AspNetCore.Mvc;
using RecipesWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesWebApplication.Controllers
{
    public class CuisineController : Controller
    {
        private IRecipeRepository repository;

        public CuisineController (IRecipeRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Cuisines.OrderBy(c => c.CuisineName));
        }

        public ViewResult Edit(int cuisineID)
        {
            //List<Cuisine> allCuisines = new List<Cuisine>();
            //allCuisines = repository.Cuisines.ToList() as List<Cuisine>;
            //ViewBag.Cuisines = allCuisines;

            return View(repository.Cuisines
                .FirstOrDefault(c => c.CuisineID == cuisineID));
        }

        [HttpPost]
        public IActionResult Edit(Cuisine cuisine)
        {
            if (ModelState.IsValid)
            {
                repository.AddCuisine(cuisine);
                TempData["message"] = $"{cuisine.CuisineName} has been saved!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(cuisine);
            }
        }

        public ViewResult Create()
        {

            return View("Edit", new Cuisine());
        }

        [HttpPost]
        public IActionResult Delete(int cuisineId)
        {

            Cuisine deletedCuisine = repository.DeletCuisine(cuisineId);

            if (deletedCuisine != null)
            {
                TempData["message"] = $"{deletedCuisine.CuisineName} was deleted!";
            }

            return RedirectToAction("Index");
        }
    }
}
