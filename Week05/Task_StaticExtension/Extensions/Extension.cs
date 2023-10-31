using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_StaticExtension.Extensions
{
    internal static class Extension
    {
        public static bool CheckGroupNo(this string GroupNo)
        {
            //Console.WriteLine("g1");
            if (String.IsNullOrWhiteSpace(GroupNo) || GroupNo.Length != 4 || (!Char.IsUpper(GroupNo[0]))) return false;
            //Console.WriteLine("g2");
            for (int i = 1; i < 4; i++)
            {
                if (!Char.IsNumber(GroupNo[i])) return false;
            }

            return true;
        }

        public static bool CheckFullName(this string FullName)
        {
            //Console.WriteLine("c1");
            if (String.IsNullOrWhiteSpace(FullName) || (!Char.IsUpper(FullName[0]))) return false;
            //Console.WriteLine("c2");
            int SurnameStarts = 0;
            for (int i = 1; i < FullName.Length; i++)
            {
                if (FullName[i] == ' ')
                {
                    SurnameStarts = i + 1;
                    break;
                }
                else if (!Char.IsLower(FullName[i]))
                {
                    //Console.WriteLine("c3");
                    return false;
                }
            }
            //Console.WriteLine("c4");
            if (SurnameStarts == 0 || SurnameStarts >= FullName.Length || (!Char.IsUpper(FullName[SurnameStarts]))) return false;
            //Console.WriteLine("c5");
            for (int i = SurnameStarts + 1; i < FullName.Length; i++)
            {
                if (!Char.IsLower(FullName[i])) return false;
            }

            return true;
        }
    }
}
