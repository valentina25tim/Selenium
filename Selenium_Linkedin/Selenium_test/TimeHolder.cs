using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_test
{
    public static  class TimeHolder
    {
        private static readonly int ShortDelayTime = 500;
        private static readonly int LongDelayTime = 8000;
        private static readonly int DelayTime = 1500;

        public static Task Delay()
        {
            return Task.Delay(DelayTime);
        }
        public static Task ShortDelay()
        {
            return Task.Delay(ShortDelayTime);
        }
        public static Task LongDelay()
        {
            return Task.Delay(LongDelayTime);
        }
        
    }
}
