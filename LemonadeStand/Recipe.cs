using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Recipe
    {
        public int howSweet;
        public int howCold;
        

        public Recipe()
        {
            howSweet = 1;
            howCold = 1;
        }

        public void ChangeRecipe(int[]newRecipe)
        {
            if(newRecipe[0] == newRecipe[1])
            {
                howSweet = 2;
            }
            else if(newRecipe[1] > newRecipe[0])
            {
                howSweet = 1;
            }
            else if (newRecipe[1] == 0)
            {
                howSweet = 4;
            }
            else if (newRecipe[0] > newRecipe[1])
            {
                howSweet = 3;
            }

            if (newRecipe[2] == 0)
            {
                howCold = 0;
            }
            else if (newRecipe[2] >= 1)
            {
                howCold = 1;
            }
            
        }
    }
}