using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;
using System.Collections;
using System.Threading.Tasks;
using System.Threading;

namespace CoffeeMachine
{
    public class Machine : IMachine
    {
        public string PutOrder(string strDetails)
        {
            try
            {
                int iThreadCount = Int32.Parse(ConfigurationManager.AppSettings["iThreadCount"]);
                string strDrinks = "";
                if (strDetails == "") { return "<Info>No Order Received</Info>"; }
                else
                {

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(strDetails);
                    // XmlNodeList xmlDrinks = xmlDoc.GetElementsByTagName("Drink");
                    // for (int iDrinks = 0; iDrinks < xmlDrinks.Count; iDrinks++)
                    IEnumerator eDrinkNodes = xmlDoc.SelectNodes("//Drink").GetEnumerator();
                    List<Task<int>> lCreateDrink = new List<Task<int>>();
                    for (int iThread = 1; iThread <= iThreadCount; iThread++)
                    {
                        var t = Task.Run(() => CreateDrink(eDrinkNodes, ref strDrinks));
                        t.Wait();
                        //Lock strDrink

                    }
                }
                return strDrinks;
            }
            catch(XmlException ex)
            {
                // Loadxml went wrong
                return "<ErrInfo>Invalid XML string input </ErrInfo>";
            }
            catch (Exception ex)
            {
                // Some other Error
                return "<ErrInfo>" + ex.Message + " </ErrInfo>";
            }
          }
         private void CreateDrink(IEnumerator eDrinkNodes, ref string strDrinks)
        {
            XmlNode nodeDrink;
            lock (eDrinkNodes)
            {
                if (!eDrinkNodes.MoveNext())
                { return; }
                nodeDrink = (XmlNode)eDrinkNodes.Current;
            }
            string strDrink = "ID: " + nodeDrink.Attributes["id"].Value +"; ";
            iDrinkType oDrinkType;
            ICup oCup;
            ISugar oSugar;
            if (nodeDrink.SelectNodes("DrinkType").Count==0 )
            { strDrink = strDrink + "Missing Drink type info; "; }
            if (nodeDrink.SelectNodes("Sugar").Count == 0)
            { strDrink = strDrink + "Missing Sugar info; "; }
            if (nodeDrink.SelectNodes("Cup").Count == 0)
            { strDrink = strDrink + "Missing Cup info; "; }
            foreach (XmlNode childDrinkType in nodeDrink.SelectNodes("DrinkType"))
            {
                oDrinkType = SetDrinkType(Int32.Parse(childDrinkType.InnerText));
                if (oDrinkType == null)
                { strDrink = strDrink + "Invalid Drink type data; "; }
                else
                { strDrink = strDrink + oDrinkType.CreateDrinkType() + "; "; }
            }
            foreach (XmlNode childSugar in nodeDrink.SelectNodes("Sugar"))
            {
                oSugar = SetSugar(Int32.Parse(childSugar.Attributes["Type"].Value));
                if (oSugar == null)
                { strDrink = strDrink + "Invalid Sugar type data; "; }           
                else
                { strDrink = strDrink + oSugar.AddSweetness(Int32.Parse(childSugar.InnerText)) + "; "; }
                
            }
            foreach (XmlNode childCup in nodeDrink.SelectNodes("Cup"))
            {
                oCup = SetCup(Int32.Parse(childCup.InnerText));
                if (oCup == null)
                { strDrink = strDrink + "Invalid cup data; "; }    
                else
                { strDrink = strDrink + oCup.AddCup() + "; "; }
            }
            lock (strDrinks)
            {
                strDrinks = strDrinks + "<"+strDrink+">";
            }
        }
           private iDrinkType SetDrinkType(int iDrinkType)
           {
            switch(iDrinkType)
            {
                case (int)cGlobal.eDrinkType.Chocolate:
                    return new cChocolate();
                case (int)cGlobal.eDrinkType.Coffee:
                    return new cCoffee();
                case (int)cGlobal.eDrinkType.Tea:
                    return new cTea();
            }
            return null;
           }
        private ISugar SetSugar(int iSugar)
        {
            switch (iSugar)
            {
                case (int)cGlobal.eSugar.NormalSugar:
                    return new cNormalSugar();
            }
            return null;
        }
        private ICup SetCup(int iCup)
        {
            switch (iCup)
            {
                case (int)cGlobal.eCup.NotOwn:
                    return new cNotOwnMug();
                case (int)cGlobal.eCup.Own:
                    return new cOwnMug();
            }
            return null;
        }
    }
}
