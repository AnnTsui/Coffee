using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeMachine
{
    public static class cGlobal
    {
        public enum eDrinkType
        {
            Tea=1,
            Coffee=2,
            Chocolate=3
        };
        public enum eSugar
        {
            NormalSugar = 1,
        };
        public enum eCup
        {
            Own = 1,
            NotOwn=2
        };
    }
}