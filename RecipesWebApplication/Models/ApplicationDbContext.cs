using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RecipesWebApplication.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
            
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeReview> Reviews { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
    }
    
}
