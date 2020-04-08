using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model.Tests
{
    [TestClass()]
    public class ShopComputerModelTests
    {
        [TestMethod()]
        public void ShopComputerModelTest()
        {
            var shop = new ShopComputerModel();
            Console.WriteLine(shop.Sellers.Count);
            shop.Start();
        }

    }
}