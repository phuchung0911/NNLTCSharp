using System;

namespace ThucHanh01
{
    class Cau09
    {
        // Phương thức sử dụng tham số out để trả về 2 kết quả cùng lúc
        public static void TimMaxMin(double a, double b, double c, out double max, out double min)
        {
            // Tìm số lớn nhất
            max = a;
            if (b > max) max = b;
            if (c > max) max = c;

            // Tìm số nhỏ nhất
            min = a;
            if (b < min) min = b;
            if (c < min) min = c;
        }

        public static void Main(string[] args)
        {
            // Khai báo biến
            double so1, so2, so3;
            double lonNhat, nhoNhat;

            // Nhập dữ liệu
            Console.Write("Nhap so thuc thu nhat: ");
            so1 = double.Parse(Console.ReadLine());

            Console.Write("Nhap so thuc thu hai: ");
            so2 = double.Parse(Console.ReadLine());

            Console.Write("Nhap so thuc thu ba: ");
            so3 = double.Parse(Console.ReadLine());

            // Gọi phương thức truyền tham chiếu out
            TimMaxMin(so1, so2, so3, out lonNhat, out nhoNhat);

            // Xuất kết quả
            Console.WriteLine("Gia tri lon nhat la: {0}", lonNhat);
            Console.WriteLine("Gia tri nho nhat la: {0}", nhoNhat);
        }
    }
}