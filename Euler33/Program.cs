using System;
using System.Linq;

namespace Euler33
{
    class Program
    {
        static void Main(string[] args)
        {
            long aProd = 1;
            long bProd = 1;
            foreach(int a in Enumerable.Range(10, 90))
            {
                foreach (int b in Enumerable.Range(a, 100 - a))
                {
                    int aTen = a / 10;
                    int bTen = b / 10;
                    int aUnit = a % 10;
                    int bUnit = b % 10;

                    if ((aUnit == bUnit) && (aUnit == 0)) //trivial divide by 10
                        continue;
                    if ((aTen == bTen) && (aUnit == bUnit) && (aTen == aUnit)) //trivial, e.g. a == b == 55
                        continue; 

                    //diagonal simplification
                    if(((aTen == bUnit) && (aUnit * b  == a * bTen) && (bTen != 1)) ||
                        ((aUnit == bTen) && (bUnit != 0) && (aTen * b == a * bUnit)))
                    {
                        Console.WriteLine(a + " / " + b + " == " + aTen + " / " + bUnit);
                        aProd *= a;
                        bProd *= b;
                    }

                    //note: simplifying by units alone implies that aUnit == bUnit which in turns trivially implies aTen == bTen
                    //and the same for simplifying by tens alone
                }
            }
            Console.WriteLine(bProd / GCD(aProd, bProd));
            Console.ReadLine();
        }

        static long GCD(long a, long b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
