using System;
using System.Collections.Generic;
using System.Text;

namespace CSLT_INF509005_T2.session05
{
    internal class Exercise_Guessing_Game_Engine
    {
        public static void Main3(string[] args)
        {
            guessing_game_engine();
            guessing_game_engine_5_times();
        }

        ///<summary>
        ///1. Máy tính nghĩ ngẫu nhiên 1 số. [1-10]
        ///2. Hỏi người dùng đoán số
        ///3. Nếu người dùng đoán đúng thì thông báo
        ///     nếu người dùng đoán nhỏ/lớn hơn thì thông báo nhỏ/lớn hơn
        ///     
        /// chơi cho đến khi người dùng chọn không chơi nữa
        /// Thống kê số lần thắng, thua
        ///</summary>
        static void guessing_game_engine()
        {
            //1. Máy tính nghĩ ngẫu nhiên 1 số. [1-10]
            Random rnd = new Random();//thư viện tạo số ngẫu nhiên
            int com_num = rnd.Next(10) + 1;//[1-10]

            //2. Hỏi người dùng đoán số
            Console.Write("Bạn đoán số mấy? ");
            int user_num = int.Parse(Console.ReadLine());

            //3. So sánh đáp án
            if (user_num == com_num)
            {
                Console.WriteLine("Bravo!, bạn là thiên tài.");
            }
            else if (user_num < com_num)
            {
                Console.WriteLine("Bạn đoán số nhỏ hơn máy nghĩ");
            }    
            else
            {
                Console.WriteLine("Bạn đoán số lớn hơn máy nghĩ");
            }    
        }

        static void guessing_game_engine_5_times()
        {
            bool continue_play = true;
            int dem_thang = 0, tong_so_van_choi = 0;
            int level = 1;
            int so_lan_doan = 0;
            do
            {
                tong_so_van_choi++;

                //cho người dùng chọn mức độ
                while (true)
                {
                    Console.Write("Bạn chơi mức độ nào <1-dễ; 2-trung bình; 3-khó>? ");
                    level = int.Parse(Console.ReadLine());
                    if (level == 1)
                    {
                        so_lan_doan = 9;
                        break;
                    }
                    else if (level == 2)
                    {
                        so_lan_doan = 6;
                        break;
                    }
                    else if (level == 3)
                    {
                        so_lan_doan = 3;
                        break;
                    }
                    else
                    {

                        Console.WriteLine("Độ khó không hợp lệ (1-3). Hãy chọn lại!");
                    }
                }

                    //1. Máy tính nghĩ ngẫu nhiên 1 số. [1-100]
                    Random rnd = new Random();//thư viện tạo số ngẫu nhiên
                    int com_num = rnd.Next(100) + 1;//[1-100]

                    //2. Hỏi người dùng đoán số. Cho đoán 5 lần
                    for (int i = 0; i < so_lan_doan; i++)
                    {
                        Console.Write("Bạn đoán số mấy? ");
                        int user_num = int.Parse(Console.ReadLine());
                    
                    //3. So sánh đáp án
                    if (user_num == com_num)
                    {
                        dem_thang++;
                        Console.WriteLine("Bravo!, bạn là thiên tài.");
                        Console.WriteLine($"Bạn đã đoán đúng sau {i+1} ");
                        break;
                    }
                    else if (user_num < com_num)
                    {
                        Console.WriteLine("Bạn đoán số nhỏ hơn máy nghĩ");
                    }
                    else
                    {
                        Console.WriteLine("Bạn đoán số lớn hơn máy nghĩ");
                    }
                }
                Console.WriteLine($"Số máy nghĩ ra là {com_num}");
                //xong 1 lần chơi

                //hỏi người chơi chơi nữa không
                string tl;
                while (true)
                {
                    Console.Write("Bạn dám chơi nữa không <c/k? ");
                    tl = Console.ReadLine().ToLower();
                    if (tl == "k" || tl == "c") break;
                    Console.WriteLine("Nhập sai ký tự. Hãy nhập lại.");                    
                }

                if (tl == "c")
                {
                    Console.WriteLine("Bắt đầu ván chơi....");
                }   
                else
                {
                    continue_play = false;
                    
                }    
            } while (continue_play);
        }
    }
}
