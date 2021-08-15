using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Broadway._6PM.Web
{
    public class ArithmeticOperation
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            Singleton.Get.Id = 20;
            var s = Singleton.Get.Id;
            return a * b;
        }

        public double Divide(double a, double b)
        {
            return b == 0 ? 0 : a / b;
        }
    }
}