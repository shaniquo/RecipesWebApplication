using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesWebApplication.Models;

namespace RecipesWebApplication.Models
{
    public class FakeRecipeRepository //: IRecipeRepository
    {
        private static Cuisine c1 = new Cuisine
        {
            CuisineName = "Indian Cuisine",
            CuisineOrigin = "India"
        };

        private static Cuisine c2 = new Cuisine
        {
            CuisineName = "Caribbean Cuisine",
            CuisineOrigin = "Caribbean"
        };

        private static Cuisine c3 = new Cuisine
        {
            CuisineName = "Asian Cuisine",
            CuisineOrigin = "Asia"
        };

        private static Recipe r1 = new Recipe
        {
            //RecipeID = 1,
            Name = "Ackee And Saltfish",
            //Cusine = c2.CuisineID,
            Ingredients =
               "1/2 pound boneless salted codfish " +
               "1/2 cup vegetable oil " +
               "4 cloves garlic, finely chopped " +
               "1 sprig fresh thyme " +
               "2 onions, sliced " +
               "4 scallions,chopped " +
               "1 cup sliced assorted bell peppers(red, green, yellow, orange) " +
               "1 / 4 Scotch bonnet pepper,finely chopped with seeds removed " +
               "1(20 - ounce) can ackee, drained " +
               "1 teaspoon freshly ground black pepper " +
               "1 teaspoon paprika",
            Instructions = "Wash off all the salt from the salted cod fish in cold water, " +
               "and then soak as follows: Soak for 1 hour in hot water, and then drain and replace with " +
               "a new batch of hot water for another hour. The fish will be soaked for a total of 2 hours. " +
               "Heat the oil in a medium skillet over medium heat and then add the chopped garlic and cook for 30 seconds. " +
               "Add the sprig of thyme and cook for 30 seconds.Add the onions, scallions, bell peppers, and Scotch bonnet " +
               "pepper and cook for 5 minutes.Stir the entire mix as needed.Add the prepared codfish to the skillet and simmer " +
               "for 5 minutes, stirring as needed.Add the ackee to the skillet and simmer for another 2 minutes.Stir in the black " +
               "pepper and turn off the stove.Garnish the cooked meal with the paprika.",
            CookTime = 100,
            Servings = 4,
            Calories = 480,
            PrepTime = 20,
           // Reviews = new List<RecipeReview> { rev1, rev2 }
        };

        private static Recipe r2 = new Recipe
        {
            //RecipeID = 2,
            Name = "Oxtail Stew",
            Ingredients =
                "2 -3 tablespoon cooking oil " +
                "1 - 2 pounds oxtail cut up medium pieces " +
                "1 onion chopped " +
                "2 teaspoon minced garlic " +
                "1 - teaspoon fresh chopped thyme " +
                "½ teaspoon smoked paprika " +
                "1 tablespoon ketchup / tomato paste " +
                "1 Whole Scotch bonnet pepper " +
                "2 green onions chopped " +
                "5 - 6 Whole pimento seeds(allspice), " +
                "1 Tablespoon Worcestershire sauce " +
                "1 - teaspoon curry or more adjust to preference " +
                "15 ounce can butter beans, rinsed and drained " +
                "1 teaspoon browning(optional) " +
                "1 Tablespoon bouillon powder or cube(optional) " +
                "Salt to taste",
            Instructions = "Season oxtail with, salt and pepper. Set aside " +
                "In a large pot, heat oil over medium heat, until hot, and then add " +
                "the oxtail sauté stirring, frequently, any browned bits off the bottom " +
                "of the pot, until oxtail is brown.If desire drain oil and leave about " +
                "2 - 3 tablespoons. Add onions, green onions, garlic, thyme, all spice, " +
                "worcestershire, smoked paprika, stir for about a minute.Throw in scotch " +
                "bonnet pepper, tomato paste, bouillon and curry powder, stir for another " +
                "minute.Then add about  4 - 6 cups of water, it's best to start with 4 cups , " +
                "then add as needed . Bring to a boil and let it simmer until tender (depending " +
                "on the oxtail size and preference) about 2- 3 hours, occasionally stirring the saucepan. " +
                "About 20 - 30 minutes before you remove from the stove add broad beans.Adjust t" +
                "hickness of soup with water or stock. Season with salt according to preference.",
            CookTime = 120,
            Servings = 6,
            Calories = 470,
            PrepTime = 15,
           // Reviews = new List<RecipeReview> { rev3 }
        };

