using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSLT_INF509005_T2.session03
{
    internal class Exercises_3_1
    {

        static void Bai_1()
        {
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

            //Tính tiền điện
            decimal soKwh = (decimal)tieuThu;
            decimal tienDien = 0;

            if (soKwh > 300)
            {
                tienDien += (soKwh - 300) * 3050m; // Bậc 5
                tienDien += 100 * 2729m;           // Bậc 4
                tienDien += 100 * 2167m;           // Bậc 3
                tienDien += 50 * 1866m;            // Bậc 2
                tienDien += 50 * 1806m;            // Bậc 1
            }
            else if (soKwh > 200)
            {
                tienDien += (soKwh - 200) * 2729m; // Bậc 4
                tienDien += 100 * 2167m;           // Bậc 3
                tienDien += 50 * 1866m;            // Bậc 2
                tienDien += 50 * 1806m;            // Bậc 1
            }
            else if (soKwh > 100)
            {
                tienDien += (soKwh - 100) * 2167m; // Bậc 3
                tienDien += 50 * 1866m;            // Bậc 2
                tienDien += 50 * 1806m;            // Bậc 1
            }
            else if (soKwh > 50)
            {
                tienDien += (soKwh - 50) * 1866m;  // Bậc 2
                tienDien += 50 * 1806m;            // Bậc 1
            }
            else
            {
                tienDien += soKwh * 1806m;         // Bậc 1
            }

            //Thuế VAT
            decimal vat = tienDien * (decimal)0.08f;

            //làm tròn đến hàng đơn vị trước khi định dạng :C
            tienDien = Math.Round(tienDien, 0);
            vat = Math.Round(vat, 0);
        
            //In ra hoá đơn
            Console.WriteLine($"\nSố điện tiêu thụ: {tieuThu} kWh");
            Console.WriteLine($"Tiền điện chưa thuế: {tienDien:#,##0} VNĐ ");
            Console.WriteLine($"Thuế VAT (8%): {vat:#,##0} VNĐ ");
            Console.WriteLine($"Tổng thanh toán: {tienDien + vat:#,##0} VNĐ ");

            Console.ReadLine();
        }
        
       static void Bai_2()
        {
            //Bài 2: Hệ Thống Theo Dõi Chỉ Số BMI & Đánh Giá Tình Trạng Sức Khỏe
            //Tình huống thực tế: Một ứng dụng theo dõi sức khỏe cá nhân cần tính chỉ số khối cơ thể(BMI -Body Mass Index) dựa trên chiều cao và cân nặng do người dùng cung cấp, đồng thời đưa ra lời khuyên về cân nặng lý tưởng.
            //Kiến thức trọng tâm: Kiểu double, ép kiểu, Math.Pow(), định dạng số thập phân({ 0:F2}), cấu trúc rẽ nhánh.
            //Yêu cầu bài toán:
            //• Nhập vào chiều cao(tính bằng mét, ví dụ 1.72) và cân nặng(tính bằng kg, ví dụ 68.5).
            //• Tính chỉ số BMI theo công thức: BMI = Cân nặng / (Chiều cao ^ 2).
            //• Phân loại tình trạng sức khỏe theo chuẩn WHO dành cho người châu Á:
            //• +BMI < 18.5: Gầy(Thiếu cân)
            //• +18.5 <= BMI < 23.0: Bình thường(Lý tưởng)
            //• +23.0 <= BMI < 25.0: Thừa cân(Tiền béo phì)
            //• +BMI >= 25.0: Béo phì
            //• Tính dải cân nặng lý tưởng cho chiều cao đó(Cân nặng tối thiểu = 18.5 * Chiều cao^2; Cân nặng tối đa = 22.9 * Chiều cao ^ 2).
            //• Xuất ra chỉ số BMI(lấy 2 chữ số thập phân), phân loại và khoảng cân nặng lý tưởng.

            // Chiều cao > 0
            float chieuCao;
            do
            {
                Console.Write("Chiều cao (m): ");
                chieuCao = float.Parse(Console.ReadLine());
                if (chieuCao > 0)
                    break;
                else
                    Console.WriteLine("\t*** Chiều cao phải lớn hơn 0.");
            } while (true);

            // Cân nặng > 0
            float canNang;
            do
            {
                Console.Write("Cân nặng (kg): ");
                canNang = float.Parse(Console.ReadLine());
                if (canNang > 0)
                    break;
                else
                    Console.WriteLine("\t*** Cân nặng phải lớn hơn 0.");
            } while (true);

            // Tính chỉ số BMI = Cân nặng / (Chiều cao ^ 2)
            float bmi = canNang / (float)Math.Pow(chieuCao, 2);

            // Phân loại tình trạng sức khỏe dựa trên BMI
            string tinhTrang = "";
            if (bmi < 18.5f)
            {
                tinhTrang = "Gầy (Thiếu cân)";
            }
            else if (bmi >= 18.5f && bmi < 23.0f)
            {
                tinhTrang = "Bình thường (Lý tưởng)";
            }
            else if (bmi >= 23.0f && bmi < 25.0f)
            {
                tinhTrang = "Thừa cân (Tiền béo phì)";
            }
            else
            {
                tinhTrang = "Béo phì";
            }

            // Tính dải cân nặng lý tưởng cho chiều cao tương ứng
            float canNangToiThieu = 18.5f * (float)Math.Pow(chieuCao, 2);
            float canNangToiDa = 22.9f * (float)Math.Pow(chieuCao, 2);

            Console.WriteLine("\nChỉ số BMI của bạn: {0:F2}", bmi);
            Console.WriteLine("Phân loại sức khỏe: {0}", tinhTrang);
            Console.WriteLine("Khuyên dùng: Cân nặng lý tưởng của bạn nên từ {0:F2} kg đến {1:F2} kg.", canNangToiThieu, canNangToiDa);

            Console.ReadLine();
        }

        enum CurrencyType
        // 1. Khai báo enum CurrencyType (Bai_3)
        {
            USD = 1,
            EUR = 2,
            JPY = 3,
            GBP = 4
        }
        static void Bai_3()
        {
            //Bài 3: Ứng Dụng Quy Đổi Tiền Tệ Ngoại Tệ Đa Tỷ Giá Ngân Hàng
            //Tình huống thực tế: Một quầy đổi tiền tại sân bay cần ứng dụng tính toán nhanh số tiền khách hàng nhận được khi đổi từ Việt Nam Đồng(VND) sang các loại ngoại tệ phổ biến(USD, EUR, JPY, GBP) có tính phí dịch vụ.
            //Kiến thức trọng tâm: Kiểu decimal, enum (CurrencyType), switch-case, định dạng tiền tệ quốc tế.
            //Yêu cầu bài toán:
            //• Tạo một enum tên CurrencyType gồm: USD, EUR, JPY, GBP.
            //• Khai báo tỷ giá cố định(Ví dụ: 1 USD = 25,400 VNĐ; 1 EUR = 27,200 VNĐ; 1 JPY = 165 VNĐ; 1 GBP = 32,100 VNĐ).
            //• Nhập vào số tiền VNĐ cần đổi(decimal) và chọn loại ngoại tệ muốn đổi.
            //• Phí dịch vụ quy đổi là 0.5 % trên tổng số tiền VNĐ.
            //• Tính số tiền VNĐ thực tế sau khi trừ phí, sau đó quy đổi ra ngoại tệ tương ứng.
            //• In kết quả chính xác đến 2 chữ số thập phân kèm ký hiệu tiền tệ
            
            // Nhập số tiền VNĐ cần đổi (decimal)
            Console.Write("Nhập số tiền VNĐ: ");
            decimal totalVnd = decimal.Parse(Console.ReadLine());

            int choice;
            do
            {
                Console.Write("Chọn ngoại tệ (1-USD, 2-EUR, 3-JPY, 4-GBP): ");
                choice = int.Parse(Console.ReadLine());

                // Sử dụng Enum để kiểm tra tính hợp lệ
                if (Enum.IsDefined(typeof(CurrencyType), choice))
                    break;
                else
                    Console.WriteLine("\t*** Lựa chọn không hợp lệ. Vui lòng chọn từ 1 đến 4.");
            } while (true);

            // Khai báo tỷ giá cố định dạng số thực/nguyên ban đầu 
            float exchangeRate = 0f;
            string currencyName = "";

            // Ép kiểu choice về enum CurrencyType để dùng trong switch-case
            CurrencyType selectedCurrency = (CurrencyType)choice;

                switch (selectedCurrency)
                {
                    case CurrencyType.USD:
                        exchangeRate = 25400f;
                        currencyName = "USD";
                        break;
                    case CurrencyType.EUR:
                        exchangeRate = 27200f;
                        currencyName = "EUR";
                        break;
                    case CurrencyType.JPY:
                        exchangeRate = 165f;
                        currencyName = "JPY";
                        break;
                    case CurrencyType.GBP:
                        exchangeRate = 32100f;
                        currencyName = "GBP";
                        break;
                }

            // Tính phí dịch vụ quy đổi là 0.5% trên tổng số tiền VNĐ và ép kiểu sang (decimal) giống bài tiền điện
            decimal serviceFee = (decimal)(totalVnd * 0.005m);

            // Tính số tiền VNĐ thực tế sau khi trừ phí
            decimal netVnd = totalVnd - serviceFee;

            // Quy đổi ra ngoại tệ tương ứng và ép kiểu sang decimal
            decimal foreignAmount = (decimal)((float)netVnd / exchangeRate); //cast

            Console.WriteLine($"\nPhí dịch vụ (0.5%): {serviceFee:#,##0} VNĐ");
            Console.WriteLine($"Số tiền VNĐ tính đổi: {netVnd:#,##0} VNĐ");
            Console.WriteLine($"Số tiền {currencyName} nhận được: {foreignAmount:F2} {currencyName}");

            Console.ReadLine();
        }

        static void Bai_4()
        {
            //Bài 4: Tính Tuổi Chính Xác & Đếm Ngược Ngày Sinh Nhật
            //Tình huống thực tế: Hệ thống chăm sóc khách hàng của một công ty bán lẻ cần tự động tính tuổi chính xác của khách hàng và đếm số ngày còn lại đến sinh nhật tiếp theo để gửi voucher ưu đãi.
            //Kiến thức trọng tâm: Kiểu DateTime, TimeSpan, DateTime.ParseExact, toán tử trừ hai ngày, ép kiểu.
            //Yêu cầu bài toán:
            //• Nhập ngày tháng năm sinh của người dùng dưới dạng chuỗi 'dd/MM/yyyy'(ví dụ: '25/10/2002').
            //• Chuyển đổi chuỗi thành DateTime sử dụng DateTime.TryParseExact để đảm bảo không bị lỗi định dạng.
            //• Lấy ngày hiện tại hệ thống(DateTime.Now.Date).
            //• Tính tuổi chính xác tính theo số năm.
            //• Xác định ngày sinh nhật tiếp theo trong năm nay hoặc năm sau.Tính số ngày còn lại đến sinh nhật đó.
            //• Hiển thị: Tuổi hiện tại, Tổng số ngày đã sống từ lúc sinh ra, và Số ngày còn lại đến sinh nhật kế tiếp.

            DateTime ngaySinh;

            do
            {
                Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
                bool checkDinhDang = DateTime.TryParseExact(
                    Console.ReadLine(),
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out ngaySinh
                );
                DateTime ngayHienTai = DateTime.Now.Date;

                if (checkDinhDang == true && ngaySinh <= ngayHienTai)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t*** Ngày sinh không hợp lệ hoặc sai định dạng dd/MM/yyyy. Vui lòng nhập lại.");
                }
            } while (true);

            DateTime ngayHienTaiHethong = DateTime.Now.Date;

            // Tính tuổi chính xác tính theo số năm
            int tuoi = ngayHienTaiHethong.Year - ngaySinh.Year;
            if (ngayHienTaiHethong < ngaySinh.AddYears(tuoi))
            {
                tuoi--; // Giảm đi 1 tuổi nếu năm nay chưa đến ngày sinh nhật
            }

            // Chênh lệch giữa 2 DateTime trả về một đối tượng TimeSpan. Dùng thuộc tính TotalDays của TimeSpan.
            TimeSpan chenhLechDaSong = ngayHienTaiHethong - ngaySinh;
            float tongSoNgayDaSong = (float)chenhLechDaSong.TotalDays;

            // Xác định ngày sinh nhật tiếp theo trong năm nay hoặc năm sau
            DateTime sinhNhatTiepTheo = ngaySinh.AddYears(tuoi);
            if (sinhNhatTiepTheo < ngayHienTaiHethong)
            {
                sinhNhatTiepTheo = ngaySinh.AddYears(tuoi + 1);
            }

            // Tính số ngày còn lại đến sinh nhật đó
            TimeSpan chenhLechDenSinhNhat = sinhNhatTiepTheo - ngayHienTaiHethong;
            float soNgayConLai = (float)chenhLechDenSinhNhat.TotalDays;

            // Áp dụng cách tính tiền và ép kiểu decimal giống ảnh hướng dẫn mới của thầy:
            // Giả sử có một quy đổi vui: quy đổi số ngày đã sống thành giá trị quy đổi nào đó (hoặc giữ nguyên định dạng số)
            decimal ngayDaSongDecimal = (decimal)(tongSoNgayDaSong);//cast
            decimal ngayConLaiDecimal = (decimal)(soNgayConLai);//cast

            Console.WriteLine($"\nTuổi hiện tại: {tuoi} tuổi");
            Console.WriteLine($"Bạn đã sống tổng cộng: {ngayDaSongDecimal:N0} ngày ");
            Console.WriteLine($"Sinh nhật tiếp theo còn: {ngayConLaiDecimal:N0} ngày nữa "); 
           
            Console.ReadLine();
        }

        static void Bai_5()
        {
            //Bài 5: Quản Lý Điểm Học Phần & Quy Đổi Thang Điểm GPA(4.0)
            //Tình huống thực tế: Hệ thống quản lý đào tạo đại học cần tính điểm trung bình tín chỉ(GPA) học kỳ cho sinh viên dựa trên điểm số các môn học và quy đổi sang thang điểm chữ(A, B, C, D, F) cùng thang điểm 4.
            //Kiến thức trọng tâm: Kiểu float hoặc double, char, enum, ép kiểu điểm số, định dạng bảng xuất.
            //Yêu cầu bài toán:
            //• Nhập điểm số(thang 10, kiểu double) và số tín chỉ(int) của 3 môn học: Lập trình C#, Toán rời rạc, Tiếng Anh.
            //• Tính điểm trung bình trọng số (Weighted Average Score):
            // Score_Avg = (Điểm1* TC1 + Điểm2* TC2 +Điểm3 * TC3) / (TC1 + TC2 + TC3).
            //• Quy đổi Score_Avg sang Điểm chữ(char/string) và Thang điểm 4 (double):
            //• + [8.5 - 10.0]: Điểm A | Thang 4: 4.0 | Xếp loại: Xuất sắc / Giỏi
            //• + [7.0 - 8.4] : Điểm B | Thang 4: 3.0 | Xếp loại: Khá
            //• + [5.5 - 6.9] : Điểm C | Thang 4: 2.0 | Xếp loại: Trung bình
            //• + [4.0 - 5.4] : Điểm D | Thang 4: 1.0 | Xếp loại: Yếu
            //• + [< 4.0] : Điểm F | Thang 4: 0.0 | Xếp loại: Kém(Trượt)
            //• Xuất bảng điểm chi tiết và GPA làm tròn 2 chữ số thập phân.

            // 1. Nhập thông tin môn C#
            int tc_cs = 4;
            float diem_cs;
            do
            {
                Console.Write($"C# ({tc_cs} TC): ");
                diem_cs = float.Parse(Console.ReadLine());
                if (diem_cs >= 0f && diem_cs <= 10f)
                    break;
                else
                    Console.WriteLine("\t*** Điểm số phải nằm trong khoảng từ 0 đến 10.");
            } while (true);

            // 2. Nhập thông tin môn Toán
            int tc_toan = 3;
            float diem_toan;
            do
            {
                Console.Write($"Toán ({tc_toan} TC): ");
                diem_toan = float.Parse(Console.ReadLine());
                if (diem_toan >= 0f && diem_toan <= 10f)
                    break;
                else
                    Console.WriteLine("\t*** Điểm số phải nằm trong khoảng từ 0 đến 10.");
            } while (true);

            // 3. Nhập thông tin môn Tiếng Anh
            int tc_ta = 2;
            float diem_ta;
            do
            {
                Console.Write($"Tiếng Anh ({tc_ta} TC): ");
                diem_ta = float.Parse(Console.ReadLine());
                if (diem_ta >= 0f && diem_ta <= 10f)
                    break;
                else
                    Console.WriteLine("\t*** Điểm số phải nằm trong khoảng từ 0 đến 10.");
            } while (true);

            int tong_tc = tc_cs + tc_toan + tc_ta;

            // Tính điểm trung bình trọng số (Hệ 10)
            float score_avg = (diem_cs * tc_cs + diem_toan * tc_toan + diem_ta * tc_ta) / tong_tc;

            // Quy đổi kết quả dựa trên các khoảng điểm của đề bài
            string diem_chu;
            float thang_4;
            string xep_loai;

            if (score_avg >= 8.5f && score_avg <= 10.0f)
            {
                diem_chu = "A";
                thang_4 = 4.0f;
                xep_loai = "Xuất sắc / Giỏi";
            }
            else if (score_avg >= 7.0f && score_avg < 8.5f)
            {
                diem_chu = "B";
                thang_4 = 3.0f;
                xep_loai = "Khá";
            }
            else if (score_avg >= 5.5f && score_avg < 7.0f)
            {
                diem_chu = "C";
                thang_4 = 2.0f;
                xep_loai = "Trung bình";
            }
            else if (score_avg >= 4.0f && score_avg < 5.5f)
            {
                diem_chu = "D";
                thang_4 = 1.0f;
                xep_loai = "Yếu";
            }
            else
            {
                diem_chu = "F";
                thang_4 = 0.0f;
                xep_loai = "Kém (Trượt)";
            }

            // Áp dụng kỹ thuật ép kiểu decimal giống thầy hướng dẫn bài tiền điện
            decimal gpa_thang_4 = (decimal)thang_4; //cast

            Console.WriteLine($"\nĐiểm TB Thang 10: {score_avg:F2}");
            Console.WriteLine($"Điểm Chữ Quy Đổi: {diem_chu}");
            Console.WriteLine($"Điểm GPA Thang 4: {gpa_thang_4:F2}");
            Console.WriteLine($"Xếp Loại Học Lực: {xep_loai}");

            Console.ReadLine();
        }

        static void Bai_6()
        {
            //Bài 6: Chuẩn Hóa Họ Tên Người Dùng &Tự Động Tạo Email / Username
            //Tình huống thực tế: Bộ phận Nhân sự(HR) cần một công cụ xử lý dữ liệu thô nhập vào từ biểu mẫu đăng ký.Họ tên nhập vào thường bị lỗi thừa khoảng trắng, hoa thường lộn xộn.Cần chuẩn hóa tên và tạo tài khoản công ty.
            //Kiến thức trọng tâm: Kiểu string, các phương thức Trim(), Split(), Substring(), ToLower(), ToUpper(), string.Join().
            //Yêu cầu bài toán:
            //• Nhập vào một chuỗi họ tên thô từ bàn phím(Ví dụ: " ngUYỄN vĂn aN ").
            //• Loại bỏ khoảng trắng thừa ở đầu, cuối và giữa các từ(chỉ giữ lại 1 khoảng trắng giữa các từ).
            //• Chuyển đổi chuỗi thành dạng Viết Hoa Chữ Cái Đầu Mỗi Từ(Title Case): "Nguyễn Văn An".
            //• Tách thành Họ, Tên Đệm và Tên chính.
            //• Tạo Username không dấu theo quy tắc: ten.hovatenm. (Ví dụ: an.nguyenvan).
            //• Tạo Email công ty: username + "@company.edu.vn".

            // SỬA LỖI CHÍNH: Cấu hình Console hiển thị và nhập được tiếng Việt Unicode

            Console.Write("Nhập họ tên thô: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) return;

            // 1. Chuẩn hóa khoảng trắng thừa
            input = Regex.Replace(input.Trim(), @"\s+", " ");

            // 2. Tách các từ trong họ tên
            string[] words = input.Split(' ');

            // 3. Viết hoa chữ cái đầu của từng từ (ví dụ: tRẦN -> Trần)
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }

            string hoTenChuanHoa = string.Join(" ", words);

            // 4. Tách Họ, Tên đệm, Tên
            string ho = words[0];
            string ten = words[words.Length - 1];
            string tenDem = "";
            if (words.Length > 2)
            {
                tenDem = string.Join(" ", words, 1, words.Length - 2);
            }

            // 5. Tạo Username và Email (Chuyển sang dạng không dấu, viết thường)
            string tenKhongDau = LoaiBoDauTiengViet(ten).ToLower();

            string hoTenDemKhongDau = "";
            for (int i = 0; i < words.Length - 1; i++)
            {
                hoTenDemKhongDau += LoaiBoDauTiengViet(words[i]).ToLower();
            }

            string username = $"{tenKhongDau}.{hoTenDemKhongDau}";
            string email = $"{username}@company.edu.vn";

            Console.WriteLine($"\nHọ tên chuẩn hóa: {hoTenChuanHoa}");
            Console.WriteLine($"Họ: {ho} | Tên đệm: {tenDem} | Tên: {ten}");
            Console.WriteLine($"Username tạo tự động: {username}");
            Console.WriteLine($"Email cấp phát: {email}");

            Console.ReadLine();
        }

        // Hàm loại bỏ hoàn toàn dấu tiếng Việt sử dụng mã hóa an toàn, bất chấp định dạng file nguồn
        static string LoaiBoDauTiengViet(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            // Thay thế nhóm ký tự chữ A/a bằng mã Hex nội bộ
            text = Regex.Replace(text, "[\u00e1\u00e0\u1ea3\u00e3\u1ea1\u0103\u1eaf\u1eb1\u1eb3\u1eb5\u1eb7\u00e2\u1ea5\u1ea7\u1ea9\u1eab\u1eac]", "a");
            text = Regex.Replace(text, "[\u00c1\u00c0\u1ea2\u00c3\u1ea0\u0102\u1eae\u1eb0\u1eb2\u1eb4\u1eb6\u00c2\u1ea4\u1ea6\u1ea8\u1eaa\u1eac]", "A");

            // Thay thế nhóm ký tự chữ E/e
            text = Regex.Replace(text, "[\u00e9\u00e8\u1ebd\u1ebf\u1ec1\u1ec3\u1ec5\u1ec7\u1eb9\u1ebb\u00ea]", "e");
            text = Regex.Replace(text, "[\u00c9\u00c8\u1ebc\u1ebe\u1ec0\u1ec2\u1ec4\u1ec6\u1eb8\u1eba\u00ca]", "E");

            // Thay thế nhóm ký tự chữ I/i
            text = Regex.Replace(text, "[\u00ed\u00ec\u1ec9\u0129\u1ecb]", "i");
            text = Regex.Replace(text, "[\u00cd\u00cc\u1ec8\u0128\u1eca]", "I");

            // Thay thế nhóm ký tự chữ U/u
            text = Regex.Replace(text, "[\u00fa\u00f9\u1ee7\u0169\u1ee5\u01b0\u1ee9\u1eeb\u1eed\u1eef\u1ef1]", "u");
            text = Regex.Replace(text, "[\u00da\u00d9\u1ee6\u0168\u1ee4\u01af\u1ee8\u1eea\u1eec\u1eee\u1ef0]", "U");

            // Thay thế nhóm ký tự chữ Y/y
            text = Regex.Replace(text, "[\u00fd\u1ef3\u1ef7\u1ef9\u1ef5]", "y");
            text = Regex.Replace(text, "[\u00dd\u1ef2\u1ef6\u1ef8\u1ef4]", "Y");

            // Thay thế nhóm ký tự chữ O/o
            text = Regex.Replace(text, "[\u00f3\u00f2\u1ecf\u00f5\u1ecd\u00f4\u1ed1\u1ed3\u1ed5\u1ed7\u1ed9\u01a1\u1edb\u1edd\u1edf\u1ee1\u1ee3]", "o");
            text = Regex.Replace(text, "[\u00d3\u00d2\u1ece\u00d5\u1ecc\u00d4\u1ed0\u1ed2\u1ed4\u1ed6\u1ed8\u01a0\u1eda\u1edc\u1ede\u1ee0\u1ee2]", "O");
            // Thay thế chữ Đ/đ đặc biệt
            text = text.Replace("\u0111", "d"); // đ
            text = text.Replace("\u0110", "D"); // Đ

            return text;
        }

        static void Bai_7()
        {
            //Bài 7: Lập Kế Hoạch Chi Phí Nhiên Liệu & Chia Sẻ Chuyến Đi(Car - pooling)
            //Tình huống thực tế: Một nhóm bạn lên kế hoạch đi phượt bằng xe ô tô cá nhân. Họ cần một máy tính bỏ túi để ước tính tổng lượng nhiên liệu tiêu thụ, tổng chi phí xăng dầu và chia đều cho từng thành viên.
            //Kiến thức trọng tâm: Kiểu double, decimal, int, Math.Ceiling, định dạng tiền tệ.
            //Yêu cầu bài toán:
            //• Nhập khoảng cách chuyến đi(km - kiểu double).
            //• Nhập mức tiêu thụ nhiên liệu trung bình của xe(lít/ 100km - kiểu double).
            //• Nhập giá xăng hiện tại(VNĐ / lít - kiểu decimal).
            //• Nhập số lượng người tham gia chuyến đi(người -kiểu int).
            //• Tính tổng số lít xăng cần dùng = (Quãng đường / 100) * Mức tiêu thụ.
            //• Tính tổng chi phí tiền xăng = Tổng số lít xăng * Giá xăng.
            //• Tính số tiền mỗi người phải chi trả(làm tròn lên hàng nghìn VNĐ gần nhất bằng Math.Ceiling).

            Console.Write("Quãng đường (km): ");
            double distance = double.Parse(Console.ReadLine());

            Console.Write("Mức tiêu hao (L/100km): ");
            double fuelConsumptionRate = double.Parse(Console.ReadLine());

            Console.Write("Giá xăng (VNĐ/Lít): ");
            decimal fuelPrice = decimal.Parse(Console.ReadLine());

            int number_of_people;
            do
            {
                Console.Write("Số người đi: ");
                number_of_people = int.Parse(Console.ReadLine());
                if (number_of_people > 0)
                    break;
                else
                    Console.WriteLine("\t*** Số người đi phải lớn hơn 0.");
            } while (true);

            // Tính tổng số lít xăng cần dùng
            double totalFuel = (distance / 100.0) * fuelConsumptionRate;

            // Tính tổng chi phí tiền xăng
            decimal totalCost = (decimal)(totalFuel * (double)fuelPrice); //cast

            // Tính số tiền mỗi người phải chi trả và làm tròn
            decimal costPerPerson = totalCost / number_of_people;
            decimal costPerPersonRounded = Math.Ceiling(costPerPerson / 1000m) * 1000m;

            Console.WriteLine($"\nTổng nhiên liệu tiêu thụ: {totalFuel} Lít");
            Console.WriteLine($"Tổng chi phí xăng dầu: {totalCost:N0} VNĐ");
            Console.WriteLine($"Chi phí mỗi người: {costPerPersonRounded:N0} VNĐ");

            Console.ReadLine();
        }

        static void Bai_8()
        {
            //Bài 8: Kiểm Tra Mã Xác Thực OTP &Quản Lý Thời Gian Hiệu Lực
            //Tình huống thực tế: Hệ thống bảo mật ngân hàng gửi mã xác thực OTP gồm 6 chữ số đến điện thoại người dùng.Mã OTP chỉ có hiệu lực trong vòng 5 phút(300 giây) kể từ thời điểm phát hành.
            //Kiến thức trọng tâm: Kiểu string, DateTime, TimeSpan, bool, int.TryParse, so sánh chuỗi.
            //Yêu cầu bài toán:
            //• Mô phỏng hệ thống tạo sẵn mã OTP đúng: "839201" và thời điểm tạo mã CreationTime = DateTime.Now.
            //• Cho phép người dùng nhập mã OTP từ bàn phím và nhập thời gian gửi xác nhận(hoặc giả lập thời gian trôi qua).
            //• Kiểm tra 3 điều kiện an toàn:
            //• 1.Chuỗi nhập vào đúng đủ 6 ký tự và toàn là số.
            //• 2.Mã OTP nhập vào khớp hoàn toàn với mã hệ thống đã gửi.
            //• 3.Thời điểm xác thực không vượt quá 5 phút so với CreationTime.
            //• In kết quả xác minh: THÀNH CÔNG hoặc LỖI CỤ THỂ(Mã sai / Hết hạn OTP / Định dạng không hợp lệ).

            // 1. Khởi tạo dữ liệu hệ thống dựa trên yêu cầu đề bài
            string correctOtp = "839201";

            // 2. NHẬN DỮ LIỆU ĐẦU VÀO (INPUT)
            Console.WriteLine("--- INPUT ---");

            string inputOtp;
            do
            {
                Console.Write("Mã OTP nhận được: ");
                inputOtp = Console.ReadLine();

                if (inputOtp.Length == 6 && int.TryParse(inputOtp, out _))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t*** Định dạng không hợp lệ. OTP phải có đủ 6 ký tự số.");
                }
            } while (true);


            int minutes = 0;
            int seconds = 0;
            do
            {
                Console.Write("Thời gian trôi qua: ");
                string inputTime = Console.ReadLine(); // Người dùng nhập: "2 phút 15 giây"

                // Tách chuỗi để lấy số phút và số giây
                string[] parts = inputTime.Split(' ');

                if (parts.Length >= 4 && int.TryParse(parts[0], out minutes) && int.TryParse(parts[2], out seconds))
                {
                    if (minutes >= 0 && seconds >= 0)
                    {
                        break;
                    }
                }
                Console.WriteLine("\t*** Định dạng không hợp lệ. Vui lòng nhập đúng mẫu (Ví dụ: 2 phút 15 giây).");
            } while (true);


            // 3. XỬ LÝ VÀ HIỂN THỊ KẾT QUẢ ĐẦU RA (OUTPUT)
            Console.WriteLine("--- OUTPUT ---");

            // Kiểm tra điều kiện mã đúng và thời gian trong giới hạn 5 phút (300 giây)
            int totalSecondsElapsed = (minutes * 60) + seconds;

            if (inputOtp != correctOtp)
            {
                Console.WriteLine("Trạng thái xác thực: LỖI - Mã sai.");
            }
            else if (totalSecondsElapsed > 300)
            {
                Console.WriteLine("Trạng thái xác thực: LỖI - Hết hạn OTP.");
            }
            else
            {
                // In ra chính xác theo mẫu: THÀNH CÔNG - Giao dịch đã được phê duyệt.
                Console.WriteLine("Trạng thái xác thực: THÀNH CÔNG - Giao dịch đã được phê duyệt.");
            }

            Console.ReadLine();
        }

        static void Bai_9()
        {
            //Bài 9: Máy Tính Lương Gross -Net & Thuế TNCN Nhân Viên
            //Tình huống thực tế: Phòng kế toán cần phần mềm tự động tính tiền lương thực nhận(Net Salary) từ lương thỏa thuận(Gross Salary) sau khi trừ các khoản bảo hiểm bắt buộc và Thuế thu nhập cá nhân(TNCN).
            //Kiến thức trọng tâm: Kiểu decimal, double, bool, tính toán phần trăm, cấu trúc thuế lũy tiến.
            //Yêu cầu bài toán:
            //• Nhập Lương Gross(VNĐ) và Số người phụ thuộc(int).
            //• Tính các khoản Bảo hiểm bắt buộc theo tỷ lệ hiện hành(trên lương Gross):
            //• +Bảo hiểm xã hội(BHXH): 8 %
            //• +Bảo hiểm y tế(BHYT): 1.5 %
            //• +Bảo hiểm thất nghiệp(BHTN): 1 %
            //• => Tổng giảm trừ bảo hiểm = 10.5 % *Lương Gross.
            //• Tính Thu nhập chịu thuế = Gross - Tổng bảo hiểm -Mức bản thân(11,000,000 VNĐ) -(Số người phụ thuộc * 4,400,000 VNĐ). (Nếu <= 0 thì Thu nhập chịu thuế = 0).
            //• Tính Thuế TNCN theo biểu thuế lũy tiến từng phần(Bậc 1: 5 % cho <= 5tr, Bậc 2: 10 % cho 5 - 10tr, Bậc 3: 15 % cho 10 - 18tr...).
            //• Tính Lương Net thực nhận = Gross - Tổng bảo hiểm -Thuế TNCN
            // Nhập lương Gross ban đầu bằng kiểu float

            // 1. Nhập lương Gross 
            Console.Write("Lương Gross: ");
            // 1. Đọc dữ liệu dưới dạng chuỗi (string)
            string inputGross = Console.ReadLine();
            float gross_float = float.Parse(inputGross);
            // 2. Di chuyển con trỏ ngược lên dòng vừa nhập
            Console.SetCursorPosition(13, Console.CursorTop - 1);
            // 3. Ép kiểu tạm thời sang decimal để định dạng :N0 xuất ra dấu phẩy, kèm chữ VNĐ
            Console.WriteLine($"{((decimal)gross_float):N0} VNĐ");

            // 2. Nhập Số người phụ thuộc (Bắt buộc dùng kiểu INT theo đúng đề bài)
            int soNguoiPhuThuoc;
            do
            {
                Console.Write("Số người phụ thuộc: ");
                soNguoiPhuThuoc = int.Parse(Console.ReadLine());

                if (soNguoiPhuThuoc >= 0)
                    break;
                else
                    Console.WriteLine("\t*** Số người phụ thuộc phải lớn hơn hoặc bằng 0.");

            } while (true);

            // Ép kiểu (decimal) từ biến float sang tính toán tài chính giống thầy //cast
            decimal bhxh = (decimal)(gross_float * 0.08f);
            decimal bhyt = (decimal)(gross_float * 0.015f);
            decimal bhtn = (decimal)(gross_float * 0.01f);
            decimal tongBaoHiem = bhxh + bhyt + bhtn;

            // Tính các khoản giảm trừ gia cảnh (Số người phụ thuộc dùng toán tử nhân với kiểu int)
            decimal giamTruBanThan = 11000000m;
            decimal giamTruPhuThuoc = soNguoiPhuThuoc * 4400000m;

            // Thu nhập chịu thuế = Gross - Tổng bảo hiểm - Mức bản thân - Người phụ thuộc
            decimal thuNhapChiuThue = (decimal)gross_float - tongBaoHiem - giamTruBanThan - giamTruPhuThuoc;

            // Kiểm tra kỹ điều kiện thu nhập chịu thuế không được âm
            if (thuNhapChiuThue <= 0)
            {
                thuNhapChiuThue = 0;
            }

            // Tính thuế TNCN theo biểu thuế lũy tiến từng phần của đề bài
            decimal thueTNCN = 0;
            if (thuNhapChiuThue <= 5000000m)
            {
                thueTNCN = thuNhapChiuThue * 0.05m;
            }
            else if (thuNhapChiuThue <= 10000000m)
            {
                thueTNCN = (5000000m * 0.05m) + ((thuNhapChiuThue - 5000000m) * 0.10m);
            }
            else if (thuNhapChiuThue <= 18000000m)
            {
                thueTNCN = (5000000m * 0.05m) + (5000000m * 0.10m) + ((thuNhapChiuThue - 10000000m) * 0.15m);
            }
            else if (thuNhapChiuThue <= 32000000m)
            {
                thueTNCN = (5000000m * 0.05m) + (5000000m * 0.10m) + (8000000m * 0.15m) + ((thuNhapChiuThue - 18000000m) * 0.20m);
            }
            else if (thuNhapChiuThue <= 52000000m)
            {
                thueTNCN = (5000000m * 0.05m) + (5000000m * 0.10m) + (8000000m * 0.15m) + (14000000m * 0.20m) + ((thuNhapChiuThue - 32000000m) * 0.25m);
            }
            else if (thuNhapChiuThue <= 80000000m)
            {
                thueTNCN = (5000000m * 0.05m) + (5000000m * 0.10m) + (8000000m * 0.15m) + (14000000m * 0.20m) + (20000000m * 0.25m) + ((thuNhapChiuThue - 52000000m) * 0.30m);
            }
            else
            {
                thueTNCN = (5000000m * 0.05m) + (5000000m * 0.10m) + (8000000m * 0.15m) + (14000000m * 0.20m) + (20000000m * 0.25m) + (28000000m * 0.30m) + ((thuNhapChiuThue - 80000000m) * 0.35m);
            }

            // Tính lương Net thực nhận
            decimal luongNet = (decimal)gross_float - tongBaoHiem - thueTNCN;

            Console.WriteLine($"\nGiảm trừ Bảo hiểm (10.5%): {tongBaoHiem:N0} VNĐ");
            Console.WriteLine($"Thu nhập chịu thuế: {thuNhapChiuThue:N0} VNĐ");
            Console.WriteLine($"Thuế TNCN phải nộp: {thueTNCN:N0} VNĐ");
            Console.WriteLine($"LƯƠNG NET THỰC NHẬN: {luongNet:N0} VNĐ");

            Console.ReadLine();
        }

        enum StockStatus
        {
            OutOfStock,
            LowStock,
            InStock,
            Discontinued
        }
        static void Bai_10()
        {
            //Bài 10: Quản Lý Tồn Kho &Xử Lý Giá Trị Khuyết Thiếu(Nullable Types)
            //Tình huống thực tế: Trong phần mềm quản lý kho hàng e-Commerce, một số mặt hàng mới nhập có thể chưa được cập nhật số lượng(Quantity = null) hoặc chưa có ngày dự kiến nhập hàng tiếp theo(RestockDate = null).
            //Kiến thức trọng tâm: Kiểu Nullable<int> (int?), Nullable<DateTime>(DateTime ?), toán tử Null - coalescing (??), toán tử Null - conditional(?.).
            //Yêu cầu bài toán:
            //• Khai báo các biến thông tin sản phẩm:
            //• +Mã sản phẩm(string), Tên sản phẩm(string)
            //• +Số lượng tồn kho: int? quantity = null; (Có thể null)
            //• +Ngưỡng tối thiểu: int minThreshold = 10;
            //• +Ngày nhập hàng tiếp theo: DateTime? restockDate = null;
            //• Sử dụng toán tử ?? để gán số lượng hiển thị mặc định = 0 nếu quantity bị null.
            //• Đánh giá trạng thái kho bằng enum StockStatus (OutOfStock, LowStock, InStock, Discontinued):
            //• + Nếu quantity == null hoặc = 0 => OutOfStock
            //• + Nếu quantity<minThreshold => LowStock
            //• + Ngược lại => InStock
            //• Sử dụng toán tử ?. và ?? để in ra Ngày nhập hàng dạng 'dd/MM/yyyy' hoặc thông báo 'Chưa có lịch nhập' nếu restockDate null.
            Console.Write("Nhập tên sản phẩm: ");
            string productName = Console.ReadLine();

            Console.Write("Nhập mã sản phẩm: ");
            string productId = Console.ReadLine();

            // Nhập số lượng tồn kho (Xử lý chuỗi rỗng hoặc chữ thành null)
            Console.Write("Nhập số lượng tồn kho (bấm Enter để bỏ trống/null): ");
            string inputQuantity = Console.ReadLine();
            int? quantity = string.IsNullOrEmpty(inputQuantity) ? null : int.Parse(inputQuantity);

            // Đặt ngưỡng tối thiểu mặc định cố định theo đề bài
            int minThreshold = 10;

            // Nhập ngày restock (Nếu bấm Enter thì coi như chưa có lịch và gán null)
            Console.Write("Nhập ngày restock (dd/mm/yyyy - bấm Enter để bỏ trống): ");
            string inputDate = Console.ReadLine();
            DateTime? restockDate = string.IsNullOrEmpty(inputDate) ? null : DateTime.ParseExact(inputDate, "dd/MM/yyyy", null);

            // Sử dụng toán tử ?? để gán số lượng hiển thị mặc định = 0 nếu quantity bị null
            int displayQuantity = quantity ?? 0;

            // Đánh giá trạng thái kho
            StockStatus status;
            if (quantity == null || quantity == 0)
            {
                status = StockStatus.OutOfStock;
            }
            else if (quantity < minThreshold)
            {
                status = StockStatus.LowStock;
            }
            else
            {
                status = StockStatus.InStock;
            }

            // Sử dụng toán tử ?. và ?? để định dạng ngày hoặc thông báo
            string restockDisplay = restockDate?.ToString("dd/MM/yyyy") ?? "Chưa có lịch nhập hàng";

            Console.WriteLine($"Sản phẩm: {productName} (Mã: {productId})");
            Console.WriteLine($"Số lượng tồn kho: {(quantity.HasValue ? quantity.ToString() : "null (Chưa kiểm kê)")}");
            Console.WriteLine($"Restock Date: {(restockDate.HasValue ? restockDate.Value.ToString("dd/MM/yyyy") : "null")}");
            Console.WriteLine($"\nSố lượng hiển thị: {displayQuantity} {(quantity == null ? "(Cảnh báo: Dữ liệu trống)" : "")}");
            Console.WriteLine($"Trạng thái kho: {status} {(status == StockStatus.OutOfStock ? "(Hết hàng)" : "")}");
            Console.WriteLine($"Dự kiến nhập hàng: {restockDisplay}");

            Console.ReadLine();
        }

        static void Bai_11()
        {
            //Bài 11: Tính Lãi Suất Tiết Kiệm Ngân Hàng & Dự Toán Tích Lũy
            //Tình huống thực tế: Khách hàng muốn gửi tiết kiệm tại ngân hàng.Chương trình cần hỗ trợ tính toán tổng số tiền cả gốc lẫn lãi thu được sau kỳ hạn gửi theo 2 phương thức: Lãi đơn và Lãi kép.
            //Kiến thức trọng tâm: Kiểu decimal, double, Math.Pow(), ép kiểu giữa decimal và double, định dạng số.
            //Yêu cầu bài toán:
            //• Nhập Số tiền gửi ban đầu P(decimal - VNĐ).
            //• Nhập Lãi suất năm r(%/ năm - kiểu double, ví dụ 6.5 %).
            //• Nhập Kỳ hạn gửi n(tháng - kiểu int, ví dụ 12 tháng).
            //• Tính Lãi Đơn(Simple Interest):
            //• +Tiền lãi đơn = P * (r / 100) * (n / 12.0).
            //• Tính Lãi Kép hàng tháng(Compound Interest):
            //• +Tổng tiền lãi kép A = P * (1 + (r / 100) / 12) ^ n.
            //• (Lưu ý: Công thức lũy thừa cần đổi P sang double để dùng Math.Pow, sau đó ép kiểu kết quả về decimal).
            //• In kết quả so sánh chênh lệch giữa Lãi kép và Lãi đơn.

            // 1. Nhập Số tiền gửi
            Console.Write("Số tiền gửi: ");
            decimal P = decimal.Parse(ReadNumberWithSuffix(" VNĐ"));

            // 2. Nhập Lãi suất năm
            Console.Write("Lãi suất năm: ");
            double r = double.Parse(ReadNumberWithSuffix(" %/năm"));

            // 3. Nhập Thời gian gửi
            Console.Write("Thời gian gửi: ");
            int n = int.Parse(ReadNumberWithSuffix(" tháng"));

            // Tính Lãi Đơn
            decimal simpleInterest = P * (decimal)(r / 100.0) * (decimal)(n / 12.0);

            // Tính Lãi Kép
            double P_double = (double)P;
            double A_double = P_double * Math.Pow(1 + (r / 100.0) / 12.0, n);
            decimal totalCompound = (decimal)A_double;
            decimal compoundInterest = totalCompound - P;

            // Tính chênh lệch
            decimal difference = compoundInterest - simpleInterest;

            // In kết quả theo đúng cấu trúc chữ của đề bài mẫu
            Console.WriteLine($"Tổng tiền lãi (Lãi đơn): {simpleInterest:N0} VNĐ");
            Console.WriteLine($"Tổng tiền lãi (Lãi kép): {compoundInterest:N0} VNĐ");
            Console.WriteLine($"Lợi nhuận chênh lệch: {difference:N0} VNĐ (Lãi kép tối ưu hơn)");

            Console.ReadLine();
        }

        // Hàm xử lý nhập số giữ nguyên tiền tố/hậu tố phía sau không bị mất chữ
        static string ReadNumberWithSuffix(string suffix)
        {
            string numberStr = "";
            int startX = Console.CursorLeft;
            int startY = Console.CursorTop;

            // In chữ đơn vị ra trước làm nền
            Console.Write(suffix);

            while (true)
            {
                // Đưa con trỏ về vị trí ngay sau chuỗi số vừa gõ
                Console.SetCursorPosition(startX + numberStr.Length, startY);

                // Đọc từng phím nhấn từ bàn phím
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // Nếu nhấn Enter -> Hoàn thành nhập
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (numberStr.Length > 0) break;
                    else continue; // Không cho nhấn Enter khi chưa gõ gì
                }

                // Nếu nhấn Backspace -> Xóa bớt số
                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (numberStr.Length > 0)
                    {
                        numberStr = numberStr.Substring(0, numberStr.Length - 1);
                        // Xóa toàn bộ dòng hiện tại để vẽ lại tránh lem chữ
                        Console.SetCursorPosition(startX, startY);
                        Console.Write(new string(' ', numberStr.Length + suffix.Length + 5));
                        Console.SetCursorPosition(startX, startY);
                        Console.Write(numberStr + suffix);
                    }
                }
                // Nhận ký tự số (0-9) và dấu chấm thập phân (cho phần trăm)
                else if (char.IsDigit(keyInfo.KeyChar) || keyInfo.KeyChar == '.')
                {
                    numberStr += keyInfo.KeyChar;
                    Console.SetCursorPosition(startX, startY);
                    Console.Write(numberStr + suffix);
                }
            }

            // Xuống dòng sau khi hoàn thành một lượt nhập
            Console.WriteLine();
            return numberStr;
        }

        static void Bai_12()
        {
            //Bài 12: Bộ Mã Hóa & Giải Mã Tin Nhắn Mật Mã Caesar(Caesar Cipher)
            //Tình huống thực tế: Trong một ứng dụng trò chuyện bảo mật, các tin nhắn văn bản ngắn cần được mã hóa đơn giản bằng thuật toán Caesar Cipher(dịch chuyển ký tự trong bảng mã ASCII) trước khi lưu trữ.
            //Kiến thức trọng tâm: Kiểu char, string, ép kiểu nguyên(int) <-> (char), bảng mã ASCII / Unicode, phép toán chia lấy dư(%).
            //Yêu cầu bài toán:
            //• Nhập vào một chuỗi văn bản cần mã hóa(string) và một số nguyên Key k(từ 1 đến 25).
            //• Duyệt qua từng ký tự char trong chuỗi:
            //• +Nếu là chữ cái in hoa('A' - 'Z'): Dịch chuyển k vị trí trong bảng chữ cái: newChar = (char)('A' + (c - 'A' + k) % 26).
            //• +Nếu là chữ cái in thường('a' - 'z'): Dịch chuyển tương tự với gốc 'a'.
            //• +Nếu là chữ số, khoảng trắng hoặc dấu câu: Giữ nguyên không đổi.
            //• Tạo chuỗi đã mã hóa(Encrypted String).
            //• Mô phỏng quá trình giải mã(Decrypted String) bằng cách dịch ngược lại k vị trí và in kết quả kiểm tra.
            Console.Write("Văn bản gốc: ");
            string originalText = Console.ReadLine();

            Console.Write("Khóa dịch chuyển (Shift Key k): ");
            int k = int.Parse(Console.ReadLine());

            // Gọi hàm cục bộ để mã hóa
            string encryptedText = EncryptCaesar(originalText, k);
            Console.WriteLine($"\nVăn bản Mã hóa: {encryptedText}");

            // Gọi hàm cục bộ để giải mã
            string decryptedText = DecryptCaesar(encryptedText, k);
            Console.WriteLine($"Văn bản Giải mã: {decryptedText}");


            // ==========================================
            // HÀM CỤC BỘ (LOCAL FUNCTIONS) ĐẶT Ở CUỐI HÀM
            // ==========================================

            // Hàm mã hóa Caesar cục bộ
            string EncryptCaesar(string input, int key)
            {
                char[] result = input.ToCharArray();
                for (int i = 0; i < result.Length; i++)
                {
                    char c = result[i];

                    if (c >= 'A' && c <= 'Z')
                    {
                        int asciiC = (int)c;
                        int asciiA = (int)'A';
                        int newAscii = asciiA + (asciiC - asciiA + key) % 26;
                        result[i] = (char)newAscii;
                    }
                    else if (c >= 'a' && c <= 'z')
                    {
                        int asciiC = (int)c;
                        int asciiA = (int)'a';
                        int newAscii = asciiA + (asciiC - asciiA + key) % 26;
                        result[i] = (char)newAscii;
                    }
                }
                return new string(result);
            }

            // Hàm giải mã Caesar cục bộ
            string DecryptCaesar(string input, int key)
            {
                char[] result = input.ToCharArray();
                for (int i = 0; i < result.Length; i++)
                {
                    char c = result[i];

                    if (c >= 'A' && c <= 'Z')
                    {
                        int asciiC = (int)c;
                        int asciiA = (int)'A';
                        int newAscii = asciiA + (asciiC - asciiA - key + 26) % 26;
                        result[i] = (char)newAscii;
                    }
                    else if (c >= 'a' && c <= 'z')
                    {
                        int asciiC = (int)c;
                        int asciiA = (int)'a';
                        int newAscii = asciiA + (asciiC - asciiA - key + 26) % 26;
                        result[i] = (char)newAscii;
                    }
                }
                return new string(result);
            }
        }

        // 1. Tạo enum VehicleType đúng yêu cầu
        enum VehicleType { Motorbike, Car, Truck }
        static void Bai_13()
        {
            //Bài 13: Bãi Đỗ Xe Thông Minh & Tính Phí Gửi Xe Theo Thời Gian
            //Tình huống thực tế: Hệ thống thẻ từ bãi đỗ xe thông minh tự động ghi nhận thời điểm xe vào và xe ra để tính chính xác phí gửi xe dựa trên loại phương tiện và thời lượng đỗ.
            //Kiến thức trọng tâm: Kiểu DateTime, TimeSpan, enum (VehicleType), Math.Ceiling, decimal.
            //Yêu cầu bài toán:
            //• Tạo enum VehicleType { Motorbike, Car, Truck }.
            //• Nhập loại xe, thời gian xe vào(CheckIn) và thời gian xe ra(CheckOut) dạng 'yyyy-MM-dd HH:mm'.
            //• Tính thời gian đỗ TotalHours = (CheckOut - CheckIn).TotalHours.Làm tròn lên số giờ nguyên bằng Math.Ceiling.
            //• Quy tắc tính giá:
            //• + Motorbike: 5,000 VNĐ cho 2 giờ đầu; Mỗi giờ tiếp theo +2,000 VNĐ/giờ.
            //• + Car: 20,000 VNĐ cho 2 giờ đầu; Mỗi giờ tiếp theo +10,000 VNĐ/giờ.
            //• + Truck: 50,000 VNĐ cho 2 giờ đầu; Mỗi giờ tiếp theo +25,000 VNĐ/giờ.
            //• Phụ phí qua đêm: Nếu thời gian đỗ gửi qua thời điểm 00:00 đêm, cộng thêm phụ phí 30,000 VNĐ.
            //• Xuất hóa đơn gửi xe chi tiết.
      
            Console.Write("Loại xe: ");
            string vehicleInput = Console.ReadLine()?.Trim();

            // Tự động nhận diện loại xe (chấp nhận cả "Car", "Car (Ô tô)", v.v.)
            VehicleType vehicle = VehicleType.Car;
            if (vehicleInput != null)
            {
                if (vehicleInput.StartsWith("Motorbike", StringComparison.OrdinalIgnoreCase)) vehicle = VehicleType.Motorbike;
                else if (vehicleInput.StartsWith("Car", StringComparison.OrdinalIgnoreCase)) vehicle = VehicleType.Car;
                else if (vehicleInput.StartsWith("Truck", StringComparison.OrdinalIgnoreCase)) vehicle = VehicleType.Truck;
            }

            string format = "yyyy-MM-dd HH:mm";

            Console.Write("Giờ vào: ");
            DateTime checkIn = DateTime.ParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture);

            Console.Write("Giờ ra: ");
            DateTime checkOut = DateTime.ParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture);

            // 2. Tính toán thời gian bằng TimeSpan.TotalHours và làm tròn lên bằng Math.Ceiling
            double actualHours = (checkOut - checkIn).TotalHours;
            int totalHours = (int)Math.Ceiling(actualHours);

            Console.WriteLine($"\nTổng thời gian đỗ: {actualHours:F2} giờ -> Tính phí: {totalHours} giờ");

            // 3. Khai báo giá tiền dạng decimal theo yêu cầu kiến thức trọng tâm
            decimal basePrice = 0;
            decimal extraPricePerHour = 0;

            switch (vehicle)
            {
                case VehicleType.Motorbike:
                    basePrice = 5000;
                    extraPricePerHour = 2000;
                    break;
                case VehicleType.Car:
                    basePrice = 20000;
                    extraPricePerHour = 10000;
                    break;
                case VehicleType.Truck:
                    basePrice = 50000;
                    extraPricePerHour = 25000;
                    break;
            }

            // Tính số giờ tiếp theo (nếu tổng số giờ lớn hơn 2)
            int nextHours = totalHours > 2 ? totalHours - 2 : 0;
            decimal baseFee = basePrice;
            decimal extraFee = nextHours * extraPricePerHour;

            // Tính phụ phí qua đêm (nếu ngày ra lớn hơn ngày vào)
            decimal overnightFee = 0;
            if (checkOut.Date > checkIn.Date)
            {
                overnightFee = 30000;
            }

            decimal totalFee = baseFee + extraFee + overnightFee;

            // Xuất chi tiết hóa đơn theo định dạng ví dụ mẫu
            Console.WriteLine($"Phí 2 giờ đầu: {baseFee:N0} VNĐ");
            Console.WriteLine($"Phí {nextHours} giờ tiếp theo: {extraFee:N0} VNĐ ({extraPricePerHour:N0} x {nextHours})");

            if (overnightFee > 0)
            {
                Console.WriteLine($"Phụ phí qua đêm: {overnightFee:N0} VNĐ");
            }

            Console.WriteLine($"TỔNG PHÍ ĐỖ XE: {totalFee:N0} VNĐ");

            Console.ReadLine();
        }

        static void Bai_14()
        {
            //Bài 14: Xử Lý Chuỗi Số An Toàn &Kiểm Tra Tràn Số(Overflow Exception)
            //Tình huống thực tế: Trong các ứng dụng nhận dữ liệu từ người dùng hoặc file ngoại vi, dữ liệu nhập vào có thể không phải là số hợp lệ hoặc vượt quá khả năng lưu trữ của kiểu dữ liệu. Cần xử lý an toàn.
            //Kiến thức trọng tâm: Kiểu int.TryParse, long.TryParse, byte, short, int, long, khối checked { } và OverflowException.
            //Yêu cầu bài toán:
            //• Mời người dùng nhập vào một chuỗi bất kỳ từ bàn phím.
            //• Sử dụng int.TryParse để kiểm tra xem chuỗi có phải là một số nguyên hợp lệ hay không.Nếu không, thông báo lỗi và yêu cầu nhập lại.
            //• Nếu hợp lệ, hãy kiểm tra xem giá trị đó có thể lưu trữ vừa trong kiểu dữ liệu nhỏ hơn như byte(0 - 255) hoặc short(-32, 768 đến 32, 767) hay không.
            //• Thực hiện tính Tổng các chữ số cấu thành nên số nguyên đó.
            //• Thực hiện đoạn mã thử nghiệm tính tích lũy lũy thừa / nhân số đó trong khối checked { ... } để bắt ngoại lệ OverflowException nếu xảy ra tràn số trong C#.
            int numberResult;
            string input;

            // Vòng lặp yêu cầu nhập lại nếu chuỗi không phải số nguyên hợp lệ
            while (true)
            {
                Console.Write("Nhập chuỗi số: ");
                input = Console.ReadLine();

                // 1. Sử dụng int.TryParse để kiểm tra xem chuỗi có phải là số nguyên hợp lệ hay không
                if (int.TryParse(input, out numberResult))
                {
                    break; // Hợp lệ thì thoát vòng lặp
                }
                else
                {
                    Console.WriteLine("Thông báo lỗi: Chuỗi nhập vào không hợp lệ. Vui lòng nhập lại!\n");
                }
            }

            Console.WriteLine("--- OUTPUT ---");
            Console.WriteLine($"Kiểm tra Parse: Thành công! Giá trị int = {numberResult}");

            // 2. Kiểm tra xem giá trị đó có thể lưu trữ vừa trong kiểu dữ liệu nhỏ hơn (byte, short)
            if (numberResult >= 0 && numberResult <= 255)
            {
                Console.WriteLine("Phù hợp kiểu byte: Có (Vừa vặn trong dải 0-255)");
            }
            else if (numberResult >= -32768 && numberResult <= 32767)
            {
                Console.WriteLine("Phù hợp kiểu short: Có (Vừa vặn trong dải -32,768 đến 32,767)");
            }
            else
            {
                Console.WriteLine("Phù hợp kiểu byte/short: Không (Vượt quá dải lưu trữ của byte và short)");
            }

            // 3. Thực hiện tính Tổng các chữ số cấu thành nên số nguyên đó
            int temp = Math.Abs(numberResult); // Lấy giá trị tuyệt đối để xử lý cả số âm
            int sum = 0;
            string digitsStr = "";

            while (temp > 0)
            {
                int digit = temp % 10;
                sum += digit;
                digitsStr = digit + (digitsStr == "" ? "" : " + " + digitsStr);
                temp /= 10;
            }
            if (numberResult == 0) { sum = 0; digitsStr = "0"; }
            Console.WriteLine($"Tổng các chữ số: {digitsStr} = {sum}");

            // 4. Thực hiện đoạn mã thử nghiệm tính tích lũy lũy thừa/nhân số đó trong khối checked { ... }
            try
            {
                checked
                {
                    // Thử nghiệm nhân tích lũy với chính nó để kiểm tra tràn số trong phạm vi int32
                    int overflowTest = numberResult * numberResult;
                    Console.WriteLine("Kiểm tra Tràn số: An toàn trong phạm vi int32.");
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Kiểm tra Tràn số: Phát hiện ngoại lệ tràn số (OverflowException) trong phạm vi int32!");
            }

            Console.ReadLine();
        }

        enum CustomerType
        {
            Child,
            Student,
            Adult,
            Senior
        }
        static void Bai_15()
        {
            //Bài 15: Hệ Thống Bán Vé Rạp Chiếu Phim & Chiết Khấu Tự Động
            //Tình huống thực tế: Rạp chiếu phim Cinema X áp dụng chính sách giá vé linh hoạt phụ thuộc vào đối tượng khách hàng, ngày trong tuần và các chương trình khuyến mãi tự động.
            //Kiến thức trọng tâm: Enum CustomerType(Child, Student, Adult, Senior), DayOfWeek, decimal, bool, cấu trúc logic điều kiện.
            //Yêu cầu bài toán:
            //• Khai báo enum CustomerType { Child, Student, Adult, Senior }.
            //• Giá vé gốc tiêu chuẩn(Base Price) = 100,000 VNĐ.
            //• Nhập thông tin mua vé: Loại khách hàng(CustomerType), Ngày xem phim trong tuần(DayOfWeek), và Có thẻ sinh viên hợp lệ hay không(bool).
            //• Quy tắc giảm giá / Phụ thu:
            //• + Trẻ em(Child, <12 tuổi) hoặc Người cao tuổi(Senior, >60 tuổi): Giảm 50% giá gốc.
            //• + Sinh viên (Student, có thẻ): Giảm 30% giá gốc vào các ngày từ Thứ 2 đến Thứ 5.
            //• + Khuyến mãi Thứ 4 Vui Vẻ (Wednesday): Giảm 20% cho tất cả khách hàng Adult.
            //• + Phụ thu Cuối tuần (Friday, Saturday, Sunday): Cộng thêm 20,000 VNĐ/vé.
            //• In vé xem phim chi tiết gồm: Giá gốc, Khoản giảm giá, Phụ thu cuối tuần và Giá vé thanh toán cuối cùng.
            // 1. Cấu hình mặc định
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

            Console.ReadLine();
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Bai_1();
            Bai_2();
            Bai_3();
            Bai_4();
            Bai_5();
            Bai_6();
            Bai_7();
            Bai_8();
            Bai_9();
            Bai_10();
            Bai_11();
            Bai_12();
            Bai_13();
            Bai_14();
            Bai_15();

            Console.Write("\nNhấn phím bất kỳ để kết thúc");
            Console.ReadKey();

        }
    }
}
