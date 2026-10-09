using System;
using System.Collections.Generic;
using System.Text;

namespace CSLT_INF509005_T2.session07
{
    internal class InClass
    {
        static int[] InitializingRandomArray(int[] arr, int n)
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                arr[i] = rnd.Next(1, 101);
            }
            return arr;
        }

        static void PrintArray(int[] arr)
        {
            Console.Write($"Output array: ");
            foreach (int v in arr)
            {
                Console.Write($"{v} ");
            }
            Console.WriteLine("\n");
        }

        /// <summary>
        /// 1. to calculate the average value of array elements.
        /// </summary>
        static float CalcAvg(int[] arr)
        {
            int sum = 0;
            foreach (int v in arr)
            {
                sum += v;
            }
            return (float)sum / arr.Length;
        }

        /// <summary>
        /// 2. to test if an array contains a specific value.
        /// </summary>
        /// <param name="args"></param>
        static bool ContainSpecificValue(int[] arr, int val)
        {
            foreach (int v in arr)
            {
                if (v == val)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 3. to find the index of an array element.
        /// </summary>
        /// <param name="args"></param>
        static int FindingIndex(int[] arr, int n, int val)
        {
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == val)
                    return i;
            }
            return -1;

        }

        private static void Main55(string[] args)
        {
            //Console.Write("Input number of elements: "); int n = int.Parse(Console.ReadLine());
            //int[] arr = new int[n];
            //InitializingRandomArray(arr, n);
            //PrintArray(arr);

            //Bai 1
            //float avg = CalcAvg(arr);
            //Console.WriteLine($"The average of the above array is {avg:F2}");

            //Bai 2
            //Console.Write("Input a number you want to check!: "); int val = int.Parse(Console.ReadLine());
            //bool cond = ContainSpecificValue(arr, val);
            //if (cond) Console.WriteLine($"The array contains value {val}!!");
            //else Console.WriteLine($"Sorry...The array does not contain value {val}");

            //Bai 3
            //Console.Write("Input the number you want to find: "); int val = int.Parse(Console.ReadLine());
            //int idx = FindingIndex(arr, n, val);
            //if (idx != -1)
            //    Console.WriteLine($"The index of {val} in the array is {idx}");
            //else Console.WriteLine($"Cannot find the number {val} in the array");

            int k = 1;
            for (int i = 1; i <= 4; i++)
            {
                Console.Write(new string(' ', 4 - i));
                for (int j = 1; j <= i; j++)
                    Console.Write(k++ + " ");
                Console.WriteLine();
            }
        }
    }
}

