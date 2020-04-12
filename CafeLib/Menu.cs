using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeLib
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public bool HasFries { get; set; }
        public bool HasDrink { get; set; }
        public decimal MealPrice { get; set; }
        public List<string> ListIngredients { get; set; }
        public Menu() { }
        public Menu(int mealNumber, string mealName, string mealDescription, List<string> listIngredients, bool hasFries, bool hasDrink, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            ListIngredients = listIngredients;
            HasFries = hasFries;
            HasDrink = hasDrink;
            MealPrice = mealPrice;
        }
    }
}
