using System;
using System.Collections.Generic;
using System.Text;

namespace CSLT_INF509005_T2.session05
{
    internal class Print_each_character_of_the_word
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 5) continue;//bỏ qua lần lặp hiện tại
                Console.WriteLine(i);
            }
        }
    }
}
