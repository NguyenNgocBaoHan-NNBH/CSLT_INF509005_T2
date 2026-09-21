using System;
using System.Collections.Generic;
using System.Text;

namespace CSLT_INF509005_T2.session06
{
    internal class ExercisesFunctions
    {
        // Bài 1: Tinh tong hai so
        static int TinhTong(int a, int b)
        {
            return a + b;
        }

        // Bài 2: Kiem tra chan le
        static bool KiemTraChan(int n)
        {
            return n % 2 == 0;
        }

        // Bài 3: Tim so lon nhat trong ba so
        static int TimMax(int a, int b, int c)
        {
            return Math.Max(Math.Max(a, b), c);
        }

        // Bài 4: Tinh giai thua
        static long TinhGiaiThua(int n)
        {
            long kq = 1;
            for (int i = 1; i <= n; i++) kq *= i;
            return kq;
        }

        // Bài 5: Dao nguoc chuoi
        static string DaoNguocChuoi(string input)
        {
            char[] arr = input.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        // Bài 6: Kiem tra so nguyen to
        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // Bài 7: In day Fibonacci
        static void InFibonacci(int n)
        {
            int t1 = 0, t2 = 1;
            for (int i = 1; i <= n; i++)
            {
                Console.Write(t1 + " ");
                int next = t1 + t2;
                t1 = t2;
                t2 = next;
            }
            Console.WriteLine();
        }

        // Bài 8: Dem so luong nguyen am
        static int DemNguyenAm(string s)
        {
            int dem = 0;
            string na = "aeiouAEIOU";
            foreach (char c in s) if (na.Contains(c)) dem++;
            return dem;
        }

        // Bài 9: Tinh luy thua x^y
        static double TinhLuyThua(double x, int y)
        {
            double kq = 1.0;
            for (int i = 0; i < Math.Abs(y); i++) kq *= x;
            return y < 0 ? 1.0 / kq : kq;
        }

        // Bài 10: Tinh trung binh mang
        static double TinhTrungBinh(int[] arr)
        {
            int tong = 0;
            foreach (int x in arr) tong += x;
            return (double)tong / arr.Length;
        }

        // Bài 11: Kiem tra chuoi doi xung
        static bool KiemTraDoiXung(string s)
        {
            int dau = 0, cuoi = s.Length - 1;
            while (dau < cuoi)
            {
                if (s[dau] != s[cuoi]) return false;
                dau++; cuoi--;
            }
            return true;
        }

        // Bài 12: Celsius sang Fahrenheit
        static double CelsiusToFahrenheit(double c)
        {
            return (c * 9 / 5) + 32;
        }

        // Bài 13: Tim gia tri nho nhat mang
        static int TimMin(int[] arr)
        {
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++) if (arr[i] < min) min = arr[i];
            return min;
        }

        // Bài 14: Tong cac chu so
        static int TongCacChuSo(int n)
        {
            int tong = 0;
            n = Math.Abs(n);
            while (n > 0) { tong += n % 10; n /= 10; }
            return tong;
        }

        // Bài 15: Sap xep mang tang dan
        static void SapXepMang(int[] arr)
        {
            Array.Sort(arr);
            foreach (int x in arr) Console.Write(x + " ");
            Console.WriteLine();
        }

        // Bài 16: Xoa ky tu trung lap
        static string XoaTrungLap(string s)
        {
            string kq = "";
            foreach (char c in s) if (!kq.Contains(c)) kq += c;
            return kq;
        }

        // Bài 17: UCLN
        static int UCLN(int a, int b)
        {
            while (b != 0) { int r = a % b; a = b; b = r; }
            return a;
        }

        // Bài 18: Thap phan sang nhi phan
        static string DecimalToBinary(int n)
        {
            if (n == 0) return "0";
            string bn = "";
            while (n > 0) { bn = (n % 2) + bn; n /= 2; }
            return bn;
        }

