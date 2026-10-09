using System;
using System.Collections.Generic;
using System.Text;

namespace CSLT_INF509005_T2.session08
{
    internal class ExerciseString
    {
        // -to find the length of a string without using a library function.
        static void PrintLength(string s)
        {
            int stringLength = s.Length;
            Console.WriteLine($"Length of the string '{s}' is {stringLength}");
        }

        // -to separate individual characters from a string.
        static string SeperateCharacters(string s)
        {
            char[] sepChar = s.ToCharArray();
            return new string("sepChar\t");

        }

        // -to print individual characters of the string in reverse order.
        static string ReverseSeperateCharacters(string s)
        {
            char[] charArr = s.ToCharArray();
            Array.Reverse(charArr);
            return new string("charArr\t");
        }

        // -to count the total number of words in a string.
        static int CountWord(string s)
        {
            string[] words = s.Split();
            return words.Length;
        }

        // -to compare two strings without using a string library functions.
        static bool CompareTwoStrings(string s, string newString)
        {
            return s == newString;
        }

        // -to count the number of alphabets, digits, and special characters in a string.
        static void CountingTypes(string s)
        {
            int alphaCount = 0;
            int digitCount = 0;
            int specialCount = 0;
            foreach (char c in s)
            {
                if (char.IsLetter(c)) alphaCount++;
                else if (char.IsDigit(c)) digitCount++;
                else specialCount++;
            }
            Console.WriteLine($"Alphabets = {alphaCount} | Digit = {digitCount} | Special Characters = {specialCount}");
        }

        // -to count the number of vowels or consonants in a string.
        static void CountingVowelConsonant(string s)
        {
            int vowelCount = 0;
            int consCount = 0;
            foreach (char c in s.ToLower())
            {
                if (char.IsLetter(c))
                {
                    if ("aeiou".IndexOf(s.ToLower()) >= 0) vowelCount++;
                    else consCount++;
                }
            }
            Console.WriteLine($"Vowels = {vowelCount} | Consonants = {consCount}");
        }

        // -to check whether a given substring is present in the given string.
        static bool IsPresentInString(string s, string substring)
        {
            if (s.IndexOf(substring) >= 0) return true;
            else return false;
        }

        // -to search for the position of a substring within a string.
        static int SearchPosition(string s, string substring)
        {
            return s.IndexOf(substring);
        }

        // -to check whether a character is an alphabet and not and if so, check for the case.
        static void CheckAlphabetCase(char c)
        {
            if (char.IsLetter(c))
            {
                if (char.IsUpper(c)) Console.WriteLine("Uppercase");
                else Console.WriteLine("Lowercase");
            }
            else Console.WriteLine("Not an alphabet");
        }

        // -to find the number of times a substring appears in a given string.
        static int CountSubstring(string s, string substring)
        {
            int count = 0;
            int index = 0;
            while ((index = s.IndexOf(substring, index)) >= 0)
            {
                count++;
                index += substring.Length;
            }
            return count;
        }

        // -to insert a substring before the first occurrence of a string.
        static string InsertSubstring(string s, string substring)
        {
            string insert = "beautiful ";

            int index = s.IndexOf(substring);

            if (index >= 0)
            {
                s = s.Insert(index, insert);
            }
            return s;
        }


        private static void Main6(string[] args)
        {
            // -to input a string and print it.
            Console.Write("Please input a string: "); string s = Console.ReadLine();
            Console.WriteLine(s);

            // -to find the length of a string without using a library function.
            PrintLength(s);

            // -to separate individual characters from a string.
            Console.WriteLine(SeperateCharacters(s));

            // -to print individual characters of the string in reverse order.
            Console.WriteLine(ReverseSeperateCharacters(s));

            // -to count the total number of words in a string.
            Console.WriteLine($"The total number of words in string '{s}' is {CountWord(s)}");

            // -to compare two strings without using a string library functions.
            Console.Write("Input new string: "); string newString = Console.ReadLine();
            if (CompareTwoStrings(s, newString)) Console.WriteLine("They are the same!");
            else Console.WriteLine("They are different!");

            // -to count the number of alphabets, digits, and special characters in a string.
            CountingTypes(s);

            // -to count the number of vowels or consonants in a string.
            CountingVowelConsonant(s);

            // -to check whether a given substring is present in the given string.
            Console.Write("Please input a substring: "); string substring = Console.ReadLine();
            if (IsPresentInString(s, substring)) Console.WriteLine($"Substring '{substring} is present in string '{s}");
            else Console.WriteLine($"Substring '{substring} is NOT present in string '{s}");

            // -to search for the position of a substring within a string.
            if (SearchPosition(s, substring) >= 0) Console.WriteLine($"Substring is found at index = {SearchPosition(s, substring)}");
            else Console.WriteLine("NOT FOUND!");

            // -to check whether a character is an alphabet and not and if so, check for the case.
            Console.Write("Enter a char you want to check: "); char c = char.Parse(Console.ReadLine());
            CheckAlphabetCase(c);

            // -to find the number of times a substring appears in a given string.
            Console.WriteLine($"Substring {substring} appears {CountSubstring(s, substring)} times");

            // -to insert a substring before the first occurrence of a string.
            Console.WriteLine($"Insert 'beautiful' in string '{s}' before the first occurrence of '{substring}");
            Console.WriteLine($"Result: {InsertSubstring(s, substring)}");
        }
    }
}