        private static Recipe r3 = new Recipe
        {
            //RecipeID = 3,
            Name = "Jamaican Jerk Chicken",
            Ingredients = "1 medium onion, coarsely chopped " +
                "3 medium scallions, chopped " +
                "2 Scotch bonnet chiles, chopped " +
                "2 garlic cloves, chopped " +
                "1 tablespoon five-spice powder " +
                "1 tablespoon allspice berries, coarsely ground " +
                "1 tablespoon coarsely ground pepper " +
                "1 teaspoon dried thyme, crumbled " +
                "1 teaspoon freshly grated nutmeg " +
                "1 teaspoon salt 1/2 cup soy sauce " +
                "1 tablespoon vegetable oil " +
                "Two 3 1/2- to 4-pound chickens, quartered",
            Instructions = "In a food processor, combine the onion, scallions, chiles, garlic, five-spice powder" +
                ", allspice, pepper, thyme, nutmeg and salt; process to a coarse paste. With the machine on, add the " +
                "the soy sauce and oil in a steady stream. Pour the marinade into a large, shallow dish, add the chicken " +
                "and turn to coat. Cover and refrigerate overnight. Bring the chicken to room temperature before proceeding. " +
                "Light a grill. Grill the chicken over a medium-hot fire, turning occasionally, until well browned and cooked " +
                "through, 35 to 40 minutes. (Cover the grill for a smokier flavor.) Transfer the chicken to a platter and serve.",
            CookTime = 160,
            Servings = 8,
            Calories = 390,
            PrepTime = 30,
            //Reviews = new List<RecipeReview> { rev4, rev5 }
        };

        private static Recipe r4 = new Recipe
        {
            //RecipeID = 4,
            Name = "Curried Goat/Mutton",
            Ingredients = "3- 3 1/2 pounds goat meat (cut in chunks) " +
                "¼- ½ cup cooking oil " +
                "2 teaspoons minced garlic " +
                "1 medium onion sliced " +
                "4 - 5 Tablespoons Curry powder " +
                "1 - teaspoon white pepper " +
                "1 - 2 teaspoons fresh thyme " +
                "2 green onions sliced " +
                "2 - 3 medium potatoes " +
                "1 Tablespoon tomato paste " +
                "1 scotch bonnet pepper(adjust to suit taste buds or replace with any hot pepper) " +
                "1 tablespoon Bouillon powder(optional) " +
                "Salt to taste",
            Instructions = "Season goat with, salt and pepper. Set aside " +
                "In a large pot, heat oil over medium heat, until hot, and then add " +
                "the goat meat sauté stirring, frequently, any browned bits off the " +
                "bottom of the pot, until goat is brown. Then add curry, stir for about " +
                "1 - 2 minutes. Add the garlic, white pepper, onions, thyme, tomato paste, " +
                "scallions(green onions) and scotch bonnet pepper stir for about a minute. " +
                "Then pour in just enough water to cover the goat and bring to a boil and let " +
                "it simmer until tender(depending on the goat size and preference) about 2 hours " +
                "or more, stirring the saucepan occasionally and adding more water as needed. " +
                "About 15 - 20 minutes before you remove from the stove add potatoes and bouillon " +
                "powder.Continue cooking until potatoes are tender, if you want really thick curry " +
                "goat let the potatoes cook even more. You may adjust thickness of soup with water or stock.",
            CookTime = 105,
            Servings = 6,
            Calories = 329,
            PrepTime = 15,
           // Reviews = new List<RecipeReview> { rev6 }
        };

