using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_pattern_factory
{
    public class OriCode
    {
        public int ApiTotalCost(string[] objNames)
        {
            int cost = 0;
            foreach (string objName in objNames)
            {
                if (objName == "cake")
                {
                    cost += 100;
                }
                else if (objName == "grean tea")
                {
                    cost += 60;
                }
                else if (objName == "bike")
                {
                    cost += 2000;
                }
            }
            
            return cost;
        }
    }


   


}
