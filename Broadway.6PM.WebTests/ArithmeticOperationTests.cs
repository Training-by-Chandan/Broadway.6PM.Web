using Microsoft.VisualStudio.TestTools.UnitTesting;
using Broadway._6PM.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadway._6PM.Web.Tests
{
    [TestClass()]
    public class ArithmeticOperationTests
    {
        [TestMethod()]
        public void AddTest()
        {
            double x = 20;
            double y = 30;
            double expected = 50;
            var actual = new ArithmeticOperation().Add(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SubtractTest()
        {
            double x = 30;
            double y = 20;
            double expected = 10;
            var actual = new ArithmeticOperation().Subtract(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            double x = 2;
            double y = 30;
            double expected = 60;
            var actual = new ArithmeticOperation().Multiply(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DivideTest()
        {
            double x = 20;
            double y = 5;
            double expected = 4;
            var actual = new ArithmeticOperation().Divide(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DivideBy0Test()
        {
            double x = 20;
            double y = 0;
            double expected = 0;
            var actual = new ArithmeticOperation().Divide(x, y);

            Assert.AreEqual(expected, actual);
        }
    }
}