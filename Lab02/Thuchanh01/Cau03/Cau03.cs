using System;

namespace ThucHanh01
{
    class Cau03
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int x, y;
            double ketQua;

            // Nhập dữ liệu
            Console.Write("Nhap so nguyen x: ");
            x = int.Parse(Console.ReadLine());

            Console.Write("Nhap so nguyen y: ");
            y = int.Parse(Console.ReadLine());

            // Xử lý
            ketQua = Math.Pow(x, y);

            // Xuất kết quả
            Console.WriteLine("Ket qua {0} mu {1} la: {2}", x, y, ketQua);
        }
    }
}