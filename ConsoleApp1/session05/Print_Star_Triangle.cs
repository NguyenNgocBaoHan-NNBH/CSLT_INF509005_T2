using System;
using System.Collections.Generic;
using System.Text;

namespace CSLT_INF509005_T2.session05
{
    internal class Print_Star_Triangle
    {
        static void printStarTriangle()
        {
            int n = 10;
            for (int i = 1;  i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }    
        }

        public static void Main3333(string[] args)
        {
            printStarTriangle();
        }
    }
}
