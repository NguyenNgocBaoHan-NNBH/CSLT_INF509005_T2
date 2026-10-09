using System;
using System.Collections.Generic;
using System.Text;

namespace CSLT_INF509005_T2.session09
{
    internal class ExerciseFileBT8
    {
        public static class FileService
        {
            // 1.to create a blank file on the disk.
            public static void CreateBlankFile(string filePath)
            {
                File.Create(filePath).Close();
            }

            // 2.to remove a file from the disk.
            public static bool RemoveAFile(string filePath)
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }
                return false;
            }

            // 3.to create a file and add some text.
            public static void AddText(string filePath, string noiDung)
            {
                File.WriteAllText(filePath, noiDung);
            }

            // 4.create a text file and read it.
            public static string ReadAllFile(string filePath)
            {
                return File.ReadAllText(filePath);
            }

            // 5.to create a file and write an array of strings to the file.
            public static void WriteArrayOfStrings(string filePath, string[] lines)
            {
                File.WriteAllLines(filePath, lines);
            }

            // 6.to append some text to an existing file.
            public static void AppendSomeText(string filePath, string noiDung)
            {
                File.AppendAllText(filePath, noiDung);
            }

            // 7.to create and copy the file to another name and display the content.
            public static void CopyFile(string nguon, string dich)
            {
                File.Copy(nguon, dich, true);
            }

            // 8.create a file and move it into the same directory with another name.
            public static void RenameOrMoveFile(string nguon, string dich)
            {
                if (File.Exists(dich))
                {
                    File.Delete(dich);
                }
                File.Move(nguon, dich);
            }

            // 9.read the first line of a file.
            public static string ReadTheFirstLine(string filePath)
            {
                return File.ReadLines(filePath).First();
            }

            // 10.to create and read the last line of a file.
            public static string ReadTheLastLine(string filePath)
            {
                return File.ReadLines(filePath).Last();
            }

            // 11.create and read the last n lines of a file.
            public static IEnumerable<string> ReadTheLastNLines(string filePath, int n)
            {
                return File.ReadLines(filePath)
                             .Reverse()
                             .Take(n)
                             .Reverse();
            }

            // 12.to read a specific line from a file.
            public static string ReadASpecificLine(string filePath, int viTriDong)
            {
                return File.ReadLines(filePath).Skip(viTriDong - 1).First();
            }

            // 13.to count the number of lines in a file.
            public static int CountLinesInFile(string filePath)
            {
                return File.ReadAllLines(filePath).Length;
            }

            // 14.To print the structure of specific folder (include files)
            public static IEnumerable<string> LayDanhSachTenFile(string folderPath)
            {
                return Directory.GetFiles(folderPath).Select(f => Path.GetFileName(f));
            }

            // 15.Read a text file, then calculate the statistics of the appearance of characters and numbers.
            public static IOrderedEnumerable<KeyValuePair<char, int>> StatisticsOfCharactersAndNumbers(string filePath)
            {
                string text = File.ReadAllText(filePath);
                return text.Where(c => char.IsLetterOrDigit(c))
                           .GroupBy(c => c)
                           .ToDictionary(g => g.Key, g => g.Count())
                           .OrderBy(k => k.Key);
            }

            static void Main()
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.InputEncoding = System.Text.Encoding.UTF8;

                string file1 = "BaoCao.txt";
                string file2 = "BaoCao_Copy.txt";
                string file3 = "BaoCao_DoiTen.txt";

                // 1.to create a blank file on the disk.
                FileService.CreateBlankFile("Rong.txt");
                Console.WriteLine("1: Đã tạo tệp Rong.txt (file trống)");

                // 2.to remove a file from the disk.
                bool daXoa = FileService.RemoveAFile("Rong.txt");
                if (daXoa)
                    Console.WriteLine("2: Đã xóa tệp Rong.txt");
                else
                    Console.WriteLine("2: Tệp Rong.txt không tồn tại để xóa");

