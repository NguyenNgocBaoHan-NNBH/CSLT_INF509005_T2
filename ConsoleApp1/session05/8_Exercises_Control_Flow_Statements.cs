using System;
using System.Collections.Generic;
using System.Text;

namespace CSLT_INF509005_T2.session05
{
    internal class _8_Exercises_Control_Flow_Statements
    {
        /// <summary>
        /// Write a program to check whether a triangle is Equilateral, Isosceles or Scalene.
        /// </summary>
        static void Ex01()
        {
            Console.Write("Nhập cạnh a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Nhập cạnh b: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Nhập cạnh c: ");
            int c = int.Parse(Console.ReadLine());

            // Kiểm tra điều kiện tồn tại tam giác
            if (a + b > c && a + c > b && b + c > a)
            {
                if (a == b && b == c)
                {
                    Console.WriteLine("Tam giác đều.");
                }
                else if (a == b || b == c || a == c)
                {
                    Console.WriteLine("Tam giác cân.");
                }
                else
                {
                    Console.WriteLine("Tam giác thường.");
                }
            }
            else
            {
                Console.WriteLine("Ba cạnh không tạo thành một tam giác hợp lệ.");
            }
        }
        /// <summary>
        /// Write a program to read 10 numbers and find their average and sum.
        /// </summary>
        static void Ex02()
        {
            int sum = 0;
            Console.WriteLine("\nNhập vào 10 số:");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"Số thứ {i}: ");
                sum += int.Parse(Console.ReadLine());
            }

            int average = sum / 10;
            Console.WriteLine($"\nTổng: {sum}");
            Console.WriteLine($"Trung bình cộng: {average}");
        }
        /// <summary>
        /// Write a program to display the multiplication table of a given integer.
        /// </summary>
        static void Ex03()
        {
            Console.Write("\nNhập vào một số nguyên: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nBảng nhân của {n}:");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{n} x {i} = {n * i}");
            }

            Console.ReadLine();
        }
        /// <summary>
        /// Write a program to display a pattern like triangles with a number.
        /// The patterns like : (picture)
        /// </summary>
        static void Ex04_and_05()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(numbers[j] + " ");
                }
                Console.WriteLine();
            }

            int temp1 = 0;
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(numbers[temp1++] + " ");

                }
                Console.WriteLine();
            }
            int temp2 = 0;
            int row_num = 4;

            for (int i = 0; i <= 3; i++)
            {
                Console.Write(new string(' ', row_num - 1 - i));
                for (int j = 0; j <= i; j++)
                {

                    Console.Write(numbers[temp2++] + " ");
                }

                Console.WriteLine();

            }
        }
        /// <summary>
        /// Write a program to display the n terms of harmonic series and their 
        /// sum. 1 + 1/2 + 1/3 + 1/4 + 1/5 ... 1/n terms
        /// </summary>
        static void Ex06()
        {
            Console.Write("\nNhập số hạng n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            double sum = 0;

            Console.Write("Chuỗi Harmonic: ");
            for (int i = 1; i <= n; i++)
            {
                sum += 1.0 / i;
                if (i == 1)
                    Console.Write("1");
                else
                    Console.Write($" + 1/{i}");
            }
            Console.WriteLine($"\nTổng của chuỗi: {sum}");
        }
        /// <summary>
        /// Write a program to find the ‘perfect’ numbers within a given number range.
        /// </summary>
        static void Ex07()
        {
            Console.Write("\nNhập khoảng bắt đầu: ");
            int start = int.Parse(Console.ReadLine());

            Console.Write("Nhập khoảng kết thúc: ");
            int end = int.Parse(Console.ReadLine());

            Console.Write($"Các số hoàn hảo từ {start} đến {end} là: ");

            int dem = 0;

            for (int num = start; num <= end; num++)
            {
                int sum = 0;

                for (int i = 1; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        sum += i;
                    }
                }

                if (sum == num)
                {
                    dem++;
                    Console.Write(num + " ");
                }
            }

            if (dem > 0)
                Console.WriteLine();
            else
            {
                Console.WriteLine($"Không có số hoàn hảo trong khoảng này.");
            }
        }
        /// <summary>
        /// Write a program to determine whether a given number is prime or not.
        /// </summary>
        static void Ex08()
        {
            Console.Write("\nNhập số cần kiểm tra: ");
            int so = int.Parse(Console.ReadLine());

            bool kt = true;
            for (int i = 2;i <= so / 2;i++)
            {
                if (so % i == 0)
                {
                    kt = false;
                    break;
                }    
            } 
            if (kt)
                Console.WriteLine($"Số {so} là số nguyên tố");
            else
                Console.WriteLine($"Số {so} KHÔNG là số nguyên tố");
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            Ex01();
            Ex02();
            Ex03();
            Ex04_and_05();
            Ex06();
            Ex07();
            Ex08();

            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}