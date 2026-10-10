using System;
using System.Collections.Generic;
using System.Text;

namespace CSLT_INF509005_T2.session09
{
    internal class ExerciseFileBT8
    {
        static void SoLanXuatHien(string filePath)
        {
            string text = File.ReadAllText(filePath);
            int[,] stats = new int[256, 2];

            for (int i = 0; i < 256; i++)
                stats[i, 0] = i;

            foreach (char c in text)
            {
                if (char.IsLetterOrDigit(c) && (int)c < 256)
                {
                    stats[(int)c, 1]++;
                }
            }

            Console.WriteLine("Character Count");
            for (int i = 0; i < 256; i++)
            {
                if (stats[i, 1] > 0)
                    Console.WriteLine($"'{(char)stats[i, 0]}' : {stats[i, 1]}");
            }
        }

        static void PrintFolderStructure(DirectoryInfo dir, string indent)
        {
            foreach (FileInfo file in dir.GetFiles())
            {
                Console.WriteLine($"{indent} [FILE] {file.Name} ({file.Length} bytes)");
            }

            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                Console.WriteLine($"{indent} [DIR]  {subDir.Name}");
                PrintFolderStructure(subDir, indent + "    ");
            }
        }


        private static void Main(string[] args)
        {
            string dir = Path.Combine(Directory.GetCurrentDirectory(), "artifacts");
            Directory.CreateDirectory(dir);

            // 1.to create a blank file on the disk.
            string emptyPath = Path.Combine(dir, "empty.txt");
            File.Create(emptyPath).Close();
            Console.WriteLine("Đã tạo file trống tại: " + emptyPath);

            // 2.to remove a file from the disk.
            File.Delete(emptyPath);

            // 3.to create a file and add some text.
            string f = Path.Combine(dir, "excercise.txt");
            File.WriteAllText(f, "First Line" + Environment.NewLine);

            // 4.create a text file and read it.
            Console.WriteLine(File.ReadAllText(f));

            // 5.to create a file and write an array of strings to the file.

            string[] contentArr = { "Line 1", "Line 2", "Line 3", "Line 4", "Line 5", "Line 6" };
            File.WriteAllLines(f, contentArr);

            // 6.to append some text to an existing file.
            File.AppendAllText(f, "Line 7 (appended)");

            // 7.to create and copy the file to another name and display the content.
            string fCopy = Path.Combine(dir, "excercise_copy.txt");
            File.Copy(f, fCopy, true);

            Console.WriteLine("Copied content");
            Console.WriteLine(File.ReadAllText(fCopy));

            // 8.create a file and move it into the same directory with another name.
            string fRename = Path.Combine(dir, "excercise_renamed.txt");
            if (File.Exists(fRename)) File.Delete(fRename);
            File.Move(f, fRename);

            using (StreamReader sr = new StreamReader(fRename))
            {
                Console.WriteLine("First line in file: " + sr.ReadLine());
            }

            // 9.read the first line of a file.
            string firstLine = File.ReadLines(fRename).LastOrDefault();
            Console.WriteLine("Last line in file: " + firstLine);

            // 10.to create and read the last line of a file.
            string lastLine = File.ReadLines(fRename).LastOrDefault();
            Console.WriteLine("Last line in file: " + lastLine);

            // 11.create and read the last n lines of a file.
            int n = 2;
            Console.WriteLine($"Read {n} last lines");
            foreach (string r in File.ReadAllLines(fRename).TakeLast(n))
            {
                Console.WriteLine(r);
            }

            // 12.to read a specific line from a file.
            int h = 2;
            string lineH = File.ReadAllLines(fRename).Skip(h - 1).FirstOrDefault();
            Console.WriteLine($"Line {h} in the file: \n{lineH}");

            // 13.to count the number of lines in a file.
            int lineNum = File.ReadLines(fRename).Count();
            Console.WriteLine($"File {fRename} has {lineNum} lines");

            // 14.To print the structure of specific folder (include files)
            Console.WriteLine("\nFolder Structure");
            DirectoryInfo rootDir = new DirectoryInfo(dir);
            Console.WriteLine($"[DIR] {rootDir.Name}");
            PrintFolderStructure(rootDir, "  ");

            // 15.Read a text file, then calculate the statistics of the appearance of characters and numbers. 
            SoLanXuatHien(fRename);
        }
    }
}