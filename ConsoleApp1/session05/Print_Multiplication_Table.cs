using System;
using System.Collections.Generic;
using System.Text;

namespace CSLT_INF509005_T2.session05
{
    internal class Print_Multiplication_Table
    {
        static void printMultiplicationTable()
        {
            for (int i = 2; i <= 15; i++)
            {
                for (int j = 1; j <=10; j++)
                {
                    Console.WriteLine($" {i} * {j} = {i*j}");
                }
                Console.WriteLine();
            }    
        }

        public static void Main333(string[] args)
        {
            printMultiplicationTable();
        }
    }
}