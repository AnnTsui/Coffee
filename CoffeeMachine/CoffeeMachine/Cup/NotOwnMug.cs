using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeMachine
{
    public class NotOwnMug
    {
        public Queue<string> qNotOwnMug()
        {
            Queue<string> qNotOwnMug = new Queue<string>();
            qNotOwnMug.Enqueue("Not");
            qNotOwnMug.Enqueue("Own");
            qNotOwnMug.Enqueue("Mug");
            return qNotOwnMug;
        }
    }
}