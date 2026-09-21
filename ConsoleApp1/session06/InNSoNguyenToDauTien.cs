using System;
using System.Collections.Generic;
using System.Text;

namespace CSLT_INF509005_T2.session06
{
    internal class InNSoNguyenToDauTien
    {
        public static void Main4(string[] args)
        {
            Console.Write("Ban muon in bao nhieu so nguyen to: ");
            int N = int.Parse(Console.ReadLine());

            int dem = 0;
            int so = 2;
            while (dem <= N)
            {
                bool kt = true;
                for (int i = 2; i <= so / 2; i++)
                {
                    if (so % i == 0)
                    {
                        kt = false;
                        break;
                    }
                }
                if (kt)
                {
                    dem++;
                    Console.Write($"{so}, ");
                    if (dem % 10 == 0)
                        Console.WriteLine();
                }
                so++;
            }
        }
    }
}
