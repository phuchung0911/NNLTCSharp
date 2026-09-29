using System;
using System.Text;

namespace ThucHanh01
{
    class Cau11
    {
        // Phương thức đảo ngược chuỗi sử dụng StringBuilder
        public static string DaoNguocChuoi(string s)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = s.Length - 1; i >= 0; i--)
            {
                sb.Append(s[i]);
            }

            return sb.ToString();
        }

        public static void Main(string[] args)
        {
            // Khai báo biến
            string str, ketQua;

            // Nhập dữ liệu
            Console.Write("Nhap chuoi ban dau: ");
            str = Console.ReadLine();

            // Xử lý bằng cách gọi hàm
            ketQua = DaoNguocChuoi(str);

            // Xuất kết quả
            Console.WriteLine("Chuoi sau khi dao nguoc la: {0}", ketQua);
        }
    }
}