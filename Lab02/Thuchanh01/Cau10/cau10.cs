using System;

namespace ThucHanh01
{
    class Cau10
    {
        // Phương thức kiểm tra chuỗi đối xứng
        public static bool KiemTraDoiXung(string s)
        {
            int trai = 0;
            int phai = s.Length - 1;

            while (trai < phai)
            {
                if (s[trai] != s[phai])
                {
                    return false;
                }
                trai++;
                phai--;
            }

            return true;
        }

        public static void Main(string[] args)
        {
            // Khai báo biến
            string str;

            // Nhập dữ liệu
            Console.Write("Nhap vao mot chuoi: ");
            str = Console.ReadLine();

            // Xử lý và xuất kết quả
            if (KiemTraDoiXung(str))
            {
                Console.WriteLine("Chuoi \"{0}\" la chuoi doi xung.", str);
            }
            else
            {
                Console.WriteLine("Chuoi \"{0}\" khong phai la chuoi doi xung.", str);
            }
        }
    }
}