        private static Recipe r5 = new Recipe
        {
            //RecipeID = 5,
            Name = "Brown Stewed Chicken",
            Ingredients = "Chicken Marinate " +
                "5 - 6 chicken thighs bone in trimmed of excess fat " +
                "1 teaspoons salt " +
                "½ teaspoons bouillon chicken powder " +
                "½ teaspoon minced ginger " +
                "1 teaspoon minced garlic " +
                "½ teaspoon white pepper " +
                "1 - teaspoon fresh thyme " +
                "½ teaspoon smoked paprika " +
                "2 green onions diced " +
                "Brown Chicken Stew " +
                "2 Tablespoons or more canola oil " +
                "1 Tablespoon brown sugar " +
                "1 large onion diced " +
                "1 - teaspoon garlic minced " +
                "2 Tablespoons ketchup " +
                "1 teaspoon browning sauce " +
                "1 - teaspoon fresh or dried thyme " +
                "1 - teaspoon hot sauce sub chili sauce " +
                "1 1 / 2 teaspoon smoked paprika " +
                "2 small bell pepper " +
                "1 / 2 teaspoon white pepper " +
                "3 / 4 cup chicken broth / water " +
                "Salt and to taste",
            Instructions = "Place chicken thighs in a large bowl or slow-cooker insert. Then " +
                "seasoned with all marinate ingredients- salt, chicken bouillon, garlic, ginger, paprika, " +
                "white pepper and thyme. Mix chicken with a spoon or with hands until they are well " +
                "coated, cover tightly and set aside in the fridge Marinate for about an hour or " +
                "preferably over night When ready to cook heat up a skillet or large sauce pan with " +
                "about 2 tablespoons oil, and then brown the chicken about 3 - 4 minutes until chicken " +
                "is golden brown: remove and place in the crockpot.Drain any excess oil from the skillet " +
                "and leave about 2 Tablespoons of oil. Add onions, garlic, hot sauce, smoked paprika, " +
                "sugar, browning sauce, ketchup, bell peppers and salt to taste.Stir for about 2 - 3 " +
                "minutes until onions is translucent. Then add to crockpot, deglaze pan with about " +
                "¾ cup of water add to slow cooker, together with ketchup, brown sauce and any remaining " +
                "marinate from the chicken. Cover and cook on high for about 3 - 4 hours.Remove and serve " +
                "with rice and beans",
            CookTime = 180,
            Servings = 6,
            Calories = 183,
            PrepTime = 20
        };


        private static RecipeReview rev1 = new RecipeReview() { /*ReviewID = 1,*/ RecID = 1, Comment = "Nice recipe", YourName = "John Doe", Ratings = 4 };
        private static RecipeReview rev2 = new RecipeReview() { /*ReviewID = 2,*/ RecID = 1, Comment = "Great recipe", YourName = "Jane Doe", Ratings = 5 };
        private static RecipeReview rev3 = new RecipeReview() { /*ReviewID = 3,*/ RecID = 2, Comment = "I love it!!!!!!!", YourName = "Mary Poppins", Ratings = 5 };
        private static RecipeReview rev4 = new RecipeReview() { /*ReviewID = 4,*/ RecID = 3, Comment = "Not too bad.", YourName = "Tom Hortons", Ratings = 2 };
        private static RecipeReview rev5 = new RecipeReview() { /*ReviewID = 5,*/ RecID = 3, Comment = "Have it your way", YourName = "Berger King", Ratings = 3 };
        private static RecipeReview rev6 = new RecipeReview() { /*ReviewID = 6,*/ RecID = 4, Comment = "It's finger lickin' good ", YourName = "Karl Frank Collins", Ratings = 5 };

        private static List<Cuisine> cuisines = new List<Cuisine>() { c1, c2, c3 };

        private static List<Recipe> recipes = new List<Recipe>() { r1, r2, r3, r4, r5 };

        private static List<RecipeReview> reviews = new List<RecipeReview>() { rev1, rev2, rev3, rev4, rev5/*, rev6*/};
        public IQueryable<Recipe> Recipes => recipes.AsQueryable<Recipe>();
        public IQueryable<RecipeReview> Reviews => reviews.AsQueryable<RecipeReview>();
        public IQueryable<Cuisine> Cuisines => cuisines.AsQueryable<Cuisine>();



    }
}

