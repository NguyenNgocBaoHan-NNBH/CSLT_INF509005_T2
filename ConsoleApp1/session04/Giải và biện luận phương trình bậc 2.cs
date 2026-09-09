using System;
using System.Collections.Generic;
using System.Text;

namespace CSLT_INF509005_T2.session04
{
    internal class Giải_và_biện_luận_phương_trình_bậc_2
    {
        static void giaiPT(int a, int b, int c)
        {
            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)
                    {
                        Console.WriteLine("Vô số nghiệm, x tuỳ ý");
                    }
                    else //c#0
                    {
                        Console.WriteLine("Vô lý (Phương trình vô nghiệm)"); //c=0
                    }
                }
                else //a=0, b#0
                {
                    double x = -c / b;
                    Console.WriteLine($"Phương trình có 1 nghiệm: x = {x}");
                }

            }
            else //a#0
            {
                if (b == 0)
                {
                    if (c == 0) //ax^2 = 0
                    {
                        Console.WriteLine("x = 0");
                    }
                }
                else //b#0
                {
                    if (c == 0) 
                    {
                        Console.WriteLine($"2 nghiệm x = 0 và x = {-b/a}");
                    }
                    else //c#0
                    {
                        //double delta = b * b - 4 * a * c;
                        double delta = Math.Pow(b, 2) - 4 * a * c;
                        if (delta < 0)
                        {
                            Console.WriteLine("Phương trình không có nghiệm thực");
                        }
                        else if (delta == 0)
                        {
                            double kep = -b / (2 * a);
                            Console.WriteLine($"Phương trình có nghiệm kép: {kep}");
                        }
                        else //delta>0
                        {
                            double x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                            double x2 = (-b + Math.Sqrt(delta)) / (2 * a);
                            Console.WriteLine($"Phương trình có 2 nghiệm phân biệt:");
                            Console.WriteLine($"\tx1 = {x1}");
                            Console.WriteLine($"\tx2 = {x2}");
                        }
                    }    
                }
            }
        }

        public static void Main22(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập hệ số a: "); int a = int.Parse(Console.ReadLine());
            Console.Write("Nhập hệ số b: "); int b = int.Parse(Console.ReadLine());
            Console.Write("Nhập hệ số c: "); int c = int.Parse(Console.ReadLine());

            giaiPT(a,b,c);  
        }
    }
}
