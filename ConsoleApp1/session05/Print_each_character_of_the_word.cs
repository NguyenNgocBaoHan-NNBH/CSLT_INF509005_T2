using System;
using System.Collections.Generic;
using System.Text;

namespace CSLT_INF509005_T2.session05
{
    internal class Print_each_character_of_the_word
    {
        public static void Main33(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            /*for (int i = 0; i < 10; i++)
            {
                if (i == 5) continue;//bỏ qua lần lặp hiện tại
                Console.WriteLine(i);
            }*/

            string s = "Đại học Kinh tế TPHCM";

            /*for(int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(s[i]);
            }*/
            
            foreach(char c in s)
            {
                Console.WriteLine(c);
            }    
        }
    }
}
