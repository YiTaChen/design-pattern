
# Design Pattern - Factory (工廠模式) 

## 情境: 
既然是工廠模式，那就假設今天我們有一間工廠，可以生產食品或模具，請設計一套可用的系統。

---
### 架構:
#### Client Site: 
UI調用Server的API，傳送Json or string...等資料給伺服器進行處理(產生物件)。 

#### Server Site: 
建立API，把接收到資料拿來進行處理。

---

### 最簡易的寫法

#### Server Site:

```` c# 
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
````

#### 測試程式：

```` c#
 [TestClass()]
    public class OriCodeTests
    {
        [TestMethod()]
        public void ApiTotalCostTest()
        {
            string[] orderList = { "cake", "cake", "grean tea" };

            OriCode obj = new OriCode();
            Assert.AreEqual( 260 ,obj.ApiTotalCost(orderList));

        }
    }
````

這code... 不太好 XDD

先假設上面的code可以暫時滿足客戶需求，
但哪天客戶說需要增加可生產的項目或者要修改`cake`的價格時，都會需要足一查找。


另外以測試的角度來說，已經偏向系統測試而非單元測試。


專案規模小又簡單時，維護起來還可行，但當專案規模擴大時，同樣的design又出現在多個地方 ex: `apiTotalWaitTime(string[] objNames)`，基本上每天要修改這些就飽哩。

因此需要使用統整與分離的技巧(甩鍋)

---

```` c#

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

````

### 工廠模式優缺點
#### 缺點
代碼變多。

對於初學者，需要的知識量增加。

#### 優點

方便單元測試，可以直接對單一工廠或產品進行測試。

好擴展，直接增加個類別即可。

#### Addtion
至於工廠中的if else，後續可以用控制反轉(IOC) 中的依賴注入(DI) 大幅的優化。

---


