using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace CSLT_INF509005_T2.ĐẠI
{
    internal class FileName
    {
        enum CustomerType
        {
            Child,
            Student,
            Adult,
            Senior
        }

        static void Main3(string[] args)
        {

            decimal basePrice = 100000m;
            decimal discount = 0m;
            decimal surcharge = 0m;
            string discountLabel = "Khoản giảm giá"; // Nhãn mặc định để in ra

            // 2. Nhập thông tin chính xác theo định dạng mẫu Input
            Console.Write("Khách hàng: ");
            string customerInput = Console.ReadLine(); // Ví dụ nhập: Student
                                                       // Chuyển đổi từ chuỗi sang Enum (bỏ qua hoa thường)
            CustomerType customer = (CustomerType)Enum.Parse(typeof(CustomerType), customerInput, true);

            // TỐI ƯU: Chỉ hỏi thẻ SV nếu khách hàng nhập vào là Student
            bool hasStudentCard = false;
            if (customer == CustomerType.Student)
            {
                Console.Write("Thẻ SV hợp lệ: ");
                hasStudentCard = bool.Parse(Console.ReadLine());
            }

            Console.Write("Ngày xem: ");
            string dayInput = Console.ReadLine();
            DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayInput, true);

            // --- Logic tính toán giữ nguyên theo đề bài ---
            if (customer == CustomerType.Child || customer == CustomerType.Senior)
            {
                discount = basePrice * 0.50m;
                discountLabel = "Giảm giá (50%)";
            }
            else if (customer == CustomerType.Student && hasStudentCard &&
                     (day >= DayOfWeek.Monday && day <= DayOfWeek.Thursday))
            {
                discount = basePrice * 0.30m;
                discountLabel = "Giảm giá SV (30%)";
            }
            else if (customer == CustomerType.Adult && day == DayOfWeek.Wednesday)
            {
                discount = basePrice * 0.20m;
                discountLabel = "Giảm giá Thứ 4 Vui Vẻ (20%)";
            }

            if (day == DayOfWeek.Friday || day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
            {
                surcharge = 20000m;
            }

            decimal totalTicketPrice = basePrice - discount + surcharge;

            Console.WriteLine($"\nGiá vé gốc: {basePrice:N0} VNĐ");
            Console.WriteLine($"{discountLabel}: -{discount:N0} VNĐ");
            Console.WriteLine($"Phụ thu cuối tuần: {surcharge:N0} VNĐ");
            Console.WriteLine($"TỔNG TIỀN VÉ: {totalTicketPrice:N0} VNĐ");
        }
    }
}