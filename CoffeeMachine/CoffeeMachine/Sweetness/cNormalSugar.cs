using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeMachine
{
    public class cNormalSugar:NormalSugar,ISugar
    {
        public  string AddSweetness(int iSweetness)
        {
            string strSweetness = "Sweetness : ";
            NormalSugar oAmountOfSugar = new NormalSugar();
            oAmountOfSugar.AmountOfSugar = iSweetness;
            strSweetness = strSweetness + (oAmountOfSugar.AmountOfSugar/20);
            return strSweetness;
        }
    }
}