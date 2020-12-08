using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesWebApplication.Models
{
    public class Cuisine
    {
        private int cuisineID;
        private string cuisineName;
        private string cuisineOrigin; //country where the cuisine comes from

        public string CuisineName { get => cuisineName; set => cuisineName = value; }
        public string CuisineOrigin { get => cuisineOrigin; set => cuisineOrigin = value; }
        public int CuisineID { get => cuisineID; set => cuisineID = value; }
    }
}
