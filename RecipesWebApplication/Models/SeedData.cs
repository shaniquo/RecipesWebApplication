using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace RecipesWebApplication.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            FakeRecipeRepository fakeRecipeRepository = new FakeRecipeRepository();
            
           context.Database.Migrate();
            

            if (!context.Cuisines.Any())
            {
                context.Cuisines.AddRange(fakeRecipeRepository.Cuisines);
                context.SaveChanges();
            }

            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(fakeRecipeRepository.Recipes);
                context.SaveChanges();
            }

            if (!context.Reviews.Any())
            {
                context.Reviews.AddRange(fakeRecipeRepository.Reviews);
                context.SaveChanges();
            }

        }

        
    }
}
