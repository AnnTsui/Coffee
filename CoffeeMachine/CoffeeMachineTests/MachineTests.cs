using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Tests
{
    [TestClass()]
    public class MachineTests
    {
        [TestMethod()]
        public void PutOrderTest()
        {
            Machine oMachine = new Machine();
            
            Assert.AreEqual("<ErrInfo>Invalid XML string input </ErrInfo>", oMachine.PutOrder("Hello bug"));

            Assert.AreEqual("<Info>No Order Received</Info>", oMachine.PutOrder(""));
            Assert.AreEqual("<ID: 1; DrinkTypeInfo:Mint ; bath ; vinegar ; ; Sweetness : 0; Cup : Use Own Mug; >", oMachine.PutOrder("<Drinks><Drink id='1'><DrinkType>1</DrinkType><Sugar Type='1' >1</Sugar><Cup>1</Cup></Drink></Drinks>"));
            Assert.AreEqual("<ID: 2; Drink Type : Coffee; Sweetness : 1; Cup : Not Own Mug ; >", oMachine.PutOrder("<Drinks><Drink id='2'><DrinkType>2</DrinkType><Sugar Type='1'>2</Sugar><Cup>2</Cup></Drink></Drinks>"));
            Assert.AreEqual("<ID: 3; Drink Type : Chocolate; Sweetness : 2; Cup : Use Own Mug; >", oMachine.PutOrder("<Drinks><Drink id='3'><DrinkType>3</DrinkType><Sugar Type='1'>4</Sugar><Cup>1</Cup></Drink></Drinks>"));
            //Invalid Sugar type data
            Assert.AreEqual("<ID: 4; Drink Type : Chocolate; Invalid Sugar type data; Cup : Use Own Mug; >", oMachine.PutOrder("<Drinks><Drink id='4'><DrinkType>3</DrinkType><Sugar Type='2'>4</Sugar><Cup>1</Cup></Drink></Drinks>"));
            //Missing Sugar info
            Assert.AreEqual("<ID: 5; Missing Sugar info; Drink Type : Chocolate; Cup : Use Own Mug; >", oMachine.PutOrder("<Drinks><Drink id='5'><DrinkType>3</DrinkType><Cup>1</Cup></Drink></Drinks>"));
            //Missing Cup & Sugar info
            Assert.AreEqual("<ID: 6; Missing Sugar info; Missing Cup info; Drink Type : Chocolate; >", oMachine.PutOrder("<Drinks><Drink id='6'><DrinkType>3</DrinkType></Drink></Drinks>"));
            //Missing all info
            Assert.AreEqual("<ID: 7; Missing Drink type info; Missing Sugar info; Missing Cup info; >", oMachine.PutOrder("<Drinks><Drink id='7'></Drink></Drinks>"));
            //Overload Sweetness
            Assert.AreEqual("<ID: 8; Drink Type : Chocolate; Sweetness : 5; Cup : Use Own Mug; >", oMachine.PutOrder("<Drinks><Drink id='8'><DrinkType>3</DrinkType><Sugar Type='1'>300</Sugar><Cup>1</Cup></Drink></Drinks>"));
            //negative Sweetness
            Assert.AreEqual("<ID: 8; Drink Type : Chocolate; Sweetness : 0; Cup : Use Own Mug; >", oMachine.PutOrder("<Drinks><Drink id='8'><DrinkType>3</DrinkType><Sugar Type='1'>-300</Sugar><Cup>1</Cup></Drink></Drinks>"));

            Assert.AreEqual("<ID: 1; Drink Type : Coffee; Sweetness : 0; Cup : Use Own Mug; ><ID: 2; Drink Type : Coffee; Sweetness : 0; Cup : Use Own Mug; >"
               , oMachine.PutOrder("<Drinks><Drink id='1'><DrinkType>2</DrinkType><Sugar Type='1' >1</Sugar><Cup>1</Cup></Drink><Drink id='2'><DrinkType>2</DrinkType><Sugar Type='1' >1</Sugar><Cup>1</Cup></Drink></Drinks>"));
         
       }

    }
}