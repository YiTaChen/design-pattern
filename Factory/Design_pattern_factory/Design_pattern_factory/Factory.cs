using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Design_pattern_factory
{
    public class Factory
    {
        public int ApiTotalCost(string[] objNames)
        {
            int cost = 0;
            foreach (string objName in objNames)
            {
                Product product;
                if (objName == "cake")
                {
                    product = new Cake();
                }
                else if (objName == "grean tea")
                {
                    product = new GreanTea();
                }
                else
                {
                    product = new Bike();
                }
                cost += product.getCost();
            }

            return cost;
        }
    }
        
    public abstract class Product
    {
        public int cost;

        public abstract int getCost();

    }

    public class GreanTea : Product
    {
        public GreanTea()
        {
            cost = 60;
        }

        override
        public int getCost()
        {
            return cost;
        }
    }

    public class Cake : Product
    {
        public Cake()
        {
            cost = 100;
        }

        override
        public int getCost()
        {
            return cost;
        }
    }

    public class Bike : Product
    {
        public Bike()
        {
            cost = 2000;
        }

        override
        public int getCost()
        {
            return cost;
        }
    }

}
