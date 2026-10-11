using System;

namespace ThucHanh01
{
    class Cau04
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int x, y;
            bool hopLeX, hopLeY;
            double ketQua;

            // Nhập dữ liệu và kiểm tra số nguyên
            Console.Write("Nhap so nguyen x: ");
            hopLeX = int.TryParse(Console.ReadLine(), out x);

            Console.Write("Nhap so nguyen y: ");
            hopLeY = int.TryParse(Console.ReadLine(), out y);

            // Xử lý và xuất kết quả
            if (hopLeX && hopLeY)
            {
                ketQua = Math.Pow(x, y);
                Console.WriteLine("Ket qua {0}^{1} la: {2}", x, y, ketQua);
            }
            else
            {
                Console.WriteLine("x hoac y khong phai la so nguyen!");
            }
        }
    }
}