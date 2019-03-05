using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Recipe
    {
        public int HowSweet;
        public int HowCold;
        

        public Recipe()
        {
            HowSweet = 1;
            HowCold = 1;
        }

        public void ChangeRecipe(int[]NewRecipe)
        {
            if(NewRecipe[0] == NewRecipe[1])
            {
                HowSweet = 2;
            }
            else if(NewRecipe[1] > NewRecipe[0])
            {
                HowSweet = 1;
            }
            else if (NewRecipe[1] == 0)
            {
                HowSweet = 4;
            }
            else if (NewRecipe[0] > NewRecipe[1])
            {
                HowSweet = 3;
            }

            if (NewRecipe[2] == 0)
            {
                HowCold = 1;
            }
            else if (NewRecipe[2] == 1)
            {
                HowCold = 2;
            }
            else if(NewRecipe[2] > 1)
            {
                HowCold = 3;
            }
        }
    }
}