using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class OriCode
    {

        public void ApiSendToNextStage(string userLevel)
        {
            if (userLevel == "Employee")
            {
                Console.WriteLine("Send to Manager");
            }
            else if (userLevel == "Manager")
            {
                Console.WriteLine("Send to Director");
            }
            else if (userLevel == "Director")
            {
                Console.WriteLine("Send to President");
            }
            else if (userLevel == "President")
            {
                Console.WriteLine("Finish Process");
            }
            return ;
        }




    }
}
