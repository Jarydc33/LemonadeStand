using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public abstract class Item
    {   //This is where I am showcasing my second SOLID design principle. Initially, all items were created as variables, but that causes
        //an issue when I want to make changes to all of the items such as if the product goes bad after a certain amount of time.
        //With this class being created and all other inventory items inheriting from it, this class uses the Open/Close princple
        //because if the requirements of the program change, they can be changed here in one location.
        public int quantity;

    }
}
