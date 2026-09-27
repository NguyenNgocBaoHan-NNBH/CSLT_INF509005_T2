using System;
using System.Collections.Generic;
using System.Text;

namespace CSLT_INF509005_T2.session07
{
    internal class Exercises
    {
        /// <summary>
        /// Create a random integer values array, then create functions that:
        /// </summary>
        static int[] InitializingRandomArrray(int[] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 101);
            }
            return arr;
        }
        static void PrintArray(int[] arr)
        {
            foreach (int v in arr)
            {
                Console.Write($"{v}\t");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// 1.to calculate the average value of array elements.
        /// </summary>
        static float CalculateAverage(int[] arr)
        {
            int sum = 0;
            foreach (int v in arr)
            {
                sum += v;
            }
            return (float)sum / arr.Length;
        }
        /// <summary>
        /// 2.to test if an array contains a specific value.
        /// </summary>
        static bool ContainsValue(int[] arr, int n)
        {
            foreach (int v in arr)
            {
                if (v == n) return true;
            }
            return false;
        }

        /// 3.to find the index of an array element.
        static int FindingIndex(int[] arr, int n)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == n) return i;
            }
            return -1;
        }

        // 4.to remove a specific element from an array.
        static int[] RemoveArrayElement(int[] arr, int n)
        {

            int index = FindingIndex(arr, n);
            if (index == -1)
            {
                Console.WriteLine("The array DOES NOT contain the value");
                return arr;
            }

            else
            {
                int[] newArr = new int[arr.Length - 1];
                for (int i = 0; i < index; i++)
                {
                    newArr[i] = arr[i];
                }
                for (int i = index; i < newArr.Length; i++)
                {
                    newArr[i] = arr[i + 1];
                }
                return newArr;
            }
        }

        /// <summary>
        /// 5.to find the maximum and minimum value of an array.
        /// </summary>
        static int[] FindingMaxMin(int[] arr)
        {
            int max = arr[0];
            int min = arr[0];
            foreach (int v in arr)
            {
                if (max < v) max = v;
                if (min > v) min = v;
            }
            return new int[] { max, min };
        }

        /// <summary>
        /// 6.to reverse an array of integer values.
        /// </summary>
        static void ReverseArray(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left < right)
            {
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
                left++;
                right--;
            }
        }

        /// <summary>
        /// 7.to find duplicate values in an array of values.
        /// </summary>
        static void FindDuplicateValues(int[] arr)
        {
            bool hasDuplicate = false;
            Console.Write("Duplicate values: ");

            for (int i = 0; i < arr.Length; i++)
            {
                bool alreadyChecked = false;
                for (int k = 0; k < i; k++)
                {
                    if (arr[k] == arr[i])
                    {
                        alreadyChecked = true;
                        break;
                    }
                }
                if (alreadyChecked == true) continue;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        hasDuplicate = true;
                        Console.Write($"{arr[i]}\t");
                        break;
                    }
                }
            }
            if (!hasDuplicate) Console.WriteLine("None");
            Console.WriteLine();
        }

        /// <summary>
        /// 8.to remove duplicate elements from an array.
        /// </summary>
        static int[] RemoveDuplicates(int[] arr)
        {
            int[] result = new int[arr.Length];
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                bool alreadyExists = false;
                for (int j = 0; j < count; j++)
                {
                    if (result[j] == arr[i])
                    {
                        alreadyExists = true;
                        break;
                    }
                }
                if (!alreadyExists)
                {
                    result[count] = arr[i];
                    count++;
                }
            }
            int[] finalResult = new int[count];
            for (int i = 0; i < count; i++)
            {
                finalResult[i] = result[i];
            }
            return finalResult;

        }
        ///<summary>
        /// Create a C# program that
        /// </summary>
        
        /// <summary>
        /// requests 10 integers from the user
        /// </summary>
        static void InputArrayWith10Elements(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Enter a number: "); arr[i] = int.Parse(Console.ReadLine());
            }
        }
        /// <summary>
        /// implementing the bubble sort algorithm.
        /// </summary>
        static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool swapped = false;
                for (int b = 0; b < arr.Length - 1 - i; b++)
                {
                    if (arr[b] > arr[b + 1])
                    {
                        int temp = arr[b];
                        arr[b] = arr[b + 1];
                        arr[b + 1] = temp;
                        swapped = true;
                    }
                }
                if (swapped == false) break;
            }
        }

        static int LinearSearch(string sentence, string word)
        {
            string[] words = sentence.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].ToLower() == word.ToLower()) return i;
            }
            return -1;
        }

        /// <summary>
        /// Create a program with following functions
        /// </summary>

        /// <summary>
        /// -Create an integer matrix N x M (N,M was prompted from user) randomly.
        /// </summary> 
        static void InitializingRandomMatrix(int[,] X)
        {
            Random rnd = new Random();
            for (int i = 0; i < X.GetLength(0); i++)
            {
                for (int j = 0; j < X.GetLength(1); j++)
                {
                    X[i, j] = rnd.Next(1, 101);
                }
            }
        }
        /// <summary>
        /// -Print the matrix.
        /// </summary>
        static void PrintMatrix(int[,] X)
        {
            for (int i = 0; i < X.GetLength(0); i++)
            {
                for (int j = 0; j < X.GetLength(1); j++)
                {
                    Console.Write($"{X[i, j]}\t");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// -Print the ith row/column. (i was prompted from user)
        /// </summary>
        static void PrintRow(int[,] X, int rowIndex)
        {
            int rows = X.GetLength(0);
            int cols = X.GetLength(1);

            if (rowIndex < 0 || rowIndex >= rows)
            {
                Console.WriteLine("Row Index is not valid");
                return;
            }
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{X[rowIndex, j]}\t");
            }
            Console.WriteLine();
        }

        static void PrintCol(int[,] X, int colIndex)
        {
            int rows = X.GetLength(0);
            int cols = X.GetLength(1);

            if (colIndex < 0 || colIndex >= cols)
            {
                Console.WriteLine("Col Index is not valid");
                return;
            }
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"{X[i, colIndex]}\t");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// -Find the max value of the matrix.
        /// </summary>
        static int FindMax(int[,] X)
        {
            int max = X[0, 0];
            for (int i = 0; i < X.GetLength(0); i++)
            {
                for (int j = 0; j < X.GetLength(1); j++)
                {
                    if (max < X[i, j]) max = X[i, j];
                }
            }
            return max;
        }

        /// <summary>
        /// -Find the min value of ith row of the matrix.
        /// </summary>
        static int FindMinOfRow(int[,] X, int rowIndex)
        {
            int cols = X.GetLength(1);
            int min = X[rowIndex, 0];

            for (int j = 1; j < cols; j++)
            {
                if (min > X[rowIndex, j]) min = X[rowIndex, j];
            }
            return min;
        }

        /// <summary>
        /// -Find the min value of ith col of the matrix.
        /// </summary>
        static int FindMinOfCol(int[,] X, int colIndex)
        {
            int rows = X.GetLength(0);
            int min = X[0, colIndex];

            for (int i = 1; i < rows; i++)
            {
                if (min > X[i, colIndex]) min = X[i, colIndex];
            }
            return min;
        }

        /// <summary>
        /// -Transpose the matrix.
        /// </summary>
        static int[,] TransposeMatrix(int[,] X)
        {
            int rows = X.GetLength(0);
            int cols = X.GetLength(1);
            int[,] transpose = new int[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    transpose[j, i] = X[i, j];
                }

            }
            return transpose;
        }

        /// <summary>
        /// -Print the main/secondary diagonal values of the matrix.(square maxtrix)
        /// </summary>
        static void PrintDiagonals(int[,] X)
        {
            int rows = X.GetLength(0);
            int cols = X.GetLength(1);

            if (rows != cols)
            {
                Console.WriteLine("The matrix must be a square matrix");
                return;
            }

            Console.WriteLine("The main diagonal of the matrix X is:");
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"{X[i, i]}\t");
            }
            Console.WriteLine("The secondary diagonal of the matrix X is:");
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"{X[i, rows - 1 - i]}\t");
            }

        }


        private static void Main(string[] args)
        {
            // Console.Write("Nhap so luong phan tu: "); int n = int.Parse(Console.ReadLine());
            // int[] arr = new int[n];
            // InitializingRandomArrray(arr);
            // PrintArray(arr);

            // Console.WriteLine($"The average of the array is {CalculateAverage(arr)}");

            // Console.Write("Enter a value you want to check: "); int val = int.Parse(Console.ReadLine());
            // if (ContainsValue(arr, val)) Console.WriteLine($"The array contains the value {val}");
            // else Console.WriteLine($"The array DOES NOT contain the value {val}");

            // Console.Write("Enter a value you want to find index: "); int val = int.Parse(Console.ReadLine());
            // if (FindingIndex(arr, val) == -1) Console.WriteLine($"The array DOES NOT contains the value {val}");
            // else Console.WriteLine($"The index of value {val} in the array is index = {FindingIndex(arr, val)}");

            // Console.Write("Enter a value you want to remove: "); int val = int.Parse(Console.ReadLine());
            // int[] arr = RemoveArrayElement(arr, val);
            // PrintArray(arr);

            // ReverseArray(arr);
            // PrintArray(arr);

            // FindDuplicateValues(arr);

            // Console.WriteLine("Duplicates values have been removed!");
            // PrintArray(RemoveDuplicates(arr));

            // int[] arr = new int[10];
            // InputArrayWith10Elements(arr);
            // Console.WriteLine("Before sorting:");

            // BubbleSort(arr);
            // Console.WriteLine("After sorting:");
            // PrintArray(arr);

            // Console.Write("Enter a sentence: "); string sentence = Console.ReadLine();
            // Console.Write("Enter a word: "); string word = Console.ReadLine();

            // if (LinearSearch(sentence, word) == -1) Console.WriteLine($"The word '{word}' is not in the sentence");
            // else Console.WriteLine($"The word '{word}' is found at the {LinearSearch(sentence, word)+1}th word");

            //Console.Write("Enter row num: "); int row = int.Parse(Console.ReadLine());
            //Console.Write("enter col num: "); int col = int.Parse(Console.ReadLine());
            //int[,] matrix = new int[row, col];

            //InitializingRandomMatrix(matrix);
            //PrintMatrix(matrix);
            //Console.WriteLine();

            //Console.Write("Enter ith row: "); int rowIndex = int.Parse(Console.ReadLine());
            //PrintRow(matrix, rowIndex);
            //Console.WriteLine($"Min of {rowIndex}th row is {FindMinOfRow(matrix, rowIndex)}");
            //Console.WriteLine();

            //Console.Write("Enter jth col: "); int colIndex = int.Parse(Console.ReadLine());
            //PrintCol(matrix, colIndex);
            //Console.WriteLine($"Min of {colIndex}th col is {FindMinOfCol(matrix, colIndex)}");
            //Console.WriteLine();

            //Console.WriteLine($"Max of matrix X is {FindMax(matrix)}");
            //Console.WriteLine();

            //Console.WriteLine("Transposed matrix:");
            //int[,] transpose = TransposeMatrix(matrix);
            //PrintMatrix(transpose);
            //Console.WriteLine();

            //PrintDiagonals(matrix);
        }
    }
}