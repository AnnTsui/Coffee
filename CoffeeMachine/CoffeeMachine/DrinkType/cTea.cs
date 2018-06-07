using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeMachine
{
    public class cTea : Tea, iDrinkType
    {
        public string CreateDrinkType()
        {
            string strDrinkTypeInfo = "DrinkTypeInfo:";
            string[] DrinkTypeInfo = AddTea();
            foreach (string strDrinkType in DrinkTypeInfo)
            {
                strDrinkTypeInfo = strDrinkTypeInfo + strDrinkType+" ; " ;
            }
            return strDrinkTypeInfo;
        }
    }
}