        // Bài 19: Kiem tra nam nhuan
        static bool KiemTraNamNhuan(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        // Bài 20: Dem so tu trong cau
        static int DemSoTu(string sentence)
        {
            string[] tu = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return tu.Length;
        }

        public static void Main(string[] args)
        {
            // BÀI 1: Tinh tong hai so
            Console.Write("Nhap so thu nhat: ");
            int x1 = int.Parse(Console.ReadLine());
            Console.Write("Nhap so thu hai: ");
            int y1 = int.Parse(Console.ReadLine());
            Console.WriteLine($"Tong hai so la: {TinhTong(x1, y1)}");

            // BÀI 2: Kiem tra chan le
            Console.Write("\nNhap so can kiem tra chan le: ");
            int n2 = int.Parse(Console.ReadLine());
            if (KiemTraChan(n2))
                Console.WriteLine($"{n2} la so chan");
            else
                Console.WriteLine($"{n2} la so le");

            // BÀI 3: Tim so lon nhat trong ba so
            Console.Write("\nNhap so thu nhat: ");
            int a3 = int.Parse(Console.ReadLine());
            Console.Write("Nhap so thu hai: ");
            int b3 = int.Parse(Console.ReadLine());
            Console.Write("Nhap so thu ba: ");
            int c3 = int.Parse(Console.ReadLine());
            Console.WriteLine($"So lon nhat la: {TimMax(a3, b3, c3)}");

            // BÀI 4: Tinh giai thua
            Console.Write("\nNhap so can tinh giai thua: ");
            int n4 = int.Parse(Console.ReadLine());
            Console.WriteLine($"{n4}! = {TinhGiaiThua(n4)}");

            // BÀI 5: Dao nguoc chuoi
            Console.Write("\nNhap chuoi can dao nguoc: ");
            string chuoi5 = Console.ReadLine();
            Console.WriteLine($"Chuoi sau khi dao: {DaoNguocChuoi(chuoi5)}");

            // BÀI 6: Kiem tra so nguyen to 
            Console.Write("\nNhap so can kiem tra nguyen to: ");
            int so6 = int.Parse(Console.ReadLine());
            if (IsPrime(so6))
                Console.WriteLine($"{so6} la so nguyen to");
            else
                Console.WriteLine($"{so6} KHONG la so nguyen to");

            // BÀI 7: In day Fibonacci
            Console.Write("\nNhap so luong phan tu Fibonacci: ");
            int n7 = int.Parse(Console.ReadLine());
            Console.Write("Day Fibonacci: ");
            InFibonacci(n7);

            // BÀI 8: Dem so luong nguyen am
            Console.Write("\nNhap chuoi can dem nguyen am: ");
            string chuoi8 = Console.ReadLine();
            Console.WriteLine($"So luong nguyen am: {DemNguyenAm(chuoi8)}");

            // BÀI 9: Tinh luy thua x^y
            Console.Write("\nNhap x: ");
            double x9 = double.Parse(Console.ReadLine());
            Console.Write("Nhap so mu y: ");
            int y9 = int.Parse(Console.ReadLine());
            Console.WriteLine($"Ket qua {x9}^{y9} = {TinhLuyThua(x9, y9)}");

            // BÀI 10: Tinh trung binh mang
            Console.Write("\nNhap so luong phan tu cua mang: ");
            int size10 = int.Parse(Console.ReadLine());
            int[] mang10 = new int[size10];
            for (int i = 0; i < size10; i++)
            {
                Console.Write($"Nhap phan tu arr[{i}]: ");
                mang10[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Trung binh mang la: {TinhTrungBinh(mang10)}");

            // BÀI 11: Kiem tra chuoi đối xứng
            Console.Write("\nNhap chuoi can kiem tra doi xung: ");
            string chuoi11 = Console.ReadLine();
            if (KiemTraDoiXung(chuoi11))
                Console.WriteLine("Chuoi doi xung");
            else
                Console.WriteLine("Chuoi KHONG doi xung");

            // BÀI 12: Chuyen doi nhiet do C sang F
            Console.Write("\nNhap do C: ");
            double doC = double.Parse(Console.ReadLine());
            Console.WriteLine($"{doC} do C = {CelsiusToFahrenheit(doC)} do F");

            // BÀI 13: Tim gia tri nho nhat mang
            Console.Write("\nNhap so luong phan tu cua mang: ");
            int size13 = int.Parse(Console.ReadLine());
            int[] mang13 = new int[size13];
            for (int i = 0; i < size13; i++)
            {
                Console.Write($"Nhap phan tu arr[{i}]: ");
                mang13[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Gia tri nho nhat mang la: {TimMin(mang13)}");

            // BÀI 14: Tong cac chu so của một số
            Console.Write("\nNhap so nguyen: ");
            int so14 = int.Parse(Console.ReadLine());
            Console.WriteLine($"Tong cac chu so la: {TongCacChuSo(so14)}");

            // BÀI 15: Sap xep mang tang dan
            Console.Write("\nNhap so luong phan tu cua mang: ");
            int size15 = int.Parse(Console.ReadLine());
            int[] mang15 = new int[size15];
            for (int i = 0; i < size15; i++)
            {
                Console.Write($"Nhap phan tu arr[{i}]: ");
                mang15[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("Mang sau khi sap xep: ");
            SapXepMang(mang15);

            // BÀI 16: Xoa ky tu trung lap
            Console.Write("\nNhap chuoi: ");
            string chuoi16 = Console.ReadLine();
            Console.WriteLine($"Chuoi sau khi loc: {XoaTrungLap(chuoi16)}");

            // BÀI 17: UCLN
            Console.Write("\nNhap so a: ");
            int a17 = int.Parse(Console.ReadLine());
            Console.Write("Nhap so b: ");
            int b17 = int.Parse(Console.ReadLine());
            Console.WriteLine($"UCLN cua {a17} va {b17} la: {UCLN(a17, b17)}");

            // BÀI 18: Thap phan sang nhi phan
            Console.Write("\nNhap so thap phan: ");
            int so18 = int.Parse(Console.ReadLine());
            Console.WriteLine($"He nhi phan la: {DecimalToBinary(so18)}");

            // BÀI 19: Kiem tra nam nhuan
            Console.Write("\nNhap nam can kiem tra: ");
            int nam19 = int.Parse(Console.ReadLine());
            if (KiemTraNamNhuan(nam19))
                Console.WriteLine($"{nam19} la nam nhuan");
            else
                Console.WriteLine($"{nam19} KHONG la nam nhuan");

            // BÀI 20: Dem so tu trong cau
            Console.Write("\nNhap vao mot cau: ");
            string cau20 = Console.ReadLine();
            Console.WriteLine($"So luong tu trong cau la: {DemSoTu(cau20)}");

            Console.ReadLine();
        }
    }
}