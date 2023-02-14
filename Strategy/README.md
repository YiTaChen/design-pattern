
# Design Pattern - Strategy (策略模式) 

## 概要：
如果說工廠模式是給個關鍵字生成物件，那策略模式就是使用關鍵字定義要做什麼事情。

## 情境: 
以ERP 系統來說，每一次簽核完成後，我們會將送至下一個簽核流程，
一般情況下員工簽核完成後，單據會送交給主管，主管簽完給處長再到總經理。

單以`完成簽核送交下一位簽核人員`來說，即可使用策略模式來套用。

---
### 架構:
#### Client Site: 
員工使用ERP UI 填完表單，按下完成送出。 

#### Server Site: 
收到資料後，確認填表人的層級，再轉拋給下一位簽核人員。

---

### 最簡易的寫法

#### Server Site:

```` c# 
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
````

如同工廠模式，當系統足夠小而且不會變動的情況，
系統可以滿足需求。

但正常ERP 系統，表單回有退回功能與指定人員(跳級)簽核等等，
表單不會單純按照階級流程簽核；這時在程式碼中加註更多的if else，
很容易增加未來維護的時間與風險。
單元測試上也不容易執行。

這裡效法工廠模式的統整與分離的技巧~~甩鍋~~，
不同的是，會需要使用到interface。

---

```` c#

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

````

### 策略模式優缺點：
#### 缺點：
* 代碼變多。

* 對於初學者，需要的知識量增加，尤其是使用interface 的部分，
比起繼承會需要更多了解。

#### 優點：

* 方便單元測試，增加代碼的可讀性(命名)。

* 好擴展，如程式碼中 class: `finishSignProcess` `UserNotFount` ，
增加了直接完成與回覆沒有使用者。

* 藉由interface，可以起到規範的作用，
則可以把各種策略拆分給多人實作。

#### Addtion:

一開始了解Stragety 模式時，心理OS: 不就寫個class 把各種情況包進去就好了?
後來職務上遇到需要依客戶別開發類似的專案：
通常情況會把那個class copy 過去再進行修改，
但看到class 中的每個方法都有一坨部分可用 部分不可用的情況，
修改起來也挺費勁的，特殊的情況要執行啥的，最後乾脆直接重寫 = =

代碼沒有遵循SOLID 的Single 原則，進而導致代碼很難重用...。

#### reference:
設計模式之禪－18.策略模式(Strategy Pattern)C#範例(筆記)
http://gn870988-blog.logdown.com/posts/1810665-zen-of-design-patterns-18-strategy-pattern-notes

策略模式 (Strategy Pattern)簡介　讓程式碼拓展起來更容易
https://www.appcoda.com.tw/strategy-pattern/


---


