using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CSLT_INF509005_T2.session04
{
    internal class ExercisesControlFlowStatements
    {
        /// <summary>
        /// Write a C# Sharp program that takes two numbers as input and 
        /// performs an operation(+, -, *, x,/) on them and displays the result of that
        /// operation.
        /// </summary>
        static void Cau_1()
        {
            Console.Write("Enter an integer: ");
            int number = int.Parse(Console.ReadLine());

            if (number % 2 == 0)
            {
                Console.WriteLine($"{number} is an even number.");
            }
            else
            {
                Console.WriteLine($"{number} is an odd number.");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        static void Cau_2()
        {
            Console.Write("\nEnter the first number: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int num2 = int.Parse(Console.ReadLine());

            Console.Write("Enter the third number: ");
            int num3 = int.Parse(Console.ReadLine());

            int largest = num1;

            if (num2 > largest)
            {
                largest = num2;
            }

            if (num3 > largest)
            {
                largest = num3;
            }

            Console.WriteLine($"The largest number is: {largest}");
        }
        /// <summary>
        /// Write a program to check whether a triangle is Equilateral, Isosceles or Scalene.
        /// </summary>
        static void Cau_3()
        {
            Console.Write("\nNhập cạnh a: ");
            float a = Convert.ToSingle(Console.ReadLine());

            Console.Write("Nhập cạnh b: ");
            float b = Convert.ToSingle(Console.ReadLine());

            Console.Write("Nhập cạnh c: ");
            float c = Convert.ToSingle(Console.ReadLine());

            if ((a + b > c) && (a + c > b) && (b + c > a) && a > 0 && b > 0 && c > 0)
            {
                if (a == b && b == c)
                {
                    Console.WriteLine("Đây là tam giác đều.");
                }
                else if (a == b || b == c || a == c)
                {
                    Console.WriteLine("Đây là tam giác cân.");
                }
                else
                {
                    Console.WriteLine("Đây là tam giác thường.");
                }
            }
            else
            {
                Console.WriteLine("Ba cạnh nhập vào không tạo thành một tam giác hợp lệ.");
            }
        }
        /// <summary>
        /// Write a C# Sharp program to accept a coordinate point in an XY
        /// coordinate system and determine in which quadrant the coordinate 
        /// point lies.
        /// </summary>
        static void Cau_4()
        {
            int x, y;
            Console.Write("\nNhập giá trị cho tọa độ X: ");
            x = int.Parse(Console.ReadLine());

            Console.Write("Nhập giá trị cho tọa độ Y: ");
            y = int.Parse(Console.ReadLine());

            if (x > 0 && y > 0)
            {
                Console.WriteLine($"Điểm tọa độ ({x},{y}) nằm ở góc phần tư thứ nhất.");
            }
            else if (x < 0 && y > 0)
            {
                Console.WriteLine($"Điểm tọa độ ({x},{y}) nằm ở góc phần tư thứ hai.");
            }
            else if (x < 0 && y < 0)
            {
                Console.WriteLine($"Điểm tọa độ ({x},{y}) nằm ở góc phần tư thứ ba.");
            }
            else if (x > 0 && y < 0)
            {
                Console.WriteLine($"Điểm tọa độ ({x},{y}) nằm ở góc phần tư thứ tư.");
            }
            else if (x == 0 && y == 0)
            {
                Console.WriteLine($"Điểm tọa độ ({x},{y}) nằm tại gốc tọa độ.");
            }
            else if (x == 0)
            {
                Console.WriteLine($"Điểm tọa độ ({x},{y}) nằm trên trục tung.");
            }
            else if (y == 0)
            {
                Console.WriteLine($"Điểm tọa độ ({x},{y}) nằm trên trục hoành.");
            }
        }
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Cau_1();
            Cau_2();
            Cau_3();
            Cau_4();

            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}