using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeMachine
{
    public class cOwnMug: OwnMug,ICup

    {
        public string AddCup()
        {
            string strAddCup = "Cup : ";
            List<string> lCup= UseOwnMug();
            for (int iCount = 0; iCount < lCup.Count; iCount++)
            {
                strAddCup= strAddCup+ lCup[iCount];
            }
            return strAddCup;
        }
    }
}