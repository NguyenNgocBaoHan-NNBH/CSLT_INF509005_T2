using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Principal;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1.session02
{
    internal class Exercises_1
    {
        public static void Main11(string[] args)
        {
            int number1 = 10, number2 = 12;

            //1.to Add / Sum Two Numbers.
            int sum = number1 + number2;
            Console.WriteLine($"{ number1} + { number2} = {sum}");

            Console.WriteLine(); 

            //2.to Swap Values of Two Variables.
            Console.WriteLine($"Before swap number 1 = {number1}, number 2 = {number2}");
            int temp = number1;
            number1 = number2;
            number2 = temp;
            Console.WriteLine( $"After swap number 1 = {number1}, number 2 = {number2}");

            Console.WriteLine();

            //3.to Multiply two Floating Point Numbers
            float f1 = 3.5f, f2 = 2.7f;
            float f3 = f1 * f2;
            Console.WriteLine( $"(f1) * (f2) = {f3}");

            Console.WriteLine();

            //4.to convert feet to meter
            float feet = 5.7f;
            const float rate = 0.3048f;
            float metter = rate * feet;
            Console.WriteLine( $"{feet}feet = {metter} metter.");

            Console.WriteLine();

            //5.to convert Celsius to Fahrenheit and vice versa
            float cels = 27f;
            float fah = cels * 1.8f + 32;
            Console.WriteLine( $"{cels}°C = {fah}°F");

            Console.WriteLine();

            //6.to find the Size of data types
            Console.WriteLine( $"Size of double data type is {sizeof(double)}");
            Console.WriteLine($"Size of int data type is {sizeof(int)}");

            Console.WriteLine();

            //7.to Print ASCII Value(tip: read character, print number of this char)
            Console.Write("Enter a character: ");
            int c = Console.Read();
            Console.ReadLine();
            Console.WriteLine($"ASCII code of {(char)c} is {c}");

            Console.WriteLine();

            //8.to Calculate Area of Circle
            Console.Write("Enter radius: ");
            double r = Convert.ToDouble(Console.ReadLine());
            double circleArea = 3.14 * r * r;
            Console.WriteLine($"Area of Circle is {circleArea}");

            Console.WriteLine();

            //9.to Calculate Area of Square
            Console.Write("Enter side of square: ");
            double side = Convert.ToDouble(Console.ReadLine());
            double squareArea = side * side;
            Console.WriteLine($"Area of Square is: {squareArea}");

            Console.WriteLine();

            //10.to convert days to years, weeks and days
            Console.Write("Enter total days: ");
            int totalDays = Convert.ToInt32(Console.ReadLine());
            int years = totalDays / 365;
            int weeks = (totalDays % 365) / 7;
            int days = (totalDays % 365) % 7;
            Console.WriteLine($"{totalDays} days = {years} years, {weeks} weeks, {days} days");

            Console.WriteLine(); 

            Console.WriteLine( "Press any key to continue...");
            Console.ReadKey();
        }
    }
}
