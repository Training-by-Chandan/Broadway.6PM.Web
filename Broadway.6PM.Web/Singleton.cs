using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Broadway._6PM.Web
{
    public class Singleton
    {
        private Singleton()
        {
        }

        private static Singleton singleton;

        public static Singleton Get
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new Singleton();
                }
                return singleton;
            }
        }

        //rest of the thing is our logic
        public int Id = 10;

        public string Str = "SomeString";
    }
}