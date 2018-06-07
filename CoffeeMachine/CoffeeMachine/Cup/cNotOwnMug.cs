using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeMachine
{
    public class cNotOwnMug: NotOwnMug,ICup
    {
        public string AddCup()
        {
            string strAddCup = "Cup : ";
            Queue<string> qCup = qNotOwnMug();
            foreach (Object oCup in qCup) { 
                strAddCup = strAddCup + oCup + " ";
        }
            return strAddCup;
        }
    }
}