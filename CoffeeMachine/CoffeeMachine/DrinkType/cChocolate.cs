using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeMachine
{
    public class cChocolate : Chocolate, iDrinkType
    {
        public string CreateDrinkType()
        {
            string DrinkTypeInfo = AddChocolate();
            return DrinkTypeInfo;
        }
    }
}