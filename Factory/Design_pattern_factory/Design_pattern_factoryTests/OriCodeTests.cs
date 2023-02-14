using Microsoft.VisualStudio.TestTools.UnitTesting;
using Design_pattern_factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_pattern_factory.Tests
{
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
}