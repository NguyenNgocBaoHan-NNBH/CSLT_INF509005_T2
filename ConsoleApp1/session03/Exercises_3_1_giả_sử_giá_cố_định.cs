using System;
using System.Collections.Generic;
using System.Text;

namespace CSLT_INF509005_T2.session03
{
    internal class Exercises_3_1_giả_sử_giá_cố_định
    {
        public static void Main1111(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Bài 1: Tính Tiền Điện Sinh Hoạt Gia Đình Theo Bậc Thang(EVN)
            //Tình huống thực tế: Tập đoàn Điện lực Việt Nam(EVN) áp dụng biểu giá điện sinh hoạt bậc thang lũy tiến để khuyến khích người dân tiết kiệm điện.Hãy viết chương trình tính hóa đơn tiền điện hàng tháng cho một hộ gia đình.
            //Kiến thức trọng tâm: Kiểu decimal, ép kiểu dữ liệu, định dạng tiền tệ({ 0:C} hoặc #,##0 VNĐ), tính toán toán học. 
            //Yêu cầu bài toán: 
            //• Nhập vào chỉ số điện cũ(kWh) và chỉ số điện mới(kWh).Kiểm tra điều kiện chỉ số mới phải lớn hơn hoặc bằng chỉ số cũ.
            //• Tính lượng điện tiêu thụ trong tháng = Chỉ số mới - Chỉ số cũ.
            //• Tính tiền điện theo các bậc giá chưa thuế (Giá giả định năm 2026): 
            //• + Bậc 1: Cho 50 kWh đầu tiên(từ 0 - 50 kWh) : 1.806 VNĐ/kWh 
            //• + Bậc 2: Cho 50 kWh tiếp theo(từ 51 - 100 kWh) : 1.866 VNĐ/kWh 
            //• + Bậc 3: Cho 100 kWh tiếp theo(từ 101 - 200 kWh) : 2.167 VNĐ/kWh 
            //• + Bậc 4: Cho 100 kWh tiếp theo(từ 201 - 300 kWh) : 2.729 VNĐ/kWh
            //• + Bậc 5: Cho toàn bộ kWh từ 301 kWh trở lên: 3.050 VNĐ/kWh 
            //• Cộng thêm 8 % Thuế Giá trị gia tăng(VAT). 
            //• In hóa đơn chi tiết gồm: Số kWh tiêu thụ, Tiền điện chưa thuế, Tiền thuế VAT và Tổng tiền phải thanh toán(làm tròn đến hàng đơn vị decimal). 
            Console.Write("Nhập chỉ số điện cũ (kWh):");
            float csd_cu = float.Parse(Console.ReadLine());
            float csd_moi;
            do
            {
                Console.Write("Nhập chỉ số điện mới (kWh):");
                csd_moi = float.Parse(Console.ReadLine());
                if (csd_moi >= csd_cu)
                    break;
                else
                    Console.WriteLine("\t*** Chỉ số mới phải lớn hơn hoặc bằng chỉ số cũ.");
            } while (true);

            //Tính lượng điện tiêu thụ trong tháng = Chỉ số mới - Chỉ số cũ.
            float tieuThu = csd_moi - csd_cu;
            //Giả sử đơn giá cố định 1 chữ là 3059 đồng /1 kWh
            float dongia = 3059f;

            decimal tienDien = (decimal)(tieuThu * dongia);//cast

            //thuế VAT
            decimal vat = (decimal)(tieuThu * 0.08f);

            //in ra hoá đơn
            Console.WriteLine($"\nSố điện tiêu thụ: {tieuThu} kWh");
            Console.WriteLine($"Tiền điện chưa thuế: {tienDien:C} ");
            Console.WriteLine($"Thuế VAT (8%): {vat} ");
            Console.WriteLine($"Tổng thanh toán: {tienDien + vat} ");
        }
    }
}
