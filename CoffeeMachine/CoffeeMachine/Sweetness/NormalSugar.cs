using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeMachine
{
    public class NormalSugar
    {
        private int _sugar = 0;
        public int AmountOfSugar
        {
            get
            {
                return _sugar;
            }
            set
            {
                if (value >= 0 && value <= 10)
                { _sugar = 10 * value; }
                else if (value < 0)
                { _sugar = 0; }
                else if (value >10)
                { _sugar = 100; }
            }
        }
    }
}