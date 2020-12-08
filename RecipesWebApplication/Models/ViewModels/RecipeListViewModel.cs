using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesWebApplication.Models.ViewModels
{
    public class RecipeListViewModel
    {
        public IEnumerable<Recipe> RecipesPerPage { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}
