using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSLT_INF509005_T2.session03
{
    internal class Exercises_3_2
    {
        static void Cau_1()
        {
            //Create a C# program to convert from degrees Celsius to Kelvin and Fahrenheit. Request the user the number of degrees celsius to convert them using the following conversion tables:
            //-kelvin = celsius + 273
            //- fahrenheit = celsius x 18 / 10 + 32
            //- Input
            //• 33
            //- Output
            //• kelvin = 306
            //• fahrenheit = 91

            // Yêu cầu người dùng nhập vào số độ Celsius
            Console.Write("Nhập số độ celsius: ");
            int celsius = Convert.ToInt32(Console.ReadLine());

            // Áp dụng chính xác công thức từ đề bài
            int kelvin = celsius + 273;
            int fahrenheit = celsius * 18 / 10 + 32;

            // In kết quả đầu ra theo đúng định dạng ví dụ
            Console.WriteLine("kelvin= " + kelvin);
            Console.WriteLine("fahrenheit= " + fahrenheit);

            Console.ReadLine();
        }
        static void Cau_2()
        {
            //Create a program in C# for calculate the surface and volume of a sphere, given its radius.
            //-surface = 4 * pi * radius squared
            //- volume = 4 / 3 * pi * radius cubed
            //- Input
            //• 60
            //- Output
            //• Surface: 45238,93
            //• Volume: 678584,1

            Console.Write("Enter a radius: ");
            string input = Console.ReadLine();

            // Chuyển đổi dấu phẩy thành dấu chấm (nếu có) để ép kiểu double không bị lỗi
            input = input.Replace(',', '.');
            double radius = Convert.ToDouble(input);

            double pi = Math.PI;

            // Tính toán theo công thức của đề bài
            double surface = 4 * pi * Math.Pow(radius, 2);
            double volume = (4 / 3) * pi * Math.Pow(radius, 3);

            Console.WriteLine($"Surface: {surface:F2}");
            Console.WriteLine($"Volume: {volume:F2}");

            Console.ReadLine();
        }

        static void Cau_3()
        {
            //Write a program in C# that calculates the result of adding, subtracting, multiplying and dividing two numbers entered by the user.
            //-In addition you should also calculate the rest of the division on the last line.
            //-Input
            //• 12
            //• 3
            //- Output
            //• 12 + 3 = 15
            //• 12 - 3 = 9
            //• 12 x 3 = 36
            //• 12 / 3 = 4
            //• 12 mod 3 = 0

            // Nhập hai số nguyên từ người dùng
            Console.Write("Nhập a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhập b: ");
            int b = Convert.ToInt32(Console.ReadLine());
            
            // In kết quả theo đúng định dạng mẫu của đề bài
            Console.WriteLine($"{a} + {b} = {a + b}");
            Console.WriteLine($"{a} - {b} = {a - b}");
            Console.WriteLine($"{a} x {b} = {a * b}");
            Console.WriteLine($"{a} / {b} = {a / b}");
            Console.WriteLine($"{a} mod {b} = {a % b}");

            Console.ReadLine();
        }

        public static void Main11111(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Cau_1();
            Cau_2();
            Cau_3();

            Console.Write("\nNhấn phím bất kỳ để kết thúc");
            Console.ReadKey();

        }
    }
}
