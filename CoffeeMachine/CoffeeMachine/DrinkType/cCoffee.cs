using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeMachine
{
    public class cCoffee:Coffee,iDrinkType
    {
        public string CreateDrinkType() 
        {   string DrinkTypeInfo = AddCoffee();
            return DrinkTypeInfo;
        }
    }
}