using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPracticeTests
{
    public static class WaitHelper
    {
        public static void Wait(int waitTime = 3)
        {
            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).TotalSeconds < waitTime) { }
        }
    }
}