                // 3.to create a file and add some text.
                string noiDungDoanhThu = "BÁO CÁO DOANH THU 2025\n" +
                                         "-------------------------\n" +
                                         "Quý 1: 120 tỷ VND\n" +
                                         "Quý 2: 150 tỷ VND\n";
                FileService.AddText(file1, noiDungDoanhThu);
                Console.WriteLine("3: Đã tạo và ghi nội dung vào " + file1);

                // 4.create a text file and read it.
                FileService.AddText("ReadMe.txt", "Xin chào!\nĐây là file ReadMe.");
                Console.WriteLine("4: Nội dung ReadMe.txt:");
                Console.WriteLine(FileService.ReadAllFile("ReadMe.txt"));

                // 5.to create a file and write an array of strings to the file.
                string[] lines = { "Dòng 1", "Dòng 2", "Dòng 3" };
                FileService.WriteArrayOfStrings("ArrayLines.txt", lines);
                Console.WriteLine("\n5: Đã ghi mảng chuỗi vào ArrayLines.txt");

                // 6.to append some text to an existing file.
                FileService.AppendSomeText(file1, "Quý 3: 200 tỷ VND\n");
                Console.WriteLine("6: Đã thêm văn bản vào " + file1);

                // 7.to create and copy the file to another name and display the content.
                FileService.CopyFile(file1, file2);
                Console.WriteLine("7: Đã sao chép " + file1 + " sang " + file2);
                Console.WriteLine("Nội dung " + file2 + ":");
                Console.WriteLine(FileService.ReadAllFile(file2));

                // 8.create a file and move it into the same directory with another name.
                FileService.AddText("MoveMe.txt", "Tệp sẽ được đổi tên.");
                FileService.RenameOrMoveFile("MoveMe.txt", file3);
                Console.WriteLine("8: Đã di chuyển MoveMe.txt -> " + file3);

                // 9.read the first line of a file.
                Console.WriteLine("9: Dòng đầu tiên của " + file1 + ": " + FileService.ReadTheFirstLine(file1));

                // 10.to create and read the last line of a file.
                FileService.WriteArrayOfStrings("LastLine.txt", new string[] { "dong 1", "dong 2", "dong 3" });
                Console.WriteLine("10: Dòng cuối cùng của LastLine.txt: " + FileService.ReadTheLastLine("LastLine.txt"));

                // 11.create and read the last n lines of a file.
                FileService.WriteArrayOfStrings("LastN.txt", new string[] { "dong 1", "dong 2", "dong 3", "dong 4" });
                int n = 2;
                Console.WriteLine("11: " + n + " dòng cuối cùng của LastN.txt:");
                foreach (var line in FileService.ReadTheLastNLines("LastN.txt", n))
                {
                    Console.WriteLine(line);
                }

                // 12.to read a specific line from a file.
                int k = 2;
                Console.WriteLine("\n12: Dòng thứ " + k + " của " + file1 + ": " + FileService.ReadASpecificLine(file1, k));

                // 13.to count the number of lines in a file.
                int count = FileService.CountLinesInFile(file1);
                Console.WriteLine("13: Số dòng trong " + file1 + " = " + count);

                // 14.To print the structure of specific folder (include files)
                string path = Directory.GetCurrentDirectory();
                Console.WriteLine("14: Cấu trúc thư mục " + path + ":");
                foreach (string tenFile in FileService.LayDanhSachTenFile(path))
                {
                    Console.WriteLine(" - " + tenFile);
                }

                // 15.Read a text file, then calculate the statistics of the appearance of characters and numbers.
                var thongke = FileService.StatisticsOfCharactersAndNumbers(file1);
                Console.WriteLine("\n15: Thống kê ký tự và số trong " + file1 + ":");
                foreach (var kv in thongke)
                {
                    Console.WriteLine("'" + kv.Key + "': " + kv.Value);
                }
            }
        }
    }
}
