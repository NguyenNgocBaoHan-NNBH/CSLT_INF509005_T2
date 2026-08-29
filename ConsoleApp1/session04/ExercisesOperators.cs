using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSLT_INF509005_T2.session04
{
    internal class ExercisesOperators
    {
        
        /// <summary>
        /// Write a C# Sharp program that takes two numbers as input and 
        /// performs an operation(+, -, *, x,/) on them and displays the result of that
        /// operation.
        /// </summary>
        static void Bai_1()
        {
            Console.Write("Nhap so a="); int a = int.Parse(Console.ReadLine());
            Console.Write("Nhap so b="); int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"{a} + {b} = {a + b}");
            Console.WriteLine($"{a} - {b} = {a - b}");
            Console.WriteLine($"{a} * {b} = {a * b}");
            Console.WriteLine($"{a} / {b} = {a / b}");
            Console.WriteLine($"{a} % {b} = {a % b}");
        }
        /// <summary>
        /// Write a C# Sharp program to display certain values of the function x = y2 
        /// + 2y + 1 (using integer numbers for y, ranging from -5 to +5).
        /// </summary>
        static void Bai_2()
        {
            Console.WriteLine("\ny\tx");
            for (int y = -5; y <= 5; y++)
            {
                int x = (y * y) + (2 * y) + 1;
                Console.WriteLine($"{y}\t{x}");
            }
        }
        /// <summary>
        /// Write a C# Sharp program that takes distance and time (hours, minutes, 
        /// seconds) as input and displays speed in kilometers per hour(km / h) and
        /// miles per hour(miles/h).
        /// </summary>
        static void Bai_3()
        {
            Console.Write("\nNhập khoảng cách (mét): ");
            float distance = Convert.ToSingle(Console.ReadLine());

            Console.Write("Nhập số giờ: ");
            float hours = Convert.ToSingle(Console.ReadLine());

            Console.Write("Nhập số phút: ");
            float minutes = Convert.ToSingle(Console.ReadLine());

            Console.Write("Nhập số giây: ");
            float seconds = Convert.ToSingle(Console.ReadLine());

            float totalHours = hours + (minutes / 60.0f) + (seconds / 3600.0f);

            float distanceKm = distance / 1000.0f;
            float distanceMiles = distance / 1609.0f;
         
            float speedKh = distanceKm / totalHours;
            float speedMph = distanceMiles / totalHours;

            Console.WriteLine("Kết quả vận tốc:");
            Console.WriteLine($"- Kilômét trên giờ (km/h): {speedKh}");
            Console.WriteLine($"- Dặm trên giờ (miles/h): {speedMph}");
        }
        /// <summary>
        /// Write a C# Sharp program that takes the radius of a sphere as input and 
        /// calculates and displays the surface and volume of the sphere.V = 
        /// 4/3*π* r^3
        /// </summary>
        static void Bai_4()
        {
            Console.Write("\nNhập bán kính của hình cầu (r): ");
            double r = Convert.ToDouble(Console.ReadLine());

            double surfaceArea = 4 * Math.PI * Math.Pow(r, 2);

            double volume = (4.0 / 3.0) * Math.PI * Math.Pow(r, 3);

            Console.WriteLine($"Diện tích bề mặt hình cầu: {surfaceArea:F2}");
            Console.WriteLine($"Thể tích hình cầu: {volume:F2}");
        }
        /// <summary>
        /// Write a C# Sharp program that takes a character as input and checks if it 
        /// is a vowel, a digit, or any other symbol.
        /// </summary>
        static void Bai_5()
        {
            Console.Write("\nNhập vào một ký tự: ");
            char ch = Console.ReadKey().KeyChar;
            Console.WriteLine(); 

            if (char.IsDigit(ch))
            {
                Console.WriteLine($"'{ch}' là một chữ số.");
            }

            else if ("aeiouAEIOU".Contains(ch))
            {
                Console.WriteLine($"'{ch}' là một nguyên âm.");
            }

            else
            {
                Console.WriteLine($"'{ch}' là một ký tự khác.");
            }
        }

        public static void Main2(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Bai_1();
            Bai_2();
            Bai_3();
            Bai_4();
            Bai_5();

            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
