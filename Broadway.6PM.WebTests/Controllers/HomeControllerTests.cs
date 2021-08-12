using Microsoft.VisualStudio.TestTools.UnitTesting;
using Broadway._6PM.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Broadway._6PM.Web.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            var home = new HomeController();
            var result = home.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void IndexV2Test()
        {
            var home = new HomeController();

            Assert.ThrowsException<SomeException>(() => { home.Index(1); });
        }

        [TestMethod()]
        public void IndexV3Test()
        {
            var home = new HomeController();
            var result = home.Index(2);
            Assert.IsNull(result);
        }
    }
}