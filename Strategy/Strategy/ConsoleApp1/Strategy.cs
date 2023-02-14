using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class StrategyClass
    {
        public void ApiSendToNextStage(string userLevel)
        {
            ISendNextStage stage;

            if (userLevel == "Employee")
            {
                stage = new SendToManager();          
            }
            else if (userLevel == "Manager")
            {
                stage = new SendToDirector();
            }
            else if (userLevel == "Director")
            {
                stage = new SendToPresident();
            }
            else if (userLevel == "President")
            {
                stage = new finishSignProcess();
            }
            else if (userLevel == "Special permission")
            {
                stage = new finishSignProcess();
            }
            else
            {
                stage = new UserNotFount();
            }
            stage.toNextStage();

            return;
        }

    }

    interface ISendNextStage
    {
        public void toNextStage();
    }

    public class finishSignProcess : ISendNextStage
    {
        public void toNextStage()
        {
            Console.WriteLine("Finish Process");
        }
    }

    public class SendToManager : ISendNextStage
    {
        public void toNextStage()
        {
            Console.WriteLine("Send to Manager");
        }
    }


    public class SendToDirector : ISendNextStage
    {
        public void toNextStage()
        {
            Console.WriteLine("Send to Director");
        }
    }


    public class SendToPresident : ISendNextStage
    {
        public void toNextStage()
        {
            Console.WriteLine("Send to President");
        }
    }

    public class UserNotFount : ISendNextStage
    {
        public void toNextStage()
        {
            Console.WriteLine("Level not found, pls check");
        }
    }

}
