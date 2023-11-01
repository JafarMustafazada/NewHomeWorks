using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_IndexerExtension
{
    internal static class ExtensionMethods
    {
        public static bool IsPrime(this int value)
        {
            if (value <= 3) return value > 1;
            if (value % 2 == 0 || value % 3 == 0) return false;

            // if we cant use square root methods, then I gonna use square of steps!
            for (int i = 5; i * i <= value; i += 6) 
            {
                if (value % i == 0 || value % (i + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }
        public static bool IsPowOfTwo(this int value)
        {
            return ((value & value - 1) == 0);
        }
    }
}
